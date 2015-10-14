using UnityEngine;
using System.Collections;

public class delayScript : MonoBehaviour {

	public AudioSource foo;

	void Update()
	{
		if (!foo.isPlaying && Time.time >= 3) 
		{
			foo.Play ();
		}
	}
}
