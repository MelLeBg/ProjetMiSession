using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable] 


public class Wave
{
    public string wavename;
    public int NbEnnemies;
    public float SpawnRate;
}

public class WaveSpawner : MonoBehaviour
{
    public GameObject Enemy;
    public Wave[] waves; 
    public Transform[] Spawnpoints; 
    public Animator animator;
    public Text WaveName;

    private Wave currentWave;
    private int CurrentWaveNumber;
    private float nextSpawn;

    private bool canSpawn = true;
    private bool GameWon = false;


    private void Update()
    {
        currentWave = waves[CurrentWaveNumber];
        SpawnWave();
        GameObject TotalEnemies = GameObject.FindGameObjectWithTag("Ennemie");

        if (TotalEnemies == null) 
        {
           
            
                if (GameWon == true)
                {
                    FindObjectOfType<GameManager>().WinningScreen();
                    GameWon = false;
                }

            
            SpawnNextWave();
        }


    }

    void SpawnNextWave()
    {
        CurrentWaveNumber++;
        canSpawn = true;
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawn < Time.time)
        {
            Transform randomSpawn = Spawnpoints[Random.Range(0, Spawnpoints.Length)]; 
            Instantiate(Enemy, randomSpawn.position, transform.rotation); 
            currentWave.NbEnnemies--;
            nextSpawn = Time.time + currentWave.SpawnRate;

            if (currentWave.NbEnnemies == 0) 
            {
                canSpawn = false;
                

            }
        }
    }



}




