using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	//An array of sprites (images to load inside a prefab, Brick in this case), that will be shown on the prefab to be filled by the designer
	public static int breakableCount;
	public Sprite[] hitSprites;
	public AudioClip Crack;
	public GameObject Smoke;
	public AudioClip Puff;
		
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;
	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (isBreakable) {
			//This following method puts an AudioSource on the place where the brick is. If destroyed, it sounds anyway!
			AudioSource.PlayClipAtPoint(Crack, transform.position);
			HanddleHits();
		}
	}
	
	void HanddleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			GameObject smokePuff = Instantiate(Smoke, this.transform.position, Quaternion.identity) as GameObject;
			smokePuff.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
			smokePuff.GetComponent<ParticleSystem>().Play();
			AudioSource.PlayClipAtPoint(Puff, transform.position);
			Destroy(gameObject);
			breakableCount--;
				if (breakableCount <= 0) {
					levelManager.NextLevel();
				}
		} else {
			LoadSprites();
		}
	}

	//Method that renders the sprite inside the prefab, in this case Bricks. 
	void LoadSprites(){
		//To find out the number of the Sprite to be loaded, so we define the sprite index to load.
		//When a brick have 2 hits of limit, it means it'll be loaded with a default sprite, and then for 
		//each hit, it starts from the sprite 0. In this case is the first sprite defined by the designer.  
		//In this case, the designer have to define wich sprite to load in order.
		int spriteIndex = timesHit - 1;
		
		//So, if the designer forgets to define a sprite, we evaluate as following:
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}

	}
	// Update is called once per frame
	void Update () {
		
	}
}
