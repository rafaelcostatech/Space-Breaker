using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector2 tweak = new Vector2();
	public Sprite[] ballSprite;
	private Vector3 paddleToBallVector;	
	int ballNumber = 0;
	
	void Awake(){
		
		

	}
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().sprite = ballSprite[ballNumber];
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		tweak.x = Random.Range(0.1f, 0.3f);
		tweak.y = Random.Range(0.0f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetKeyDown(KeyCode.Space)) {
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f,10f);
			}
		}			
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		tweak.y = Random.Range(0.0f, 0.3f);
		if (hasStarted) {
			if (Input.GetKey(KeyCode.LeftArrow)) {
				tweak.x -= 0.2f;
			} else if (Input.GetKey(KeyCode.RightArrow)) {
				tweak.x += 0.2f;
			}
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}			
	}
}
