using UnityEngine;
using System.Collections;

public class Mush : MonoBehaviour {

	private int intelligence;
	private int cases = 0;
	
	public GameObject ArrowLeft;
	public GameObject ArrowDown;
	public GameObject ArrowRight;
	
	public Transform LeftSpawn;
	public Transform DownSpawn;
	public Transform RightSpawn;

	private bool thisframe;
	private bool lastframe = false;
	private int bassframes = 0;

	public GUIStyle Random1;
	public float guiPlacementX1;
	public float guiPlacementY1;

	void OnGUI()
	{
		if (GUI.Button (new Rect(Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * .075f, Screen.height * .10f), "",Random1)){
			print ("Clicked Menu");
			Application.LoadLevel("Menu");
		}
	}
	
	void Update() 
	{
		float[] spectrum = GetComponent<AudioSource>().GetSpectrumData(1024, 0, FFTWindow.BlackmanHarris);

		float bassCount = 0f;
		int l = spectrum.Length;
		thisframe = false;
		for (int j=0; j< l; j++) {
			//Debug.Log(  j+ ": index "+ spectrum[j] );

			if(j <10)
				bassCount+= spectrum[j] * 10;
		}	
		if (bassCount > 8.5) {
			thisframe = true;

		} else {
			bassframes = 0;		
		}
		//Debug.Log("end framw!!!!");
		//float[] spectrum = audio.GetOutputData (1024*4, 0);

		if (lastframe && thisframe) {
			bassframes ++;

			if(bassframes > 2.5)
			{
				//Debug.Log ("bass bitch!!!!");
				intelligence = Random.Range (0, 3);
				cases++;
				switch (intelligence)
				{
				case 2:
					if(cases >= 2)
					{
						//print ("Left Arrow Spawn!");
						Instantiate (ArrowLeft, LeftSpawn.position, LeftSpawn.rotation);
						cases = 0;
					}
					break;
					case 1:
					if(cases >= 2)
					{
						//print ("Down Arrow Spawn");
						Instantiate (ArrowDown, DownSpawn.position, DownSpawn.rotation);
						cases = 0;
					}
					break;
				case 0:
					if(cases >= 1)
					{
						//print ("Right Arrow Spawn");
						Instantiate (ArrowRight, RightSpawn.position, RightSpawn.rotation);
						cases = 0;
					}
					break;
				}
			}
		
		}

		lastframe = thisframe;

		int i = 1;
		while (i < 1023) {
			Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
			Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.yellow);
			i++;
		}
	}
}