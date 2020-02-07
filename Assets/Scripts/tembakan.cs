using UnityEngine;
using System.Collections;

public class tembakan : MonoBehaviour {

	public bool first;
	public float speed;
	public int damage;

	//public float timetodestroy;

	public bool isLeft;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (timetodestroy > 0)
		//	timetodestroy -= Time.deltaTime;
		if (!first) {
			if (isLeft) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, 0);
			} else {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, 0);
			}
		}


	}
}
