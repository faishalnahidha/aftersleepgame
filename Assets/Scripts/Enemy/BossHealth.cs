using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHealth : EnemyHealth {
	
	int amountBeforeGroaning = 0;
	public AudioSource groanSound;
	public AudioSource footstep;
	public Slider healthSlider;

	public override void Awake ()
	{
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
		hitParticles = GetComponentInChildren <ParticleSystem> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();
		
		currentHealth = startingHealth;

		healthSlider.value = currentHealth;
	}

	public override void Update ()
	{
		if(isSinking)
		{
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}

		if (amountBeforeGroaning >= 1000) {
			//Debug.Log("aaaaa");
			amountBeforeGroaning =0;
			groanSound.Play ();
		}
	}

	public override void TakeDamage (int amount, Vector3 hitPoint)
	{
		if(isDead)
			return;

		//enemyAudio.Play ();

		amountBeforeGroaning += amount;
		
		currentHealth -= amount;
		
		hitParticles.transform.position = hitPoint;
		hitParticles.Play();

		healthSlider.value = currentHealth;
		
		if(currentHealth <= 0)
		{
			footstep.Stop();
			Death ();
		}
	}

	public override void StartSinking ()
	{
		Debug.Log ("Hello, The Boss sinking now");
		GetComponent <NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		isSinking = true;
		ScoreManager.score += scoreValue;
		Destroy (gameObject, 20f);
	}

}
