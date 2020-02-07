using UnityEngine;
using System.Collections;

public class fadeObj : MonoBehaviour {

	public float delay;
	public float duration;
	public bool first;

	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;

		//Debug.Log ("3");
	}

	// Update is called once per frame
	void Update () {
		if (!first) {
			if (delay > 0) {
				delay -= Time.deltaTime;
				startTime = Time.time;
			}
			float t = (Time.time - startTime) / duration;
			GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, Mathf.SmoothStep (1, 0, t));
			if (t > 1)
				Destroy (this.gameObject);
		}
	}
}
