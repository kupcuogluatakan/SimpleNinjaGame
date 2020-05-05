using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private Rigidbody2D myRigidbody;
	private Animator myAnimator;

	private int skor;
	public Text toplamSkor;

	[SerializeField]
	private GameObject anahtarVar;

	[SerializeField]
	private float hiz;
	private bool sagaBak;

	[SerializeField]
	private AudioSource altinSes;
	[SerializeField]
	private AudioSource anahtarSes;

	private bool atak;
	private bool kayma;

	[SerializeField]
	private Transform[] temasNoktasi;
	[SerializeField]
	private float temasCapi;
	[SerializeField]
	private LayerMask hangiZemin;

	private bool zeminde;
	private bool zipla;
	[SerializeField]
	private bool havadaKontrol;
	[SerializeField]
	private float ziplamaKuvveti;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();
		sagaBak = true;
		skor = 0;
	}

	// Update is called once per frame
	void FixedUpdate () { //yapılan işlemler buraya yazılmalı.belirli zaman aralığında çalışıyor
		float yatay = Input.GetAxis ("Horizontal");
		TemelHareketler (yatay);
		YonCevir (yatay);//bir true
		AtakHareketleri();//bir false
		//Debug.Log ("Yatay:" + yatay);
		DegerleriResetle();
	}

	private void Update()//bir olay meydana geldiğinde
	{
		Kontroller();
	}

	private void TemelHareketler(float yatay)
	{
		if (!myAnimator.GetBool("kayma") && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("atak")) ;
		myRigidbody.velocity = new Vector2 (yatay*hiz, myRigidbody.velocity.y);
		myAnimator.SetFloat("karakterHizi",Mathf.Abs(yatay));

		if (kayma && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("slide"))//slide aktif degilse kayma aktifse kayma olur
			myAnimator.SetBool("kayma", true);
		
		else if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("slide"))
			myAnimator.SetBool("kayma", false);



	}

	private void YonCevir(float yatay)
	{
		if(yatay>0 && !sagaBak || yatay<0 && sagaBak)
		{
			sagaBak = !sagaBak;
			transform.localScale = new Vector3 (transform.localScale.x * -1, 1, 1);

		}
	}
	void OnCollisionEnter2D(Collision2D otherObject)//çarpışma anında
	{
		if (otherObject.gameObject.tag == "altin") //altın ile çarpışma tag altın mı
		{
			otherObject.gameObject.SetActive (false);
			skor = skor + 100;
			SkorAyarla (skor);
			altinSes.Play();
		}
		if (otherObject.gameObject.tag == "anahtar")
		{
			otherObject.gameObject.SetActive(false);
			anahtarVar.SetActive(true);
			anahtarSes.Play();
		}
	}

	void SkorAyarla(int skorum)
	{
		toplamSkor.text = "Skor : "+skorum.ToString();
	}

	private void AtakHareketleri()
	{
		if (atak)
			myAnimator.SetTrigger("atak");

	}
	private void Kontroller()
	{
		if (Input.GetKeyDown(KeyCode.T))
			atak = true;
		
	}
	private void DegerleriResetle()//default degerler
	{
		atak = false;
		kayma = false;
	}
	private bool Zeminde()
	{
		if(myRigidbody.velocity.y<=0)
		{
			foreach (Transform nokta in temasNoktasi)
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll(nokta.position, temasCapi, hangiZemin);
				for (int i = 0; i < colliders.Length; i++)
				{ 
					if (colliders[i].gameObject != gameObject)
						return true;
				}
			}
		}
		return false;
	}
}