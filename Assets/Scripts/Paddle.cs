using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
public bool autoPlay = false;
private float paddleSpeed = 10;
private Ball ball;
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
	}
	// Update is called once per frame
	void Update () {
		if (autoPlay) {			
			automaticPlay();
		} else {
			moveManual();
		}
	}
	
	void automaticPlay () {
		Vector3 paddlePos = new Vector3 (Mathf.Clamp(7.5f, 0.5f, 15.5f), this.transform.position.y, 0f);
		Vector3 ballPosition = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPosition.x, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}
	
	void moveManual () {
		Vector3 vec = new Vector3 (Mathf.Clamp(transform.position.x, 0.5f, 15.5f), this.transform.position.y, 0f);
		if (Input.GetKey(KeyCode.LeftArrow)) {
			vec.x = Mathf.Clamp(vec.x + paddleSpeed * Time.deltaTime * -1, 0.5f, 15.5f);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			vec.x = Mathf.Clamp(vec.x + paddleSpeed * Time.deltaTime, 0.5f, 15.5f);
		}
		this.transform.position = vec;
		
	}
}
