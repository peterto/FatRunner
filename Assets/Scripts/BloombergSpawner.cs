using UnityEngine;
using System.Collections;

public class BloombergSpawner : MonoBehaviour {

	public float spawnTime = 5f;
	public float spawnDelay = 3f;
	public GameObject[] badFoods;

	public Vector3 pos;

	public float CurveSpeed = 5;
	public float MoveSpeed = 5;

	private int randomNum = 0;
	
	float fTime = 0;
	Vector3 vLastPos = Vector3.zero;

	public int direction = 1;

	public Transform childSpawn;

	void circularMovement() {
		//this.transform.position = pos;
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
		InvokeRepeating("generateRandom", spawnDelay, spawnTime);
		vLastPos = transform.position;
	}

	void generateRandom(){
		randomNum = Random.Range(0, 3);
	}

	void OnBecameInvisible(){
		print("I became invisible");
		if (direction == 1)
			direction = 0;
		else if (direction == 0)
			direction = 1;
	}


	// Update is called once per frame
	void Update () {
		vLastPos = transform.position;
		
		fTime += Time.deltaTime * CurveSpeed;

		//Vector3 vSin = new Vector3(Mathf.Sin(fTime), -Mathf.Sin(fTime), 0);
		//Vector3 vLin = new Vector3(MoveSpeed, MoveSpeed, 0);
		Vector3 vSin = new Vector3();

		switch(randomNum) {
		case 0:
			vSin = new Vector3(-Mathf.PingPong(fTime, 2), Mathf.PingPong(fTime, 2), 0);
			break;
		case 1:
			vSin = new Vector3(Mathf.PingPong(fTime, 2), -Mathf.PingPong(fTime, 2), 0);
			break;
		case 2:
			vSin = new Vector3(-Mathf.PingPong(fTime, 2), -Mathf.PingPong(fTime, 2), 0);
			break;
		case 3:
			vSin = new Vector3(Mathf.PingPong(fTime, 2), Mathf.PingPong(fTime, 2), 0);
			break;
		default:
			vSin = new Vector3(Mathf.PingPong(fTime, 2), -Mathf.PingPong(fTime, 2), 0);
			break;
		}
		//Vector3 vSin = new Vector3(Mathf.PingPong(fTime, 2), Mathf.PingPong(fTime, 2), 0);
		Vector3 vLin = new Vector3(MoveSpeed, 0, 0);

		if(direction == 1)
			transform.position += (vSin + vLin) * Time.deltaTime;
		else if(direction == 0)
			transform.position -= (vSin + vLin) * Time.deltaTime;

//		transform.position = new Vector3(Mathf.PingPong(Time.deltaTime, 6) - 3, 0, 0);

		//transform.position += (vSin) * Time.deltaTime;
		Debug.DrawLine(vLastPos, transform.position, Color.green, 100);
	}
	
	void Spawn() {
		int badFoodIndex = Random.Range(0, badFoods.Length);
		Instantiate(badFoods[badFoodIndex], this.transform.position, this.transform.rotation);
	}
}
