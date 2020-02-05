using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public Transform shotSpawn1;
	public Transform shotSpawn2;
	public Transform shotSpawn3;
	public Transform shotSpawn4;
	public Transform shotSpawn5;
	public float fireRate;
	private float nextFire = 0.0f;
	private int upgrade = 0;

	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null) {
			Debug.Log("Cannot find GameController script in to the console");
		}
	}
	//Update is called once per frame
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody> ().velocity = movement * speed;
		GetComponent<Rigidbody> ().position = new Vector3 
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax) ,
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
				);
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
	void Update(){
		if (gameController.GetScore () >= 500 && upgrade == 0) {
			upgrade = 1;
		}
		if (gameController.GetScore () >= 2000 && upgrade == 1) {
			upgrade = 2;
		}
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			if(upgrade==0){
				nextFire = Time.time + fireRate;
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				GetComponent<AudioSource>().Play();
			}

			if(upgrade == 1){
				nextFire = Time.time + fireRate;
				Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
				Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
				GetComponent<AudioSource>().Play();
			}

			if(upgrade==2){
				nextFire = Time.time + fireRate;
				Instantiate(shot, shotSpawn3.position, shotSpawn3.rotation);
				Instantiate(shot, shotSpawn4.position, shotSpawn4.rotation);
				Instantiate(shot, shotSpawn5.position, shotSpawn5.rotation);
				GetComponent<AudioSource>().Play();
			}
		}
	}
}
