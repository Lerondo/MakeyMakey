 using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class LightSwitchsPlay : MonoBehaviour {

	void Start()
	{
		GetComponent<Light>().intensity = 0;
	}

	void Update ()
	{
		if (gameObject.tag == "1stLight")
		{
			if (Input.GetKeyDown (KeyCode.LeftArrow)) 
			{
				GetComponent<Light>().color = new Color (Random.value,Random.value,Random.value);
				GetComponent<Light>().intensity = 8;
				GetComponent<AudioSource>().Play();
			}
			if (Input.GetKeyUp (KeyCode.LeftArrow)) 
			{
				GetComponent<Light>().intensity = 0;
			}
		}
		if (gameObject.tag == "2ndLight")
		{
			if (Input.GetKeyDown (KeyCode.UpArrow)) 
			{
				GetComponent<Light>().color = new Color (Random.value,Random.value,Random.value);
				GetComponent<Light>().intensity = 8;
				GetComponent<AudioSource>().Play();
			}
			if (Input.GetKeyUp (KeyCode.UpArrow)
			    ) 
			{
				GetComponent<Light>().intensity = 0;
			}
		}
		if (gameObject.tag == "3rdLight")
		{
			if (Input.GetKeyDown (KeyCode.RightArrow)) 
			{
				GetComponent<Light>().color = new Color (Random.value,Random.value,Random.value);
				GetComponent<Light>().intensity = 8;
				GetComponent<AudioSource>().Play();
			}
			if (Input.GetKeyUp (KeyCode.RightArrow)) 
			{
				GetComponent<Light>().intensity = 0;
			}
		}
	}
}
