using UnityEngine;
using System.Collections;

public class Kamera : MonoBehaviour {

	[SerializeField]
	private float xMax;
	[SerializeField]
	private float yMax;
	[SerializeField]
	private float xMin;
	[SerializeField]
	private float yMin;

	private Transform hedef;

	void Start () {
		hedef = GameObject.Find ("Player").transform;
	}

	void LateUpdate()
	{
		transform.position = new Vector2 (Mathf.Clamp (hedef.position.x, xMin, xMax), Mathf.Clamp (hedef.position.y, yMin, yMax));
	}

}
