using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;

public enum RoomType
{

	Classroom = -1,
	Secret = 0,
	HouseRoomGryffindor = 1,
	HouseRoomSlytherin = 2,
	HouseRoomRavenclaw = 3,
	HouseRoomHufflepuff = 4

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
		case RoomType.HouseRoomGryffindor:
			

			break;
		case RoomType.HouseRoomSlytherin:


			break;
		case RoomType.HouseRoomRavenclaw:


			break;
		case RoomType.HouseRoomHufflepuff:


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

		if(room_type == RoomType.Classroom && students_inside.Count < students_inside_max){

			students_inside.Add(_toadd);


		}


		else if (room_type == RoomType.HouseRoomGryffindor){

			if(_toadd.rank_type == Rank.StudentGryffindor){

				students_inside.Add(_toadd);
				
			}else {

				_toadd.transform.GetComponent<Character>().target = Manager.all_rooms [Random.Range (0, Manager.all_rooms.Count)].transform;
				
			}


		}
		else if (room_type == RoomType.HouseRoomSlytherin){

			if(_toadd.rank_type == Rank.StudentSlytherin){

				students_inside.Add(_toadd);

			}else {

				_toadd.transform.GetComponent<Character>().target = Manager.all_rooms [Random.Range (0, Manager.all_rooms.Count)].transform;

			}


		}
		else if (room_type == RoomType.HouseRoomRavenclaw){

			if(_toadd.rank_type == Rank.StudentRavenclaw){

				students_inside.Add(_toadd);

			}else {

				_toadd.transform.GetComponent<Character>().target = Manager.all_rooms [Random.Range (0, Manager.all_rooms.Count)].transform;

			}


		}
		else if (room_type == RoomType.HouseRoomHufflepuff){

			if(_toadd.rank_type == Rank.StudentHufflepuff){

				students_inside.Add(_toadd);

			}else {

				_toadd.transform.GetComponent<Character>().target = Manager.all_rooms [Random.Range (0, Manager.all_rooms.Count)].transform;

			}


		}


	}

}
