using UnityEngine;
using System.Collections;
using System;

public class DevriyeDurum : DusmanDurum {

	private Dusman dusman;
	private float devriyeZamanlayici;

	private float devriyeSuresi = 10;

	public void Enter(Dusman dusman)
	{
		this.dusman = dusman;
	}

	public void Execute()
	{
		Devriye ();
		dusman.Hareket ();

		if (dusman.Hedef != null && dusman.FirlatmaAlaninda) {
			dusman.DurumDegistir (new GezmeDurum());
		}
	}
	public void Exit()
	{

	}
	public void OnTriggerEnter(Collider2D other)
	{
		if (other.tag == "kenar") 
		{
			dusman.YonDegistir ();
		}
	}

	private void Devriye()
	{
		
		devriyeZamanlayici += Time.deltaTime;

		if (devriyeZamanlayici >= devriyeSuresi) {
			dusman.DurumDegistir (new DusunmeDurum());
		}
	}
}
