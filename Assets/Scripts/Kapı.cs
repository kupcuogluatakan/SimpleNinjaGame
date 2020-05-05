using UnityEngine;
using System.Collections;

public class Kapı : MonoBehaviour {

	[SerializeField]
	private GameObject anahtarVar;
	[SerializeField]
	private GameObject kapiAcik;

	[SerializeField]
	private GameObject kapiKapali;

	[SerializeField]
	private AudioSource kapiKilitliSes;
	[SerializeField]
	private AudioSource kapiAcikSes;


	void OnTriggerEnter2D(Collider2D other) 
	{ 

		if (other.gameObject.tag == "Player" && anahtarVar.activeSelf ) {
			this.gameObject.SetActive (false);
			kapiAcik.SetActive (true);
			kapiAcikSes.Play ();
			Application.LoadLevel ("ikinciOyun");

			
		} else if (other.gameObject.tag == "Player" ) {

				kapiKilitliSes.Play ();
		}

		}
	}

	

