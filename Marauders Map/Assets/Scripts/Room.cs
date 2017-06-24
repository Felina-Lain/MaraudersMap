using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;

public enum RoomType
{

	Classroom = -1,
	Secret = 0,
	Gryffindor = 1,
	Slytherin = 2,
	Ravenclaw = 3,
	Hufflepuff = 4

}


public class Room : MonoBehaviour {

	public RoomType room_type;

	public List<Character> students_inside = new List<Character>();

	[Header("Class and Lessons")]
	public float class_time_max;
	public float non_class_time_max;
	public float students_inside_max;
	[SerializeField]
	bool class_in_session;

	[Header("Countdown check")]
	[SerializeField]
	float class_time;
	[SerializeField]
	float non_class_time;

	//create a temporary list to store all rooms except this one
	List<Room> tmp_list = Manager.all_rooms;

	// Use this for initialization
	void Start () {

		//remove this room from list
		tmp_list.Remove (this);
		
	}
	
	// Update is called once per frame
	void Update () {

		switch(room_type){

		case RoomType.Classroom: 
			

			break;
		case RoomType.Gryffindor:
			

			break;
		case RoomType.Slytherin:


			break;
		case RoomType.Ravenclaw:


			break;
		case RoomType.Hufflepuff:


			break;
		case RoomType.Secret:
			

			break;
		
		default:
			break;
		}


		
	}


	void EventOver(){


		//give each students in the classroom a new destination
		for (int i = 0; i < students_inside.Count; i++) {

			//new target
			students_inside [i].transform.GetComponent<Character>().target = Manager.all_rooms [Random.Range (0, Manager.all_rooms.Count)].transform;

		}

		students_inside.Clear();

	}

	public void AddStudent(Character _toadd){

		//if it's a classroom and the max number of students isn't reached
		if (room_type == RoomType.Classroom && students_inside.Count <= students_inside_max) {

			//add the student to this room list
			students_inside.Add (_toadd);
			//remove the student target
			_toadd.transform.GetComponent<Character> ().target = null;
			//do one of the two attitude for the student
			//random range min inclusive, max exclusive
			_toadd.transform.GetComponent<Character> ().attitude = Random.Range (1, 3);

		}

		//if it's a house room and the student is from that house
		if (room_type != RoomType.Classroom || room_type != RoomType.Secret) {
			if ((int)room_type == (int)_toadd.rank_type) {

				print ("entered the room");
				//add the student to this room list
				students_inside.Add (_toadd);

			} else {

				//else give it a new random destination while excluding this room
				//cancel the current attitude
				_toadd.transform.GetComponent<Character> ().attitude = 0;
				//change the target
				_toadd.transform.GetComponent<Character> ().target = tmp_list [Random.Range (0, tmp_list.Count)].transform;

				print ("leaving to " + _toadd.transform.GetComponent<Character> ().target);
										
			}

		}
	}
}