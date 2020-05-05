using UnityEngine;
using System.Collections;

public class DusmanGorus : MonoBehaviour {

	[SerializeField]
	private Dusman dusman;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			dusman.Hedef = other.gameObject;
		}	
	}

	void OnTriggerExit2D(Collider2D other)
	{
	if (other.tag == "Player")
	{
		dusman.Hedef = null;
	}	
    
	}
}
