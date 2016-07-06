using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {

	private float speed;
	private float roadLength;
	private float lifeTime;

	// Use this for initialization
	void Start () {
		lifeTime = roadLength / speed;
		Invoke("Remove", lifeTime);
	}

	void Remove(){
		Destroy(gameObject);
	}

	public void SetPath(float someSpeed, float someRoadLength){
		speed = someSpeed;
		roadLength = someRoadLength;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * speed * Time.deltaTime;
	}
}
