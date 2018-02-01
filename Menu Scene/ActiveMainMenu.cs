using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActiveMainMenu : MonoBehaviour {

	public Canvas menu;
	public Text pressEnterText;
	public Button startGameButton;
	public Image centreIcon;
	public Animator centreIconActive;
	//public Text text1, text2, text3;
	public Text playText, quitText, optionText, sub1Text, sub3Text, newGameText;
	public Image subsub1, subsub2, subsub3;
	public Animator menuLine1, menuLine2, menuLine3;
	public Button SubMenuButton1, SubMenuButton2, SubMenuButton3;
	public Animator submenuAnimator1, submenuAnimator2, submenuAnimator3;
	//public

	// Use this for initialization
	void Start () 
	{	
		startGameButton.enabled = false;
		subsub1.enabled = false;
		subsub2.enabled = false;
		subsub3.enabled = false;
		sub1Text.enabled = false;
		newGameText.enabled = false;
		sub3Text.enabled = false;
		centreIconActive.enabled = false;
		menuLine1.enabled = false;
		menuLine2.enabled = false;
		menuLine3.enabled = false;
		submenuAnimator1.enabled = false;
		submenuAnimator2.enabled = false;
		submenuAnimator3.enabled = false;
		SubMenuButton1.enabled = false;
		SubMenuButton2.enabled = false;
		SubMenuButton3.enabled = false;
		playText.enabled = false;
		quitText.enabled = false;
		optionText.enabled = false;


		menu = menu.GetComponent<Canvas> ();
		centreIcon = centreIcon.GetComponent<Image> ();
		centreIconActive = centreIconActive.GetComponent<Animator> ();
		playText = playText.GetComponent<Text> ();
		subsub1 = subsub1.GetComponent<Image> ();
		startGameButton = startGameButton.GetComponent<Button> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			pressEnterText.enabled = false;
			centreIcon.enabled = false;
			centreIconActive.enabled = true;
			menuLine1.enabled = true;
			menuLine2.enabled = true;
			menuLine3.enabled = true;
			submenuAnimator1.enabled = true;
			submenuAnimator2.enabled = true;
			submenuAnimator3.enabled = true;
			SubMenuButton1.enabled = true;
			SubMenuButton2.enabled = true;
			SubMenuButton3.enabled = true;
			playText.enabled = true;
			quitText.enabled = true;
			optionText.enabled = true;
		}
	}

	public void playButtom()
	{
		subsub1.enabled = true;
		subsub2.enabled = true;
		subsub3.enabled = true;
		sub1Text.enabled = true;
		startGameButton.enabled = true;
		newGameText.enabled = true;
		sub3Text.enabled = true;

	}
		
}
