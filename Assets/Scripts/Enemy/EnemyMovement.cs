using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    protected Transform player;
	protected PlayerHealth playerHealth;
	protected EnemyHealth enemyHealth;
	protected NavMeshAgent nav;


    public virtual void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
    }


    public virtual void Update ()
    {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination (player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}