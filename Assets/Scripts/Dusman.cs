using UnityEngine;
using System.Collections;
using System;

public class Dusman : Iskelet 
{

	private DusmanDurum mevcutDurum;

	public GameObject Hedef { get; set; }

	[SerializeField]
	private float kavgaAlani;

	[SerializeField]
	private float firlatmaAlani;

	public bool KavgaAlaninda
	{
		get 
		{
			if (Hedef != null)
			{
				return Vector2.Distance (transform.position, Hedef.transform.position) <= kavgaAlani;
			}
			return false;
		}
	}

	public bool FirlatmaAlaninda
	{
		get 
		{
			if (Hedef != null)
			{
				return Vector2.Distance (transform.position, Hedef.transform.position) <= firlatmaAlani;
			}
			return false;
		}
	}

	public override bool Oldumu { 
		get 
		{
			return enerji <= 0;
		}
	
	}

	public override void Start () 
	{
		base.Start ();
		DurumDegistir (new DusunmeDurum ());
	}
		

	void Update ()
	{
		if (!Oldumu) {
			if (!Darbede) 
			{
				mevcutDurum.Execute ();
			}
			HedefeBak ();
		}
	}

	private void HedefeBak()
	{
		if (Hedef != null) 
		{
			float xYon = Hedef.transform.position.x - transform.position.x;

			if (xYon < 0 && sagaBak || xYon > 0 && !sagaBak) 
			{
				YonDegistir ();
			}
		}
	}

	public void DurumDegistir(DusmanDurum yeniDurum)
	{
		if (mevcutDurum != null) {
			mevcutDurum.Exit ();
		}
		mevcutDurum = yeniDurum;
		mevcutDurum.Enter (this);
	}

	public void Hareket()
	{
		if (!Atak) {
			MyAnimator.SetFloat ("karakterHizi", 1);
			transform.Translate (YonAyarla() * (hiz * Time.deltaTime));
		}

	}

	public Vector2 YonAyarla()
	{
		return sagaBak ? Vector2.right : Vector2.left;
	}

	public override void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D(other);
		mevcutDurum.OnTriggerEnter (other);
	}

	public override IEnumerator Darbe()
	{
		enerji -= 10;
		if (!Oldumu) 
		{
			MyAnimator.SetTrigger ("darbe");
		}
		else	
		{
			MyAnimator.SetTrigger ("olme");
			yield return null;
		}
	}
}
