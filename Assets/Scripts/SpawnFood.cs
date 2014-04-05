using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {

	public float spawnTime = 5f;
	public float spawnDelay = 3f;
    public GameObject[] badFoods;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Spawn() {
		int badFoodIndex = Random.Range(0, badFoods.Length);
		Instantiate(badFoods[badFoodIndex], transform.position, transform.rotation);
	}
}
