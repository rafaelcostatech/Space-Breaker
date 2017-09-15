using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer music = null;
	
	void Awake (){
		if (music != null) {
			Destroy(gameObject);
		} else {
			music = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}		
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
