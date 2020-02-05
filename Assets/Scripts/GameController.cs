using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject[] hazards;
	public Vector3 spawnValue;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText gameOverText;
	public GUIText restartText;
	public GUIText levelText;
	
	private bool gameOver;
	private bool restart;
	private int score;
	private int tempScore;
	private int level;
	void Start(){
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		score = 0;
		level = 1;
		tempScore = 0;
		UpdateLevel ();
		UpdateScore ();
		StartCoroutine (SpawnWaves());
	}
	void Update(){
		if (restart) {
			if(Input.GetKeyDown(KeyCode.R))
				Application.LoadLevel(Application.loadedLevel);
		}
	}
	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds(startWait);
		while (true) {
			for (int i=0; i<hazardCount; i++) {
				GameObject hazard = hazards[Random.Range(0,hazards.Length)];
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x,spawnValue.x),spawnValue.y,spawnValue.z) ;
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
			if(gameOver){
				restartText.text = "Press 'R' to restart";
				restart = true;
			}
		}
		
	}
	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}
	void UpdateLevel(){
		levelText.text = "Level: " + level;
	}
	public void AddScore(int newScoreValue){
		score += newScoreValue;
		if (score >= 50 && tempScore == 0) {
			hazardCount++;
			tempScore = 1;
			level++;
		}
		if (score >= 100 && tempScore == 1) {
			hazardCount++;
			tempScore = 2;
			level++;
		}
		if (score >= 300 && tempScore == 2) {
			hazardCount++;
			tempScore = 3;
			level++;
		}
		if (score >= 500 && tempScore == 3) {
			hazardCount++;
			tempScore = 4;
			level++;
		}
		if (score >= 800 && tempScore == 4) {
			hazardCount++;
			tempScore = 5;
			level++;
		}
		if (score >= 1000 && tempScore == 5) {
			hazardCount+=2;
			tempScore = 6;
			level++;
		}
		if (score >= 2000 && tempScore == 6) {
			hazardCount+=2;
			tempScore = 7;
			level++;
		}
		if (score >= 3000 && tempScore == 7) {
			hazardCount+=3;
			tempScore = 8;
			level++;
		}
		if (score >= 4000 && tempScore == 8) {
			hazardCount+=3;
			tempScore = 9;
			level++;
		}
		if (score >= 5000 && tempScore == 9) {
			hazardCount+=4;
			tempScore = 10;
			level++;
		}
		UpdateLevel ();
		UpdateScore ();
	}
	public void GameOver(){
		gameOverText.text = "Game Over";
		gameOver = true;
	}

	public int GetScore(){
		return score;
	}
	
}
