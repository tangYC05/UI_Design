using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PressStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	public void startGame()
	{
		SceneManager.LoadScene("GameScene");
	}

	// Update is called once per frame
	void Update () 
	{
	}
}
