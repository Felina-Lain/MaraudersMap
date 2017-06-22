using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;

public enum RoomType
{

	Classroom = -1,
	HouseRoom = 0,
	Secret = 1

}


public class Room : MonoBehaviour {

	public RoomType room_type;

	[SerializeField]
	List<Character> students_inside = new List<Character>();

	[Header("Class and Lessons")]
	public float class_time_max;
	public float in_between_time_max;
	public float students_inside_max;
	[SerializeField]
	bool teacher_inside;

	[Header("Countdown check")]
	[SerializeField]
	float class_time;
	[SerializeField]
	float in_between_time;

	// Use this for initialization
	void Start () {
		in_between_time = in_between_time_max;
	}
	
	// Update is called once per frame
	void Update () {

		//if this is a classroom
		if (room_type == RoomType.Classroom) {



		} 
		
	}


	void ClassInSession(){

		class_time -= Time.deltaTime;

		
	}

	void ClassOver(){

		in_between_time -= Time.deltaTime;

		//give each students in the classroom a new destination
		for (int i = 0; i < students_inside.Count; i++) {

			students_inside [i].target = Manager.all_rooms [Random.Range (0, Manager.all_rooms.Count)].transform;

		}

	}
}
