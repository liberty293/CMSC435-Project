using UnityEngine;
using System.Collections;

public class lb_Bird_copy : MonoBehaviour {


	public AudioClip song1;
	public AudioClip song2;
	public AudioClip flyAway1;
	public AudioClip flyAway2;



	Animator anim;
	lb_BirdController_copy controller;

	bool flying = false;
	bool dead = false;
	BoxCollider birdCollider;
	Vector3 bColCenter;
	Vector3 bColSize;
	SphereCollider solidCollider;
	float distanceToTarget = 0.0f;
	float agitationLevel = .5f;
	float originalAnimSpeed = 1.0f;
	Vector3 originalVelocity = Vector3.zero;

	//hash variables for the animation states and animation properties
	int idleAnimationHash;
	int singAnimationHash;
	int ruffleAnimationHash;
	int preenAnimationHash;
	int peckAnimationHash;
	int hopForwardAnimationHash;
	int hopBackwardAnimationHash;
	int hopLeftAnimationHash;
	int hopRightAnimationHash;
	int worriedAnimationHash;
	int landingAnimationHash;
	int flyAnimationHash;
	int hopIntHash;
	int flyingBoolHash;
	//int perchedBoolHash;
	int peckBoolHash;
	int ruffleBoolHash;
	int preenBoolHash;
	//int worriedBoolHash;
	int landingBoolHash;
	int singTriggerHash;
	int flyingDirectionHash;
	int dieTriggerHash;

	void OnEnable () {
		birdCollider = gameObject.GetComponent<BoxCollider>();
		bColCenter = birdCollider.center;
		bColSize = birdCollider.size;
		solidCollider = gameObject.GetComponent<SphereCollider>();
		anim = gameObject.GetComponent<Animator>();

		idleAnimationHash = Animator.StringToHash("Base Layer.Idle");
		//singAnimationHash = Animator.StringToHash ("Base Layer.sing");
		//ruffleAnimationHash = Animator.StringToHash ("Base Layer.ruffle");
		//preenAnimationHash = Animator.StringToHash ("Base Layer.preen");
		//peckAnimationHash = Animator.StringToHash ("Base Layer.peck");
		//hopForwardAnimationHash = Animator.StringToHash ("Base Layer.hopForward");
		//hopBackwardAnimationHash = Animator.StringToHash ("Base Layer.hopBack");
		//hopLeftAnimationHash = Animator.StringToHash ("Base Layer.hopLeft");
		//hopRightAnimationHash = Animator.StringToHash ("Base Layer.hopRight");
		//worriedAnimationHash = Animator.StringToHash ("Base Layer.worried");
		//landingAnimationHash = Animator.StringToHash ("Base Layer.landing");
		flyAnimationHash = Animator.StringToHash ("Base Layer.fly");
		hopIntHash = Animator.StringToHash ("hop");
		flyingBoolHash = Animator.StringToHash("flying");
		//perchedBoolHash = Animator.StringToHash("perched");
		peckBoolHash = Animator.StringToHash("peck");
		ruffleBoolHash = Animator.StringToHash("ruffle");
		preenBoolHash = Animator.StringToHash("preen");
		//worriedBoolHash = Animator.StringToHash("worried");
		landingBoolHash = Animator.StringToHash("landing");
		singTriggerHash = Animator.StringToHash ("sing");
		flyingDirectionHash = Animator.StringToHash("flyingDirectionX");
		dieTriggerHash = Animator.StringToHash ("die");
		anim.SetFloat ("IdleAgitated",agitationLevel);
		if (dead){
			Revive();
		}
	}

	

	//Sets a variable between -1 and 1 to control the left and right banking animation
	float FindBankingAngle(Vector3 birdForward, Vector3 dirToTarget){
		Vector3 cr = Vector3.Cross (birdForward,dirToTarget);
		float ang = Vector3.Dot (cr,Vector3.up);
		return ang;
	}
	


	void OnTriggerEnter(Collider col){
		if (col.tag == "lb_bird"){
			FlyAway ();
		}
	}


	void AbortFlyToTarget(){
		StopCoroutine("FlyToTarget");
		solidCollider.enabled = false;
		anim.SetBool(landingBoolHash, false);
		anim.SetFloat (flyingDirectionHash,0);
		transform.localEulerAngles = new Vector3(
			0.0f,
			transform.localEulerAngles.y,
			0.0f);
		FlyAway ();
	}
	
	void FlyAway(){
		if(!dead){
			StopCoroutine("FlyToTarget");
			anim.SetBool(landingBoolHash, false);
			controller.SendMessage ("BirdFindTarget",gameObject);
		}
	}


	public void KillBird(){
		if(!dead){
			controller.SendMessage ("FeatherEmit",transform.position);
			anim.SetTrigger(dieTriggerHash);
			anim.applyRootMotion = false;
			dead = true;
			flying = false;
			AbortFlyToTarget();
			StopAllCoroutines();
			GetComponent<Collider>().isTrigger = false;
			birdCollider.center = new Vector3(0.0f,0.0f,0.0f);
			birdCollider.size = new Vector3(0.1f,0.01f,0.1f)*controller.birdScale;
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Rigidbody>().useGravity = true;
		}
	}

	public void KillBirdWithForce(Vector3 force){
		if(!dead){
			controller.SendMessage ("FeatherEmit",transform.position);
			anim.SetTrigger(dieTriggerHash);
			anim.applyRootMotion = false;
			dead = true;
			flying = false;

			AbortFlyToTarget();
			StopAllCoroutines();
			GetComponent<Collider>().isTrigger = false;
			birdCollider.center = new Vector3(0.0f,0.0f,0.0f);
			birdCollider.size = new Vector3(0.1f,0.01f,0.1f)*controller.birdScale;
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody>().AddForce (force);
		}
	}

	void Revive(){
		if(dead){
			birdCollider.center = bColCenter;
			birdCollider.size = bColSize;
			GetComponent<Collider>().isTrigger = true;
			dead = false;
			flying = false;
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Rigidbody>().useGravity = false;
			anim.Play (idleAnimationHash);
			controller.SendMessage ("BirdFindTarget",gameObject);
		}
	}

	void SetController(lb_BirdController_copy cont){
		controller = cont;
	}

	void ResetHopInt(){
		anim.SetInteger (hopIntHash, 0);
	}

	void ResetFlyingLandingVariables(){
		if (flying){
			flying = false;
		}
	}

	void PlaySong(){
		if (!dead){
			if(Random.value < .5){
				GetComponent<AudioSource>().PlayOneShot (song1,1);
			}else{
				GetComponent<AudioSource>().PlayOneShot (song2,1);
			}
		}
	}

}
