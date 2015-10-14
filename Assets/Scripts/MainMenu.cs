using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public void eightBit()
	{
		Application.LoadLevel ("8Bit");
	}
	public void reggae()
	{
		Application.LoadLevel ("Mush");
	}
	public void house()
	{
		Application.LoadLevel ("House");
	}
}
