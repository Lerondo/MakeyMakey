using UnityEngine;
using System.Collections;

public class DeathTimer : MonoBehaviour {

	private int timer = 50;
	
	void Update () 
	{
		timer --;
		if (timer < 0)
			Destroy(this.gameObject);
	}
}
