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

	// Use this for initialization
	void Start () {
		
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
		if(room_type == RoomType.Classroom && students_inside.Count < students_inside_max){

			//add the student to this room list
			students_inside.Add(_toadd);

		}

		//if it's a house room and the student is from that house
		print("room " + (int)room_type);
		print("stud " + (int)_toadd.rank_type);

		if ((int)room_type == (int)_toadd.rank_type){

			//add the student to this room list
			students_inside.Add(_toadd);

		}else {

			//else give it a new random destination while excluding this room
			Transform new_target = Manager.all_rooms [Random.Range (0, Manager.all_rooms.Count)].transform;
			if(new_target != this.transform){
				_toadd.transform.GetComponent<Character>().target = new_target;
			}else{
				new_target = Manager.all_rooms [Random.Range (0, Manager.all_rooms.Count)].transform;
				} 				
			}

		}
}