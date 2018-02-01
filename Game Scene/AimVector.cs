using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AimVector : MonoBehaviour {

	public Image aimVectorImage;
	bool enemyCollision = false;

	// Use this for initialization
	void Start () 
	{
		aimVectorImage = aimVectorImage.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.H)) 
		{

			if (enemyCollision == false) 
			{
				aimVectorImage.color = new Color32 (255, 0, 0, 255);
				enemyCollision = true;
			}
			else if (enemyCollision == true) 
			{
				aimVectorImage.color = new Color32 (255, 250, 250, 255);
				enemyCollision = false;
			}
		}
		
	
	}
}
