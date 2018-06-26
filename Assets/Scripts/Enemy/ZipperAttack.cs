using UnityEngine;
using System.Collections;

public class ZipperAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
	
	
	protected Animator anim;
	protected GameObject player;
	protected PlayerHealth playerHealth;
	protected EnemyHealth zipperHealth;
	protected bool playerInRange;
	protected float timer;
	
	
	public virtual void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		zipperHealth = GetComponent<EnemyHealth>();
		anim = GetComponent <Animator> ();
	}
	
	
	public void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
			anim.SetBool("PlayerInRange",true);
		}
	}
	
	
	public void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
			anim.SetBool("PlayerInRange",false);
		}
	}
	
	
	public virtual void Update ()
	{
		timer += Time.deltaTime;
		
		if(timer >= timeBetweenAttacks && playerInRange && zipperHealth.currentHealth > 0)
		{
			Attack ();
		}
		
		if(playerHealth.currentHealth <= 0)
		{
			anim.SetTrigger ("PlayerDead");
		}
	}
	
	
	public virtual void Attack ()
	{
		timer = 0f;
		
		if(playerHealth.currentHealth > 0)
		{
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
