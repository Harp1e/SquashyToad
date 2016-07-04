using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float jumpAngleInDegrees;
	public float jumpSpeed = 10.0f;

	private CardboardHead head;
	private Rigidbody rb;
	private bool onFloor;
	private float lastJumpRequestTime = 0;

	// Use this for initialization
	void Start () {
	Cardboard.SDK.OnTrigger += PullTrigger;
	head = GameObject.FindObjectOfType<CardboardHead>();
	rb = GetComponent<Rigidbody>();
	}

	void PullTrigger () {
		RequestJump();
	}

	void RequestJump(){
		lastJumpRequestTime = Time.time;
		rb.WakeUp();
	}

	void Jump(){
		float jumpAngleInRadians = jumpAngleInDegrees * Mathf.Deg2Rad;
		Vector3 projectedVector = Vector3.ProjectOnPlane(head.Gaze.direction, Vector3.up);
		Vector3 jumpVector = Vector3.RotateTowards(projectedVector, Vector3.up, jumpAngleInRadians, 0);
		rb.velocity = jumpVector * jumpSpeed;
	}

	void OnCollisionStay(Collision collision){
		float delta = Time.time - lastJumpRequestTime;
		if (delta < 0.1f){
			Jump();
			lastJumpRequestTime = 0;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
