using UnityEngine;
using System.Collections;

public class DestroyByRescue : MonoBehaviour {
	public GameObject explosion;
	public int scoreValue;
	public int decrementScoreValue;
	private GameController gameController;
	// Use this for initialization
	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null) {
			Debug.Log("Cannot find GameController script in to the console");
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy") {
			return;
		}
		if (other.tag == "Player Shot") {
			Instantiate(explosion,transform.position,transform.rotation);
			gameController.AddScore (decrementScoreValue);
			Destroy (other.gameObject);
		}
		if (other.tag == "Player") {
			gameController.AddScore (scoreValue);
		}
		Destroy (gameObject);
	}
}
