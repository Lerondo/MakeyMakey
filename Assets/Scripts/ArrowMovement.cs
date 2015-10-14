using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArrowMovement : MonoBehaviour {
	
	private float speed = 0.02f;

	public static int scoreValue;

	public Text scoreText;

	public GameObject LeftArrow;
	public GameObject UpArrow;
	public GameObject RightArrow;

	public GameObject deathSpawn;

	void Start()
	{
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
	}

	void Update () 
	{
		scoreText.text = "Score : " + scoreValue;

		transform.Translate (Vector3.up * Time.deltaTime, Space.World);

		if (LeftArrow.transform.position.y >= 0 && LeftArrow.transform.position.y <= 0.8) 
		{
			if(Input.GetKeyDown(KeyCode.LeftArrow))
			{
				Instantiate (deathSpawn, LeftArrow.transform.position, LeftArrow.transform.rotation);
				Destroy (LeftArrow);
				scoreValue++;
			}
		}
		if (UpArrow.transform.position.y >= 0 && UpArrow.transform.position.y <= 0.8) 
		{
			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				Instantiate (deathSpawn, UpArrow.transform.position, UpArrow.transform.rotation);
				Destroy (UpArrow);
				scoreValue++;
			}
		}
		if (RightArrow.transform.position.y >= 0 && RightArrow.transform.position.y <= 0.8) 
		{
			if(Input.GetKeyDown(KeyCode.RightArrow))
			{
				Instantiate (deathSpawn, RightArrow.transform.position, RightArrow.transform.rotation);
				Destroy (RightArrow);
				scoreValue++;
			}
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "box") 
		{
			scoreText.text =  "Score : " + scoreValue;
			Destroy(this.gameObject);
		}
	}
}