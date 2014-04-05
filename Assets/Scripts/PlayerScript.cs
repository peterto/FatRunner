using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public int speed;
    public int score = 0;
    public GameObject food;

	private Transform groundCheck;
	private bool grounded = false;

	// Use this for initialization
	void Start () {
	}

	void Awake() {
		groundCheck = transform.Find("groundCheck");
	}

    void ApplyForce() {
        this.rigidbody2D.AddForce(Vector2.up * speed);
    }

    void Jump() {
        this.rigidbody2D.AddForce(Vector2.up * speed);
    }

    void Duck() {
        //Change animation to dunk animation
        //Change the sprite
        print("You ducked");
    }

	void ApplyPoints(int points){
		score += 20;
		print("Your score is " + score);
	}


	// Update is called once per frame
	void Update () {

		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("ground"));

        if (grounded && Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            print("You pressed A");
            Duck();

        }
	}

	void OnGUI() {
//		GUI.Box (new Rect (0,0,100,50), "Top-left");
//		GUI.Box (new Rect(Screen.width/2,Screen.height/2,100,25), this.score.ToString());
		GUI.Box (new Rect(0, 0, 100, 25), this.score.ToString());
	}
}
