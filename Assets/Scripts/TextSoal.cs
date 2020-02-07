using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Advertisements;
using System.Collections;

public class TextSoal : MonoBehaviour {

	public UnityEngine.UI.Text soal,ket,s1,s2;
	public UnityEngine.UI.Text t1,t2,t3,t4;
	public UnityEngine.UI.Text t12,t22,t32,t42;
	public UnityEngine.UI.Text infoSkill1, infoSkill2;
	public UnityEngine.UI.Image ss1,ss2,bb1,bb2;
	public UnityEngine.UI.Image hbar1, hbar2, mbar1, mbar2, timebar, loadsoalbar;
	public int byk_num = 3;

	public AudioSource ty, wins, tkn;

	public player ply1,ply2;

	private int n1,n2,n3,n4,n5;
	private int p1,p2,p3,p4,p5;
	private int ask, ans, bnr;//, countads, countlim = 3;
	//private int score1, score2;
	public int Strt=0;
	private float timeLeft;

	private System.Random rnd = new System.Random();

	public int healamount;

	private bool p1ready, p2ready;
	public GameObject b1,b2,stbt;
	public GameObject s11, s12, s13, s21, s22, s23;

	int ansPly;
	float loadSoal;
	/*void Awake(){
		if (Advertisement.isSupported) {
			Advertisement.allowPrecache = true;
			Advertisement.Initialize ("1208788", false);
		}
	}*/

	public void keluar(){
		SceneManager.LoadScene ("main");
	}

	public void p1init(){
		p1ready = true;
		if (p2ready)
			init ();
		b1.SetActive (false);
	}
	public void p2init(){
		p2ready = true;
		if (p1ready)
			init ();
		b2.SetActive (false);
	}

	public void preinit(){
		/*countads++;
		if (countads == countlim) {
			countads = 0;
			Advertisement.Show (null, new ShowOptions {
				pause = true,
				resultCallback= result =>{
				}
			});
		}*/
		soal.text = "Tekan Ready\nuntuk Mulai";
		timeLeft = 120f;
		ket.text = "";
		infoSkill1.text = "";
		infoSkill2.text = "";
		p1ready = false;
		p2ready = false;
		ply1.health = 100;
		ply2.health = 100;
		ply1.mana = 0;
		ply2.mana = 0;
		b1.SetActive (true);
		b2.SetActive (true);
		stbt.SetActive (false);
		Strt = 0;
	}
	public void init(){
		ply1.mana = 0;
		ply2.mana = 0;
		ply1.health = 100;
		ply2.health = 100;
		//score1 = 0;
		//score2 = 0;
		init_soal ();
		Strt = 1;
		timeLeft = 120.0f;
	}
		
	public void tekan(int num){
		if (Strt == 1) {
			int ply;
			if (num > 10) {
				ply = 2;
				num -= 10;
			} else
				ply = 1;

			if (ply == 1 && ply1.cantAttack)
				return;
			if (ply == 2 && ply2.cantAttack)
				return;
			if (ansPly == -1)
				return;

			tkn.Play ();
			if (num == bnr) {
				if (ply == 1) {
					//score1++;
					//health2-=10;
					ket.text = "PLAYER 1 BENAR";
					bb1.enabled = true;
					ply1.tembak ();
					ansPly = -1;
				} else if (ply == 2) {
					//score2++;
					//health1-=10;
					ket.text = "PLAYER 2 BENAR";
					bb2.enabled = true;
					ply2.tembak ();
					ansPly = -1;
				}
				pre_init_soal ();
				//init_soal ();
			} else {
				ansPly+=ply;
				if (ply == 1) {
					//score1--;
					//ply2.health+=10;
					//ply2.healed (10);
					//ply2.addh ();
					//ply1.damaged(ply1.damage);
					//ply1.health -= ply1.damage;
					ket.text = "PLAYER 1 SALAH";
					ss1.enabled = true;
					ply1.freezeplayer (5);
					//ty.Play ();
				} else if (ply == 2) {
					//score2--;
					//ply1.health+=10;
					//ply1.healed (10);
					//ply1.addh ();
					//ply2.damaged(ply2.damage);
					//ply2.health -= ply2.damage;
					ket.text = "PLAYER 2 SALAH";
					ss2.enabled = true;
					ply2.freezeplayer (5);
					//ty.Play ();
				}
				if(ansPly == 3)
					pre_init_soal ();
					//init_soal ();
			}
		}
	}

	public void disableSS1(){
		ss1.enabled = false;
	}
	public void disableSS2(){
		ss2.enabled = false;
	}
	private void pre_init_soal()
	{
		loadSoal = 1;
	}
	private void init_soal(){
		ansPly = 0;
		n1 = rnd.Next(1, 50);
		n2 = rnd.Next(1, 50);
		n3 = n1 + n2;
		ask = rnd.Next (1, 4);
		if (ask == 1) ans = n1;
		else if (ask == 2) ans = n2;
		else if (ask == 3) ans = n3;

		p1 = rnd.Next (ans - 10, ans + 11);
		while (p1 < 1 || p1==ans) {
			p1 = rnd.Next (ans - 10, ans + 11);
		}
		p2 = rnd.Next (ans - 10, ans + 11);
		while (p2 < 1 || p2==ans || p2==p1) {
			p2 = rnd.Next (ans - 10, ans + 11);
		}
		p3 = rnd.Next (ans - 10, ans + 11);
		while (p3 < 1 || p3==ans || p3==p1 || p3==p2) {
			p3 = rnd.Next (ans - 10, ans + 11);
		}
		p4 = rnd.Next (ans - 10, ans + 11);
		while (p4 < 1 || p4==ans || p4==p1 || p4==p2 || p4==p3) {
			p4 = rnd.Next (ans - 10, ans + 11);
		}

		bnr = rnd.Next (1, 5);
		if (bnr == 1) p1 = ans;
		else if (bnr == 2) p2 = ans;
		else if (bnr == 3) p3 = ans;
		else if (bnr == 4) p4 = ans;
	}

	//private float barDisplay = 0;
	//private Vector2 pos = new Vector2 (0, 0);
	//private Vector2 size = new Vector2 (100, 20);
	public Texture progressBarEmpty, progressBarFull;
	public Transform mid;
	/*
	void OnGUI(){
		Vector3 poz;
		poz =  Camera.main.WorldToScreenPoint(new Vector3(0,0,0));

		Rect HPBAR = new Rect(poz.x, poz.y, timeLeft/180.0f*100 , 20); 
		Rect HPBAR2 = new Rect (poz.x, poz.y, 100, 20); 

		GUI.DrawTexture (HPBAR2, progressBarEmpty);
		GUI.DrawTexture (HPBAR, progressBarFull);
		/*GUI.BeginGroup (new Rect (pos.x, pos.y, size.y, size.y));
		GUI.Box (new Rect (0, 0, size.x, size.y), progressBarEmpty);
		GUI.EndGroup ();
		GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));
		GUI.Box (new Rect (0, 0, size.x, size.y), progressBarFull);
		GUI.EndGroup ();
	}*/

	void Start () {
		//countads = 0;
		infoSkill1.text = "";
		infoSkill2.text = "";
		timeLeft = 120f;
		s11.SetActive (false);
		s12.SetActive (false);
		s13.SetActive (false);
		s21.SetActive (false);
		s22.SetActive (false);
		s23.SetActive (false);
		soal.text = "Tekan Ready\nuntuk Mulai";
		ket.text = "";
		p1ready = false;
		p2ready = false;
		stbt.SetActive (false);
		loadSoal = -1;
		ss1.enabled = false;
		ss2.enabled = false;
		bb1.enabled = false;
		bb2.enabled = false;
	}

	public UnityEngine.UI.Text timelft;
	private float min, sec;

	void Update () {
		min = Mathf.Floor (timeLeft / 60);
		sec = Mathf.Floor(timeLeft % 60);
		if (min < 10) {
			if(sec<10) timelft.text = "0" + min + ":0" + sec;
			else timelft.text = "0" + min + ":" + sec;
		}else{
			if(sec<10) timelft.text = "" + min + ":0" + sec;
			else timelft.text = "" + min + ":" + sec;
		}

		if (loadSoal <= 0 && loadSoal != -1) {
			loadSoal = -1;
			init_soal ();
			loadsoalbar.fillAmount = 0;
			//ss1.enabled = false;
			//ss2.enabled = false;
			bb1.enabled = false;
			bb2.enabled = false;

		} else if (loadSoal > 0) {
			loadSoal -= Time.deltaTime;
			loadsoalbar.fillAmount = loadSoal / 0.5f;
		} else {
			loadsoalbar.fillAmount = 0;
		}
		
		hbar1.fillAmount = ply1.health / 100;
		hbar2.fillAmount = ply2.health / 100;
		mbar1.fillAmount = ply1.mana / 100;
		mbar2.fillAmount = ply2.mana / 100;
		timebar.fillAmount = timeLeft / 120f;
		//stimelft.text = "Time Left: " + timeLeft + " seconds";
		//barDisplay = timeLeft/180.0f;
		if (p1ready && p2ready)
			stbt.SetActive (true);
		
		if (ply1.state == 0) {
			s11.SetActive (false);
			s12.SetActive (false);
			s13.SetActive (false);
			infoSkill1.text = "";
		}
		else {
			s11.SetActive (true);
			s12.SetActive (true);
			s13.SetActive (true);
			if (ply1.state == 1)
				infoSkill1.text = "READY";
			else if (ply1.state == 2)
				infoSkill1.text = "VERY READY!";
			else if (ply1.state == 3)
				infoSkill1.text = "SUPER READY!!";
		}
		
		if (ply2.state == 0) {
			s21.SetActive (false);
			s22.SetActive (false);
			s23.SetActive (false);
			infoSkill2.text = "";
		} else {
			s21.SetActive (true);
			s22.SetActive (true);
			s23.SetActive (true);
			if (ply2.state == 1)
				infoSkill2.text = "READY";
			else if (ply2.state == 2)
				infoSkill2.text = "VERY READY!";
			else if (ply2.state == 3)
				infoSkill2.text = "SUPER READY!!";
		}
		/*if (health1 > 100)
			health1 = 100;
		if (health2 > 100)
			health2 = 100;*/
		if (Strt == 1) {
			if (ply1.health <= 0) {
				Strt = 0;
				soal.text = "Player 2 WIN!";
			} else if (ply2.health <= 0) {
				Strt = 0;
				soal.text = "Player 1 WIN!";
			}
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0) {
				timeLeft = 0;

				//Debug.Log ("sadw");
				ket.text = "Waktu Habis!";
				wins.Play();
				if (ply1.health < ply2.health) {
					//Debug.Log ("hello");
					soal.text = "Player 2 WIN!";
				} else if (ply2.health < ply1.health) {
					//Debug.Log ("hello2");
					soal.text = "Player 1 WIN!";
				} else {
					soal.text = "Imbang!";
				}
				Strt = 0;
			}
		}
		if (Strt == 0) {
			
		}
		else if (ask == 1)
			soal.text = "? + " + n2 + " = " + n3;
		else if (ask == 2)
			soal.text = n1 + " + ? = " + n3;
		else if (ask == 3)
			soal.text = n1 + " + " + n2 + " = ?";
		t1.text = "" + p1;
		t2.text = "" + p2;
		t3.text = "" + p3;
		t4.text = "" + p4;
		t12.text = "" + p1;
		t22.text = "" + p2;
		t32.text = "" + p3;
		t42.text = "" + p4;
		s1.text = "PLAYER 1 HEALTH:\n" + ply1.health + "/100\n";
		s2.text = "PLAYER 2 HEALTH:\n" + ply2.health + "/100\n";
	}


}
