using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class lb_BirdController_copy: MonoBehaviour {
	public bool highQuality = true;
	public bool collideWithObjects = true;
	public LayerMask groundLayer;
	public float birdScale = 1.0f;

	public bool robin = true;
	public bool blueJay = true;
	public bool cardinal = true;
	public bool chickadee = true;
	public bool sparrow = true;
	public bool goldFinch = true;
	public bool crow = true;


	GameObject[] myBirds;
	List<string> myBirdTypes = new List<string>();
	GameObject[] featherEmitters = new GameObject[3];
	


	void Start () {


		//set up the bird types to use
		if(robin){
			myBirdTypes.Add ("lb_robin");
		}
		if (blueJay){
			myBirdTypes.Add ("lb_blueJay");
		}
		if(cardinal){
			myBirdTypes.Add ("lb_cardinal");
		}
		if(chickadee){
			myBirdTypes.Add ("lb_chickadee");
		}
		if(sparrow){
			myBirdTypes.Add ("lb_sparrow");
		}
		if(goldFinch){
			myBirdTypes.Add ("lb_goldFinch");
		}
		if(crow){
			myBirdTypes.Add ("lb_crow");
		}
		//Instantiate birds based on amounts and bird types
		myBirds = new GameObject[myBirdTypes.Count];
		GameObject bird;
		for(int i=0;i<myBirds.Length;i++){
			if(highQuality){
				bird = Resources.Load (myBirdTypes[i]+"HQ",typeof(GameObject)) as GameObject;
			}else{
				bird = Resources.Load (myBirdTypes[i],typeof(GameObject)) as GameObject;
			}
			myBirds[i] = Instantiate (bird,Vector3.zero,Quaternion.identity) as GameObject;
			myBirds[i].transform.localScale = myBirds[i].transform.localScale*birdScale;
			myBirds[i].transform.parent = transform;
			myBirds[i].SendMessage ("SetController",this);
			myBirds[i].SetActive (false);
		}





		//instantiate 3 feather emitters for killing the birds
		GameObject fEmitter = Resources.Load ("featherEmitter",typeof(GameObject)) as GameObject;
		for(int i=0;i<3;i++){
			featherEmitters[i] = Instantiate (fEmitter,Vector3.zero,Quaternion.identity) as GameObject;
			featherEmitters[i].transform.parent = transform;
			featherEmitters[i].SetActive (false);
		}
	}


	void Unspawn(GameObject bird){
		bird.transform.position = Vector3.zero;
		bird.SetActive (false);
	}

	void SpawnBird(){
			GameObject bird = null;
			int randomBirdIndex = Mathf.FloorToInt (Random.Range (0,myBirds.Length));
			int loopCheck = 0;
			//find a random bird that is not active
			while(bird == null){
				if(myBirds[randomBirdIndex].activeSelf == false){
					bird = myBirds[randomBirdIndex];
				}
				randomBirdIndex = randomBirdIndex+1 >= myBirds.Length ? 0:randomBirdIndex+1;
				loopCheck ++;
				if (loopCheck >= myBirds.Length){
					//all birds are active
					return;
				}
			}
	}


	
	
	

	void FeatherEmit(Vector3 pos){
		foreach (GameObject fEmit in featherEmitters){
			if(!fEmit.activeSelf){
				fEmit.transform.position = pos;
				fEmit.SetActive (true);
				StartCoroutine("DeactivateFeathers",fEmit);
				break;
			}
		}
	}

	IEnumerator DeactivateFeathers(GameObject featherEmit){
		yield return new WaitForSeconds(4.5f);
		featherEmit.SetActive (false);
	}
}
