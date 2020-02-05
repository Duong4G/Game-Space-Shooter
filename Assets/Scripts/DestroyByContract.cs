using UnityEngine;
using System.Collections;

public class DestroyByContract : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public GameObject[] prisoners;
	public int scoreValue;
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
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Friend") {
			return;
		}
		if(explosion!=null){
			Instantiate (explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		gameController.AddScore (scoreValue);
		if (prisoners.Length>0) {
			if(Random.Range(0,2)==1){
				GameObject prisoner = prisoners[Random.Range(0,prisoners.Length)];
				Instantiate(prisoner,transform.position, transform.rotation);
			}
		}
		Destroy(other.gameObject);
		Destroy (gameObject);
	}
}
