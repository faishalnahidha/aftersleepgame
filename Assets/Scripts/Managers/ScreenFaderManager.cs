using UnityEngine;
using System.Collections;

public class ScreenFaderManager : MonoBehaviour {

	public PlayerHealth playerHealth;
	public PlayerShooting playerShooting;
	public PlayerMovement playerMovement;
	//public TimerManager timerManager;

	GameObject[] enemies;

	
	Animator anim;
	
	
	void Awake()
	{
		anim = GetComponent<Animator>();
		//anim.Play ("LevelStartClip");
	}
	
	
	void Update()
	{
		if (playerHealth.currentHealth <= 0)
		{
			anim.SetTrigger("GameOver");
		}

		if (TimerManager.timeLeft <= 0) {
			anim.SetTrigger("LevelComplete");
			LevelComplete ();
		}
	}

	void LevelComplete(){
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject go in enemies) {
			Destroy(go);
		}

		Destroy(GameObject.Find("EnemyManager"));

		playerShooting.DisableEffects ();

		playerMovement.enabled = false;
		playerShooting.enabled = false;

	}
}
