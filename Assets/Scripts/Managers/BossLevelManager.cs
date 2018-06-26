using UnityEngine;
using System.Collections;

public class BossLevelManager : MonoBehaviour {

	public BossHealth bossHealth;
	public PlayerShooting playerShooting;
	public PlayerMovement playerMovement;
	//public TimerManager timerManager;
	
	GameObject[] enemies;

	Animator anim;
	
	
	void Awake()
	{
		anim = GetComponent<Animator>();
	}
	
	
	void Update()
	{
		if (bossHealth.currentHealth <= 0)
		{
			enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach (GameObject go in enemies) {
				Debug.Log ("Destroy enemies");
				Destroy(go);
			}
			
			Destroy(GameObject.Find("EnemyManager"));
			
			playerShooting.DisableEffects ();
			
			playerMovement.enabled = false;
			playerShooting.enabled = false;

			StartCoroutine(LevelEnd());

		}
	}

	IEnumerator LevelEnd() {
		yield return new WaitForSeconds(7);
		anim.SetTrigger("LevelComplete");
	}
}
