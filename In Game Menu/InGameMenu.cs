using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameMenu : MonoBehaviour {

	public GameObject menu, itemMenu, equipmentMenu, playerStatus, AimVector;
	bool menuSwitch = false;
	public AudioSource changeMenu;


	// Use this for initialization
	void Start () 
	{
		menu.SetActive (false);
		itemMenu.SetActive (false);
		equipmentMenu.SetActive (false);																																																																																																																																																																																																																																																																																																																																				
	}

	public void selectItems()
	{
		itemMenu.SetActive (true);
		equipmentMenu.SetActive (false);
	}

	public void selectEquipment()
	{
		itemMenu.SetActive (false);
		equipmentMenu.SetActive (true);

	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.Tab)) 
		{
			changeMenu.Play ();

			if (menuSwitch == false) 
			{
				menu.SetActive (true);
				playerStatus.SetActive (false);
				AimVector.SetActive (false);
				menuSwitch = true;
			}
			else if (menuSwitch == true) 
			{
				menu.SetActive (false);
				playerStatus.SetActive (true);
				AimVector.SetActive (true);
				menuSwitch = false;
			}
		}
	}
}
