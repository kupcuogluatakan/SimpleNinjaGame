using UnityEngine;
using System.Collections;

public class Basamak : MonoBehaviour {

	private BoxCollider2D karakterCollider;
	[SerializeField]
	private BoxCollider2D basamakCollider;
	[SerializeField]
	private BoxCollider2D basamakTrigger;

	void Start () {
		karakterCollider = GameObject.Find ("Player").GetComponent<BoxCollider2D> ();
		Physics2D.IgnoreCollision (basamakCollider, basamakTrigger, true);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") 
		{
			Physics2D.IgnoreCollision (basamakCollider, karakterCollider, true);
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") 
		{
			Physics2D.IgnoreCollision (basamakCollider, karakterCollider, false);
		}
	}
}
