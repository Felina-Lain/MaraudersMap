using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	[HideInInspector] public GameObject containerObject;

	public List<Character> all_students_check = new List<Character>();
	public List<Character> all_teachers_check = new List<Character>();
	public List<Character> all_ghosts_check = new List<Character>();
	public List<Room> all_rooms_check = new List<Room>();

	public static List<Character> all_students = new List<Character>();
	public static List<Character> all_teachers = new List<Character>();
	public static List<Character> all_ghosts = new List<Character>();
	public static List<Room> all_rooms = new List<Room>();

	public int student_total;
	public int teachers_total;
	public int ghost_total;

	public GameObject student_prefab;
	public GameObject teacher_prefab;
	public GameObject ghost_prefab;

	// Use this for initialization
	void Start () {

		all_rooms.AddRange(FindObjectsOfType<Room>());

		InitialSpawn (student_prefab, student_total);
		InitialSpawn (teacher_prefab, teachers_total);
		InitialSpawn (ghost_prefab, ghost_total);
		
	}
	
	// Update is called once per frame
	void Update () {


		//Check the state of the list, else is useless
		all_students_check = all_students;
		all_rooms_check = all_rooms;
		all_teachers_check = all_teachers;
		all_ghosts_check = all_ghosts;
	}


	/// <summary>
	/// Spawn the various characters for the map
	/// </summary>
	/// <param name="_prefab">Prefab.</param>
	/// <param name="_total">Total.</param>
	void InitialSpawn(GameObject _prefab, int _total){

		containerObject = new GameObject(_prefab.name + "Pool");

		for (int i = 0; i < _total; i++) {
			GameObject _newGO = GameObject.Instantiate (_prefab);
			_newGO.name = _prefab.name;
			_newGO.transform.parent = containerObject.transform;
			_newGO.transform.position = all_rooms [Random.Range (0, all_rooms.Count)].transform.position;

			if(_prefab.name.Contains("Stu"))
			Manager.all_students.Add (_newGO.GetComponent<Character> ());

			if(_prefab.name.Contains("Tea"))
			Manager.all_teachers.Add (_newGO.GetComponent<Character> ());

			if(_prefab.name.Contains("Gho"))
			Manager.all_ghosts.Add (_newGO.GetComponent<Character> ());
		}

	}
}
