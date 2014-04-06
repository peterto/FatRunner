using UnityEngine;
using System.Collections;

public class BackgroundMove : MonoBehaviour {

	public int speed = 3;
	void moveBackground () {
		//this.rigidbody2D.AddForce(-Vector2.right * speed);
		this.transform.position -= new Vector3(0.01f, 0, 0);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moveBackground();
	}
}
