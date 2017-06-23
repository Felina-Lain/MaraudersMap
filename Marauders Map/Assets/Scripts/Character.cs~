using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Rank
{

	Ghost = -1,
	Teacher = 0,
	StudentGryffindor = 1,
	StudentSlytherin = 2,
	StudentRavenclaw = 3,
	StudentHufflepuff = 4

}

public class Character : MonoBehaviour {

	[Header("what character is it")]
	public Rank rank_type;

	[Header("Where this character go")]
	public Transform target;
	public float speed;



	[Header("Random moving around")]
	public float wanderRadius;
	public float wanderTimer;


	//to navigate the random moving
	Transform randomNavtarget;
	UnityEngine.AI.NavMeshAgent agent;
	float timer;
	int attitude;

	// Use this for initialization
	void Start () {

		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		timer = wanderTimer;
		
	}
	
	// Update is called once per frame
	void Update () {

		agent.speed = speed;

		if(target != null){
			GoingTo();
		}


		switch(attitude){

		case 1:
			WalkingAroundRandom();
			Debug.Log("WAR");
			break;

		case 2:
			Debug.Log("SA");
			break;

		default:
			break;
		}
		
	}

	void WalkingAroundRandom(){

		// Update is called once per frame

			timer += Time.deltaTime;

			if (timer >= wanderTimer) {
				Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
				agent.SetDestination(newPos);
				timer = 0;
			}

	}


	void GoingTo(){

		float distance = Vector3.Distance(this.transform.position, target.transform.position);

		//Move the square towards the current target
		agent.SetDestination(target.position);


		//In case the square arrived to the target waypoint (very small distance)
		if ((distance - this.transform.position.y) <= 0.1f){
			
			target.GetComponent<Room>().AddStudent(this);

			target = null;
			//random range min inclusive, max exclusive
			attitude = Random.Range(1,3);
		}

	}


	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
		Vector3 randDirection = Random.insideUnitSphere * dist;

		randDirection += origin;

		UnityEngine.AI.NavMeshHit navHit;

		UnityEngine.AI.NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);

		return navHit.position;
	}
		
}
