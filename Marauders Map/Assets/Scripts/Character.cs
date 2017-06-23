using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum Rank
{

	Ghost = -1,
	Teacher = 0,
	Gryffindor = 1,
	Slytherin = 2,
	Ravenclaw = 3,
	Hufflepuff = 4

}

public class Character : MonoBehaviour {

	[Header("what character is it")]
	public Rank rank_type;

	[Header("Where this character go")]
	public Transform target;

	[Header("Random moving around")]
	public float wanderRadius;
	public float wanderTimerMin;
	public float wanderTimerMax;

	//to navigate the random moving
	Transform randomNavtarget;
	UnityEngine.AI.NavMeshAgent agent;
	float timer;
	int attitude;


	void Start () {

		//get the navmesh
		agent = GetComponent<NavMeshAgent> ();

		//set a first random timer for random wandering
		timer = Random.Range(wanderTimerMin,wanderTimerMax);
		
	}
	

	void Update () {

		//if we have a target we go to it
		if(target != null){
			GoingTo();
		}

		//when we reach the target we do one of those two things
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


	/// <summary>
	/// Walkings  around at random.
	/// </summary>
	void WalkingAroundRandom(){

		//for duration of timer
			timer -= Time.deltaTime;

		//when timer is over
			if (timer <= 0) {
			//new position to go to
				Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
				agent.SetDestination(newPos);
			//new random timer
				timer = Random.Range(wanderTimerMin,wanderTimerMax);
			}

	}

	/// <summary>
	/// Goings to the main target.
	/// </summary>
	void GoingTo(){

		//check the distance between character and target
		float distance = Vector3.Distance(this.transform.position, target.transform.position);

		//Move the character towards the current target
		agent.SetDestination(target.position);


		//In case the character arrived to the target waypoint (very small distance) and take in account the distance to ground
		if ((distance - this.transform.position.y) <= 0.1f){

			//add the student to the room list
			target.GetComponent<Room>().AddStudent(this);

			//empty the target
			target = null;

			//do one of the two attitude
			//random range min inclusive, max exclusive
			attitude = Random.Range(1,3);
		}

	}


	//found on the internet, determinate the random next position to go to
	/// <summary>
	/// Randoms the nav sphere.
	/// </summary>
	/// <returns>The nav sphere.</returns>
	/// <param name="origin">Origin.</param>
	/// <param name="dist">Dist.</param>
	/// <param name="layermask">Layermask.</param>
	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
		Vector3 randDirection = Random.insideUnitSphere * dist;

		randDirection += origin;

		UnityEngine.AI.NavMeshHit navHit;

		UnityEngine.AI.NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);

		return navHit.position;
	}
		
}
