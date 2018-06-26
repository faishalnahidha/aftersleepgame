using UnityEngine;
using System.Collections;

public class BossAttack : ZipperAttack {

	public AudioSource footstep;
	public AudioSource attackHit;

	NavMeshAgent nav;
	float navSpeedBefore;
	float navAngSpeedBefore;

	public override void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		zipperHealth = GetComponent<EnemyHealth>();
		anim = GetComponent <Animator> ();
		nav = GetComponent<NavMeshAgent> ();
		navSpeedBefore = nav.speed;
		navAngSpeedBefore = nav.angularSpeed;

	}
	
	public override void Update(){

		if (playerInRange && zipperHealth.currentHealth > 0) {

			nav.speed = 0;
			nav.angularSpeed = 5;
			footstep.mute = true;
			//timer += Time.deltaTime;

			//if(timer > timeBetweenAttacks){
			//	Attack();
			//}

		}else{
			nav.speed = navSpeedBefore;
			nav.angularSpeed = navAngSpeedBefore;
			footstep.mute = false;
		}


		if(playerHealth.currentHealth <= 0)
		{
			anim.SetTrigger ("PlayerDead");
			this.enabled = false;

		}
	}

	public override void Attack(){
		//timer = 0f;
		ParticleSystem hitParticles = GetComponentInChildren <ParticleSystem> ();
		attackHit.Play ();

		hitParticles.startSize = 10;
		hitParticles.startLifetime = 0.5f;
		hitParticles.Play();

		if (playerInRange && zipperHealth.currentHealth > 0) {
			if (playerHealth.currentHealth > 0) {
				playerHealth.TakeDamage (attackDamage);

			}
		}
	}
}
