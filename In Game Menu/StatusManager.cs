using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusManager : MonoBehaviour {

	public Text inGunBulletCountText, totalBulletCountText, grenadeCountText;
	public int maxMagazineSize = 60;
	int inGunBulletCount;
	public int totalBulletCount = 180;
	int grenadeCount = 3;
	public Image healthFill, healthBarOutLine;
	float maxHealth = 100;
	float currentHealth;
	public GameObject hitWarning;
	public Image hitIndicatorImg;
	public AudioSource gunshotSound, reloadSound;

	// Use this for initialization
	void Start () 
	{
		hitWarning.SetActive (false);
		inGunBulletCount = maxMagazineSize;
		currentHealth = maxHealth;

		inGunBulletCountText = inGunBulletCountText.GetComponent<Text> ();
		totalBulletCountText = totalBulletCountText.GetComponent<Text> ();
		grenadeCountText = grenadeCountText.GetComponent<Text> ();
		healthFill = healthFill.GetComponent<Image> ();
		healthBarOutLine = healthBarOutLine.GetComponent<Image> ();
		hitIndicatorImg = hitIndicatorImg.GetComponent<Image> ();

		grenadeCountText.text = grenadeCount.ToString ();
		inGunBulletCountText.text = inGunBulletCount.ToString ();
		totalBulletCountText.text = totalBulletCount.ToString ();
	}

	void bulletUpdate()
	{
		int reloadedBulletCount;
		if (inGunBulletCount > 0) 
		{
			inGunBulletCountText.color = new Color32 (71, 232, 255, 255);

			if (Input.GetMouseButtonDown (0)) 
			{
				inGunBulletCount--;
				gunshotSound.Play ();
				inGunBulletCountText.text = inGunBulletCount.ToString ();
			}

		}

		if (inGunBulletCount == 0) 
		{
			inGunBulletCountText.color = new Color32 (250, 0, 0, 255);
		}

		if (totalBulletCount > 0) 
		{
			if (inGunBulletCount < maxMagazineSize) 
			{
				if (Input.GetKeyDown (KeyCode.R)) 
				{	
					reloadSound.Play ();	
					if (totalBulletCount < maxMagazineSize) 
					{
						if(inGunBulletCount < totalBulletCount)
						{
							reloadedBulletCount = maxMagazineSize - inGunBulletCount;

							if (totalBulletCount < reloadedBulletCount) 
							{
								int temp;
								temp = reloadedBulletCount - totalBulletCount;
								reloadedBulletCount = reloadedBulletCount - temp;
								inGunBulletCount += reloadedBulletCount;
								totalBulletCount = 0;
								inGunBulletCountText.text = inGunBulletCount.ToString ();
								totalBulletCountText.text = totalBulletCount.ToString ();
							}
					
						}

						reloadedBulletCount = maxMagazineSize - inGunBulletCount;
						inGunBulletCount += reloadedBulletCount;
						totalBulletCount -=reloadedBulletCount;
						inGunBulletCountText.text = inGunBulletCount.ToString ();
						totalBulletCountText.text = totalBulletCount.ToString ();
					} 
					else 
					{
						reloadedBulletCount = maxMagazineSize - inGunBulletCount;
						totalBulletCount -= reloadedBulletCount;
						inGunBulletCount = maxMagazineSize;
						inGunBulletCountText.text = inGunBulletCount.ToString ();
						totalBulletCountText.text = totalBulletCount.ToString ();
					}
				}
			}

		}

	}

	void grenadeUpdate()
	{
		if (grenadeCount > 0) 
		{
			if (Input.GetKeyDown (KeyCode.G)) 
			{
				grenadeCount--;
				grenadeCountText.text = grenadeCount.ToString ();
			}
		}
	}

	IEnumerator HitIndicator()
	{
		float time = 1.0f;
		float percent = 0;
		float dmgCounter = 0;

		while (percent <= 1) 
		{
			hitWarning.SetActive (true);
			dmgCounter += Time.deltaTime;
			percent = dmgCounter / time;

			hitIndicatorImg.color = Color.Lerp (Color.white, Color.clear, percent);

			if (percent >= 1) 
			{
				hitWarning.SetActive (false);
			}
			yield return null;
		}
	}

	void healthUpdate ()
	{
		float healthPercentage;

		if (currentHealth > 0) 
		{
			if (Input.GetKey (KeyCode.Minus)) 
			{
				StartCoroutine (HitIndicator());
				currentHealth -= 1;
				healthPercentage = currentHealth / maxHealth;
				setHealthBar (healthPercentage);
			}
		}

		if (currentHealth < maxHealth) 
		{
			if (Input.GetKey (KeyCode.Equals)) 
			{
				currentHealth += 1;
				healthPercentage = currentHealth / maxHealth;
				setHealthBar (healthPercentage);
			}
		}

	}

	void setHealthBar(float health)
	{
		healthFill.transform.localScale = new Vector3 (health, 
														healthFill.transform.localScale.y, 
														healthFill.transform.localScale.z);

		if (health <= 1.0) 
		{
			healthFill.color = new Color32 (0, 244, 255, 255);
		}
		if (health <= 0.70) 
		{
			healthFill.color = new Color32 (0, 255, 76, 255);
		}
		if (health <= 0.45) 
		{
			healthFill.color = new Color32 (241, 255,0, 255);
			healthBarOutLine.color = new Color32 (0, 244, 255, 255);
		}
		if (health <= 0.20) 
		{
			healthFill.color = new Color32 (255, 0, 0, 255);
			healthBarOutLine.color = new Color32 (255, 0, 0, 255);
		}

	}

	// Update is called once per frame
	void Update () 
	{

		bulletUpdate ();
		grenadeUpdate ();
		healthUpdate ();
	
	}
}
