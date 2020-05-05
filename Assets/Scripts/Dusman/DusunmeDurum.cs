using UnityEngine;
using System.Collections;
using System;

public class DusunmeDurum : DusmanDurum {

	private Dusman dusman;

	private float dusunmeZamanlayici;

	private float dusunmeSuresi = 5;

	public void Enter(Dusman dusman)
	{
		this.dusman = dusman;
	}

	public void Execute()
	{
		Debug.Log ("Şu an hiçbir şey yapmadan duruyorum :))");
		Dusunme ();
		if (dusman.Hedef != null) {
			dusman.DurumDegistir (new DevriyeDurum());
		}
	}
	public void Exit()
	{

	}
	public void OnTriggerEnter(Collider2D other)
	{
		
	}
	private void Dusunme()
	{
		dusman.MyAnimator.SetFloat ("karakterHizi",0);

		dusunmeZamanlayici += Time.deltaTime;

		if (dusunmeZamanlayici >= dusunmeSuresi) {
			dusman.DurumDegistir (new DevriyeDurum());
		}
	}
}
