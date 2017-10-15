using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public static int breakableCount=0;
	public Sprite[] hitSprites;
	public AudioClip crack;
	public GameObject smoke;


	private int maxHits;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable; 


	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		maxHits = hitSprites.Length + 1;
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		if (isBreakable) {
			breakableCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (crack,transform.position,0.5f);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void LoadSprites() {
		//int spriteIndex = timesHit - 1;
		//this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		int remain = maxHits - timesHit;
		Color brickColor = new Color ();
		if (remain == 2) {
			ColorUtility.TryParseHtmlString ("#FFED00FF", out brickColor);
			this.GetComponent<SpriteRenderer> ().color = brickColor;
		}
		else if (remain == 1) {
			ColorUtility.TryParseHtmlString ("#FF2E00FF", out brickColor);
			this.GetComponent<SpriteRenderer> ().color = brickColor;
		}
	}
	// TODO Remove this method once we can actually win

	void SimulateWin() {
		levelManager.LoadNextLevel ();

	}

	void HandleHits() {
		timesHit++;
		GameObject smokePuff = (GameObject) Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
		smokePuff.GetComponent<ParticleSystem> ().startColor = gameObject.GetComponent<SpriteRenderer> ().color;
		if (timesHit >= maxHits) {
			Destroy (gameObject);
			breakableCount--;
			levelManager.BrickDestroyed ();
		} else {
			LoadSprites ();
		}
	}
}
