//This class is responsible for charging the game levels

using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public GameObject fallingParticle;
	public GameObject fallingBigObject;
	private int ControllFall;
	private int ControllBigFall;
	
	void Update() {
		ControllFall = Random.Range(0, 200);
		ControllBigFall = Random.Range (0, 3000);
		if (fallingParticle) {
			if (ControllFall == 1) {
				FallingObjects();
			}
		}
		if (fallingBigObject) {
			if (ControllBigFall == 1) {
				BigFall();
			}
		}
	}
	
	public void LoadLevel(string name){
		Application.LoadLevel(name);
		Brick.breakableCount = 0;
	}
	
	public void NextLevel() {
		Application.LoadLevel(Application.loadedLevel+1);
		Brick.breakableCount = 0;
	}
	
	public void QuitRequest() {
		Application.Quit();
	}
	
	public void FallingObjects(){
		Vector3 vec = new Vector3(Random.Range(0f, 16.0f), 13f, Random.Range (-20f, 20f));
		fallingParticle = Instantiate(fallingParticle, vec, Quaternion.identity) as GameObject;
	}
	
	public void BigFall() {
		Vector3 vec = new Vector3(Random.Range(5f, 10.0f), 15f, Random.Range (-20f, 20f));
		fallingBigObject = Instantiate(fallingBigObject, vec, Quaternion.identity) as GameObject;	
	}	
	
	public void SpecialBall() {
		Vector3 vec = new Vector3(Random.Range(5f, 10.0f), 15f, 2);
		fallingBigObject = Instantiate(fallingBigObject, vec, Quaternion.identity) as GameObject;	
	}	
}
