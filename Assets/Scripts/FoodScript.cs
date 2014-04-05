using UnityEngine;
using System.Collections;

public class FoodScript : MonoBehaviour {

    public int speed = 3;

	private GameObject player;

	// Use this for initialization
	void Start () {
        speed = 3;	
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			player = GameObject.FindWithTag("Player");
			player.rigidbody2D.velocity = Vector2.zero;
			print("An enemy hit you.");
			player.SendMessage("ApplyPoints", 20);
			Destroy(this.gameObject);
		}
	}

	void OnBecameInvisible() {
		Destroy(transform.parent.gameObject);
	}

    void moveFood() {
        this.rigidbody2D.AddForce(-Vector2.right * speed);
    }
	
	// Update is called once per frame
	void Update () {
//		if(!this.renderer.isVisible) {
//			Destroy(this.gameObject);
//		}
        moveFood();
	}
}
