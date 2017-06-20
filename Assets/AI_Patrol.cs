using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Patrol : MonoBehaviour {

	public Transform[] points;

	private Vector3 destination;

	private int currentPatrolIndex = 0;
	private NavMeshAgent myNevMeshAgent;

	// Use this for initialization
	void Start () {
		myNevMeshAgent = GetComponent<NavMeshAgent>();

		destination = points[0].position;

		myNevMeshAgent.SetDestination(destination);
	}
	
	void Update () {
		if (Vector3.Distance(transform.position, destination) < 0.5f) {

		}
	}
}
