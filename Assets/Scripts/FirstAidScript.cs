using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FirstAidScript : MonoBehaviour {

	public int healthAmmount = 50;
	public Slider playerHealthSlider;

	GameObject player;
	PlayerHealth playerHealth;
	AudioSource heal;



	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		heal = GetComponent<AudioSource> ();

		
	}

	IEnumerator OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			heal.Play();

			yield return new WaitForSeconds(0.5f);

			playerHealth.currentHealth += healthAmmount;

			playerHealthSlider.value = playerHealth.currentHealth;

			Destroy(gameObject);

		}
	}
}
