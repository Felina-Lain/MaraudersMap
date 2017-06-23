using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Manager : MonoBehaviour {

	//visible lists for checking it works
	public List<Character> all_students_check = new List<Character>();
	public List<Character> all_teachers_check = new List<Character>();
	public List<Character> all_ghosts_check = new List<Character>();
	public List<Room> all_rooms_check = new List<Room>();

	//real static lists
	public static List<Character> all_students = new List<Character>();
	public static List<Character> all_teachers = new List<Character>();
	public static List<Character> all_ghosts = new List<Character>();
	public static List<Room> all_rooms = new List<Room>();

	//total numbers of characters
	public int student_total;
	public int teachers_total;
	public int ghost_total;

	//prefabs for spawning
	public GameObject student_prefab;
	public GameObject teacher_prefab;
	public GameObject ghost_prefab;


	void Start () {

		//Put all the rooms in the list
		all_rooms.AddRange(FindObjectsOfType<Room>());

		//create all the characters
		InitialSpawn (student_prefab, student_total);
		InitialSpawn (teacher_prefab, teachers_total);
		InitialSpawn (ghost_prefab, ghost_total);
		
	}
	

	void Update () {


		//update the check the state of the list, else is useless
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

		//create a parent to contain all the spawned items
		GameObject containerObject = new GameObject(_prefab.name + "Pool");

		//use the given total numbers to spawn the appropriate amount of each characters
		for (int i = 0; i < _total; i++) {
			//spawn a character, give it a name, place it in the parent item, change it's position and activate its navmesh
			GameObject _newGO = GameObject.Instantiate (_prefab);
			_newGO.name = _prefab.name;
			_newGO.transform.parent = containerObject.transform;
			_newGO.transform.position = all_rooms [Random.Range (0, all_rooms.Count)].transform.position;
			_newGO.GetComponent<NavMeshAgent>().enabled = true;

			//add the created character in the appropriate list depending on the name
			if(_prefab.name.Contains("Stu")){
			_newGO.GetComponent<Character>().rank_type = (Rank)Random.Range(1,5);
			Manager.all_students.Add (_newGO.GetComponent<Character> ());
			}

			else if(_prefab.name.Contains("Tea")){
				Manager.all_teachers.Add (_newGO.GetComponent<Character> ());
			}

			else if(_prefab.name.Contains("Gho")){
				Manager.all_ghosts.Add (_newGO.GetComponent<Character> ());
			}
		}

	}
}
