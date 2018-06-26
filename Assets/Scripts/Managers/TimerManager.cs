using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour {

	public float timeStart = 10f;
	public static float timeLeft;

	Transform player;
	GameObject[] enemies;
	GameObject enemyManager;
	PlayerShooting playerShooting;
	PlayerMovement playerMovement;
	EnemyManager[] enemyManagerScript;
	//EnemyMovement enemyMovement;
	//EnemyAttack enemyAttack;

	Text text;
	//PlayerHealth playerHealth;

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text>();
		timeLeft = timeStart+3;

		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerShooting = player.GetComponentInChildren<PlayerShooting> ();
		playerMovement = player.GetComponent<PlayerMovement> ();

		enemyManager = GameObject.Find ("EnemyManager");
		enemyManagerScript = enemyManager.GetComponents<EnemyManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		text.text = ""+(int)timeLeft;

		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		//enemyMovement = enemy.GetComponent<EnemyMovement> ();
		
		if(timeLeft <= 0){
			timeLeft =0;
			playerShooting.enabled = false;
			playerMovement.enabled = false;
			foreach(EnemyManager em in enemyManagerScript){
				em.setSpawnTime(1000);
			}
			foreach(GameObject go in enemies){
				go.SetActive(false);
			}
		}
	}
	
}