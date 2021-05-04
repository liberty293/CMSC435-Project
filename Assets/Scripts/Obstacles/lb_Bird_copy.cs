using UnityEngine;
using System.Collections;

public class lb_Bird_copy : SyncAnimation {


	public Controls controls;
	bool pointsAwarded=false;
	public GameObject FEmit;
	private GameObject fEmit;
	Animator anim;



	bool dead = false;


	//hash variables for the animation states and animation properties

	int flyingBoolHash;

	int dieTriggerHash;

	protected override void   OnEnable () {
		base.OnEnable();
		dead = false;
		fEmit = Instantiate(FEmit, Vector3.zero, Quaternion.identity);
		fEmit.SetActive(false);
		anim = gameObject.GetComponent<Animator>();
		flyingBoolHash = Animator.StringToHash("flying");
		dieTriggerHash = Animator.StringToHash ("die");
		anim.applyRootMotion = false;
		anim.SetBool(flyingBoolHash, true);
		initPosition = new Vector3(initPosition.x-.5f, initPosition.y + 3, initPosition.z);
		finPosition = new Vector3(finPosition.x-.5f, finPosition.y + 3, finPosition.z);
	}



    //Sets a variable between -1 and 1 to control the left and right banking animation



	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag(BearTag) && !pointsAwarded)
		{
			if (other.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(1).IsName("Bird") && other.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime < .5)
			{
				//Debug.Log("Award Points");
				score.AddScore(points);
				pointsAwarded = true;
				KillBird();
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{

        //		KillBird();
        if (!pointsAwarded)
        {
            other.GetComponentInChildren<Player>().TakeDamage(1);
			StartCoroutine("DeactivateFeathers", (fEmit));
        }
    }



	public void KillBird(){
		if(!dead){
			FeatherEmit (new Vector3(transform.position.x, transform.position.y, 0));
			for (int i=0; i<transform.childCount; i++)
            {
				transform.GetChild(i).gameObject.SetActive(false);
            }
			dead = true;
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Rigidbody>().useGravity = true;
		}
	}

	void FeatherEmit(Vector3 pos)
	{
			if (!fEmit.activeSelf)
			{
				fEmit.transform.position = pos;
//			Debug.Log(fEmit.transform.position);
				fEmit.SetActive(true);
				StartCoroutine("DeactivateFeathers",(fEmit));
				
			}
		
	}

	IEnumerator DeactivateFeathers(GameObject featherEmit)
	{
//		Debug.Log("wait");
		yield return new WaitForSeconds(1f);
//		Debug.Log("Destroy");
		Destroy(featherEmit);
		Destroy(gameObject);
	}




}
