using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour {
	private bool onhelp = false; 
	public GameObject helpobj;
	public void help(){
		onhelp = !onhelp;
	}
	public void play(){
		SceneManager.LoadScene ("gameplay");
	}
	public void exit(){
		Application.Quit ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (onhelp)
			helpobj.SetActive (true);
		else
			helpobj.SetActive (false);
	}
}
