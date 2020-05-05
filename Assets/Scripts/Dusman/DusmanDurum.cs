using UnityEngine;
using System.Collections;

public interface DusmanDurum 
{
	void Execute();
	void Enter(Dusman dusman);
	void Exit();
	void OnTriggerEnter(Collider2D other);

}
