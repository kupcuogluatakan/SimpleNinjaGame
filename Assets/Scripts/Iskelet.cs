using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Iskelet : MonoBehaviour {


	[SerializeField]
	protected Transform bicakKonum;

	[SerializeField]
	protected float hiz;

	protected bool sagaBak;

	[SerializeField]
	private GameObject bicakPrefab;

	[SerializeField]
	protected int enerji;

	[SerializeField]
	private EdgeCollider2D kilicCollider;

	[SerializeField]
	private List<string> darbeKaynaklari;

	public abstract bool Oldumu { get; }

	public bool Atak {get; set;}

	public bool Darbede {get; set;}

	public Animator MyAnimator { get; private set;}

	public EdgeCollider2D KilicCollider
	{
		get 
		{
			return kilicCollider;
		}
	}

	public virtual void Start () {
		
		sagaBak = true;
		MyAnimator = GetComponent<Animator> ();

	}

	void Update () {
	
	}
	public abstract IEnumerator Darbe();

	public void YonDegistir()
	{
		sagaBak = !sagaBak;
		transform.localScale = new Vector3 (transform.localScale.x * -1,1,1);
	}

	public virtual void BicakFirlat(int value)
	{		
			if (sagaBak)
		{
				GameObject klonBicak = (GameObject)Instantiate (bicakPrefab, bicakKonum.position, Quaternion.Euler (new Vector3 (0, 0, -90)));
				klonBicak.GetComponent<Bicak> ().Initialize (Vector2.right);
			} else {
				GameObject klonBicak = (GameObject)Instantiate (bicakPrefab, bicakKonum.position, Quaternion.Euler (new Vector3 (0, 0, 90)));
				klonBicak.GetComponent<Bicak> ().Initialize (Vector2.left);
			}
	}

	public void KavgaAtak()
	{
		kilicCollider.enabled = true;
	}


	public virtual void OnTriggerEnter2D(Collider2D other)
	{
		if(darbeKaynaklari.Contains(other.tag))
		{
			StartCoroutine (Darbe());
		}
	}


}
