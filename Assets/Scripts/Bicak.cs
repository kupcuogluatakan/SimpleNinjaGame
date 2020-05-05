using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]

public class Bicak : MonoBehaviour {
	
	[SerializeField]
	private float bicakHizi;

	private Rigidbody2D myRigidbody;

	private Vector2 bicakYonu;


	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		myRigidbody.velocity = bicakYonu * bicakHizi;
	}
	
	public void Initialize(Vector2 bicakYonu)
	{
		this.bicakYonu = bicakYonu;
	}

	void OnBecameInvisible () {
		Destroy (gameObject);
	}


}
