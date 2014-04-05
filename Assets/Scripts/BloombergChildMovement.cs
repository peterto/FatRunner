using UnityEngine;
using System.Collections;

public class BloombergChildMovement : MonoBehaviour {

	public int speed = 3;
	private Transform groundCheck;
	private bool grounded = false;

	private bool isMoving = false;

	private GameObject player;
	
	void Awake() {
		groundCheck = transform.Find("groundCheck_enemy");
	}

	// Use this for initialization
	void Start () {
	
	}

	void OnBecameInvisible() {
		Destroy(transform.parent.gameObject);
	}
	
	void moveFood() {
		this.rigidbody2D.AddForce(-Vector2.right * speed);
	}

	// Update is called once per frame
	void Update () {

		//groundCheck = transform.Find("groundCheck_enemy");
		//grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("ground"));

//		if(grounded) {
//			moveFood();
//		}
		if(this.isMoving)
			moveFood();
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			player = GameObject.FindWithTag("Player");
			player.rigidbody2D.velocity = Vector2.zero;
			print("An enemy hit you.");
			player.SendMessage("ApplyPoints", 20);
			Destroy(this.gameObject);
		}

		if(col.gameObject.tag == "ground"){
			this.isMoving = true;
			print("Star hit the ground.");
			this.rigidbody2D.gravityScale = 0;
		}

	}
}
