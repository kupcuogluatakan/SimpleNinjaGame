using UnityEngine;
using System.Collections;
using System;

public class KavgaDurum : DusmanDurum {

	private Dusman dusman;
	private float atakZamani;
	private float atakSonlanmasi = 3;

	private bool atakYapabilir = true;

	public void Enter(Dusman dusman)
	{
		this.dusman = dusman;
	}

	public void Execute()
	{
		Atak ();
		if (dusman.FirlatmaAlaninda && !dusman.KavgaAlaninda) {
			dusman.DurumDegistir (new GezmeDurum ());
		}
		else if (dusman.Hedef == null) 
		{
			dusman.DurumDegistir(new DusunmeDurum());
		}
	}

	public void Exit()
	{
		
	}

	public void OnTriggerEnter(Collider2D other)
	{
		
	}

	private void Atak()
	{
		atakZamani += Time.deltaTime;

		if (atakZamani >= atakSonlanmasi) 
		{
			atakYapabilir = true;
			atakZamani = 0;
		}

		if (atakYapabilir) 
		{
			atakYapabilir = false;
			dusman.MyAnimator.SetTrigger ("atak");
		}

	}
}
