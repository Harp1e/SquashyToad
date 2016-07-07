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
	private LevelState state;

	// Use this for initialization
	void Start () {
	Cardboard.SDK.OnTrigger += PullTrigger;
	head = GameObject.FindObjectOfType<CardboardHead>();
	rb = GetComponent<Rigidbody>();
	state = GameObject.FindObjectOfType<LevelState>();
	}

	void PullTrigger () {
		RequestJump();
	}

	void RequestJump(){
		lastJumpRequestTime = Time.time;
		rb.WakeUp();
	}

	void Jump(){
		if (!state.IsGameOver) {
			float jumpAngleInRadians = jumpAngleInDegrees * Mathf.Deg2Rad;
			Vector3 jumpVector = Vector3.RotateTowards(LookDirection(), Vector3.up, jumpAngleInRadians, 0);
			rb.velocity = jumpVector * jumpSpeed;
		}
	}

	public Vector3 LookDirection () {
		return Vector3.ProjectOnPlane(head.Gaze.direction, Vector3.up);
	}

	void OnCollisionStay(Collision collision){
		float delta = Time.time - lastJumpRequestTime;
		if (delta < 0.1f){
			Jump();
			lastJumpRequestTime = 0;
		}
	}
}
