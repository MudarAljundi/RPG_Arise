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
	private void Start () {
		myNevMeshAgent = GetComponent<NavMeshAgent>();

		destination = points[0].position;
		
		myNevMeshAgent.SetDestination(destination);
	}

	private void Update () {
		print(currentPatrolIndex + " dist " + Vector3.Distance(transform.position, destination));
		if (Vector3.Distance(transform.position, destination) < 1f) {

			currentPatrolIndex += 1;
			if (currentPatrolIndex == points.Length) {
				currentPatrolIndex = 0;
			}

			destination = points[currentPatrolIndex].position;
			myNevMeshAgent.SetDestination(destination);
		}
	}
}
