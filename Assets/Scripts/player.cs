using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public AudioSource atk1, atk2, atk3, atk4;
	public AudioSource shd1, shd2, shd3;
	public AudioSource hlt1, hlt2, hlt3;
	public AudioSource aw;

	public TextSoal gp;
	public int damage;
	public int armor;
	public float health;
	public bool kebal;
	public tembakan tb1,tb2,tb3,tb4;
	public int state;
	public bool ply1;
	public float mana;

	public fadeObj fo;
	public fadeObj adh;
	public fadeObj adm1, adm2, adm3;
	public fadeObj adr1,adr2,adr3;

	public GameObject ice;
	public bool cantAttack;

	public UnityEngine.UI.Text di, hi;

	private float cdArm, cdDmg;
//	private bool addArm, addDmg;

	private float hcd, dcd, fcd;
	private int a,d;

	public void healed(int amount){
		a = amount;
		hcd = 1.5f;
	}
	public void damaged(int amount){
		aw.Play ();
		d = amount;
		dcd = 1.5f;
	}

	public void freezeplayer(float duration){
		ice.SetActive (true);
		cantAttack = true;
		fcd = duration;
	}

	public void addh(){
		/*if (state == 3)
			hlt3.Play ();
		else if (state == 2)
			hlt2.Play ();
		else if (state == 1)
			hlt1.Play ();*/
		fadeObj newadh = (fadeObj)Instantiate (adh, new Vector3(Random.Range(transform.position.x-0.3f,transform.position.x+0.3f), transform.position.y+1.4f, transform.position.z), transform.rotation);
		newadh.first = false;
	}
	public void addArmor(){
		float pos;
		if (ply1)
			pos = 0.8f;
		else
			pos = -0.8f;
		if (state == 3) {
			shd3.Play ();
			fadeObj newadr = (fadeObj)Instantiate (adr3, new Vector3 (transform.position.x + pos, transform.position.y, transform.position.z), transform.rotation);
			newadr.first = false;
			if(!ply1) newadr.transform.localScale = new Vector3 (-0.187f, 0.187f, 0.187f);
			armor = 20;
		} else if (state == 2) {
			shd2.Play ();
			armor = 10;
			fadeObj newadr = (fadeObj)Instantiate (adr2, new Vector3 (transform.position.x + pos, transform.position.y, transform.position.z), transform.rotation);
			newadr.first = false;
			if(!ply1) newadr.transform.localScale = new Vector3 (-0.187f, 0.187f, 0.187f);
		} else if (state == 1) {
			shd1.Play ();
			armor = 5;
			fadeObj newadr = (fadeObj)Instantiate (adr1, new Vector3(transform.position.x + pos, transform.position.y, transform.position.z), transform.rotation);
			newadr.first = false;
			if(!ply1) newadr.transform.localScale = new Vector3 (-0.187f, 0.187f, 0.187f);
		}
		if (state != 0) {

			mana = 0;
			cdArm = 7;
		}
	}

	public void addDamage(){
		if (state != 0) {

			mana = 0;
			cdDmg = 8;
		}
		if (state == 3) {
			damage += 12;
			fadeObj newadm = (fadeObj)Instantiate (adm3, new Vector3(transform.position.x, transform.position.y+0.3f, 5), transform.rotation);
			newadm.first = false;

		} else if (state == 2) {
			damage += 8;
			fadeObj newadm = (fadeObj)Instantiate (adm2, new Vector3(transform.position.x, transform.position.y+0.3f, 5), transform.rotation);
			newadm.first = false;

		} else if (state == 1) {
			fadeObj newadm = (fadeObj)Instantiate (adm1, new Vector3(transform.position.x, transform.position.y+0.3f, 5), transform.rotation);
			newadm.first = false;

			damage += 4;
		}
	}

	public void addHealth(){
		if (state != 0) {
			mana = 0;
			fadeObj newfo = (fadeObj)Instantiate (fo, new Vector3(transform.position.x, transform.position.y+1.4f, transform.position.z), transform.rotation);
			newfo.first = false;

		}
		if (state == 3) {
			hlt3.Play ();
			health += 15;
			healed (15);
		} else if (state == 2) {
			hlt2.Play ();
			health += 10;
			healed (10);
		} else if (state == 1) {
			hlt1.Play ();
			health += 5;
			healed (5);
		}
	}

	void OnCollisionEnter2D(Collision2D obj){
		if (obj.gameObject.tag == "tembakan") {
			//Debug.Log ("aw");
			damaged(obj.gameObject.GetComponent<tembakan>().damage-armor);
			health -= (obj.gameObject.GetComponent<tembakan>().damage-armor);
			Destroy (obj.gameObject);
		}
	}

	public void tembak(){
		float pos;
		if (ply1)
			pos = 0.8f;
		else
			pos = -0.8f;
		if (damage == 10) {
			atk1.Play ();
			tembakan newtb = (tembakan)Instantiate (tb1, new Vector3(transform.position.x+pos, transform.position.y, transform.position.z), transform.rotation);
			Physics2D.IgnoreCollision (newtb.GetComponent<Collider2D> (), this.GetComponent<Collider2D> ());
			newtb.first = false;
			newtb.damage = this.damage;
			if (!ply1) {
				newtb.isLeft = true;
				newtb.transform.localScale = new Vector3 (-1, 1, 1);
			}
		}else if (damage == 14) {
			atk2.Play ();
			tembakan newtb = (tembakan)Instantiate (tb2, new Vector3(transform.position.x+pos, transform.position.y, transform.position.z), transform.rotation);
			Physics2D.IgnoreCollision (newtb.GetComponent<Collider2D> (), this.GetComponent<Collider2D> ());
			newtb.first = false;
			newtb.damage = this.damage;
			if (!ply1) {
				newtb.isLeft = true;
				newtb.transform.localScale = new Vector3(-1*tb2.transform.localScale.x,tb2.transform.localScale.y,tb2.transform.localScale.z);
			}
		}else if (damage == 18) {
			atk3.Play ();
			tembakan newtb = (tembakan)Instantiate (tb3, new Vector3(transform.position.x+pos, transform.position.y, transform.position.z), transform.rotation);
			Physics2D.IgnoreCollision (newtb.GetComponent<Collider2D> (), this.GetComponent<Collider2D> ());
			newtb.first = false;
			newtb.damage = this.damage;
			if (!ply1) {
				newtb.isLeft = true;
				newtb.transform.localScale = new Vector3(-1*tb3.transform.localScale.x,tb3.transform.localScale.y,tb3.transform.localScale.z);
			}
		}else if (damage == 22) {
			atk4.Play ();
			tembakan newtb = (tembakan)Instantiate (tb4, new Vector3(transform.position.x+pos, transform.position.y, transform.position.z), transform.rotation);
			Physics2D.IgnoreCollision (newtb.GetComponent<Collider2D> (), this.GetComponent<Collider2D> ());
			newtb.first = false;
			newtb.damage = this.damage;
			if (!ply1) {
				newtb.isLeft = true;
				newtb.transform.localScale = new Vector3(-1*tb4.transform.localScale.x,tb4.transform.localScale.y,tb4.transform.localScale.z);
			}
		}
	}

	void Start () {
		state = 0;
		health = 100;
		hcd = 0;
		dcd = 0;
		fcd = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (fcd > 0) {
			fcd -= Time.deltaTime;
		} else {
			cantAttack = false;
			ice.SetActive (false);
			if (ply1)
				gp.disableSS1 ();
			else
				gp.disableSS2 ();
		}
		if (hcd > 0) {
			hcd -= Time.deltaTime;
			hi.text = "+" + a;
		} else
			hi.text = "";
		if (dcd > 0) {
			dcd -= Time.deltaTime;
			di.text = "-" + d;
		} else
			di.text = "";
		if (cdArm > 0 && gp.Strt ==1)
			cdArm -= Time.deltaTime;
		else
			armor = 0;
		if (cdDmg > 0 && gp.Strt ==1)
			cdDmg -= Time.deltaTime;
		else {
			damage = 10;
		}
		
		if (mana < 100 && gp.Strt ==1 && fcd<=0)
			mana += 3*Time.deltaTime;
		if (mana >= 100 && gp.Strt == 1) {
			state = 3;
			mana = 100;
		}
		else if (mana >= 70)
			state = 2;
		else if (mana >= 40)
			state = 1;
		else
			state = 0;
		
		if (health > 100)
			health = 100;
	}
}
