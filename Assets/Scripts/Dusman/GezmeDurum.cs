using UnityEngine;
using System.Collections;
using System;

public class GezmeDurum : DusmanDurum {

	private Dusman dusman;
	private float firlatmaZamani;
	private float firlatmaSonlanmasi = 3;

	private bool firlatabilir = true;

	public void Enter(Dusman dusman)
	{
		this.dusman = dusman;
	}

	public void Execute()
	{
		BicakFirlat ();
		if (dusman.KavgaAlaninda) 
		{
			dusman.DurumDegistir (new KavgaDurum ());
		}
		else if (dusman.Hedef != null) {
			dusman.Hareket ();
		} 
		else 
		{
			dusman.DurumDegistir (new DusunmeDurum ());
		}
	}

	public void Exit()
	{

	}

	public void OnTriggerEnter(Collider2D other)
	{

	}

	private void BicakFirlat()
	{
		firlatmaZamani += Time.deltaTime;

		if (firlatmaZamani >= firlatmaSonlanmasi) 
		{
			firlatabilir = true;
			firlatmaZamani = 0;
		}

		if (firlatabilir) 
		{
			firlatabilir = false;
			dusman.MyAnimator.SetTrigger ("firlat");
		}

	}
}

