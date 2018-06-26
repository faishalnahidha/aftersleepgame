using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
	public float startingTime = 0f;
    public Transform[] spawnPoints;


    void Start ()
    {
		StartCoroutine(StartSpawn(startingTime));
        //InvokeRepeating ("Spawn", spawnTime, spawnTime);

    }

	IEnumerator StartSpawn(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

	public void setSpawnTime(float spawnTime){
		this.spawnTime = spawnTime;
	}
}
