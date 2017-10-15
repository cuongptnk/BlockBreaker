using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	//public static int count = 0;
	static MusicPlayer instance = null;
	// Use this for initialization

	void Awake() {
		Debug.Log ("Music player Awake " + GetInstanceID());
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}


	void Start () {
//		if (count == 0) {
//			count++;
//			GameObject.DontDestroyOnLoad (gameObject);
//		} else {
//			GameObject.Destroy (gameObject);
//		}

		Debug.Log ("Music player Start " + GetInstanceID());


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
