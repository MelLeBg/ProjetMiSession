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
    private bool canAnimate = false;
    private bool GameWon = true;


    private void Update()
    {
        currentWave = waves[CurrentWaveNumber];
        SpawnWave();
        GameObject TotalEnemies = GameObject.FindGameObjectWithTag("Ennemie");

        if (TotalEnemies == null) // Commence la prochaine wave lorsque tous les ennemies de la currentwave sont morts
        {
            if (CurrentWaveNumber + 1 != waves.Length)
            {
                if (canAnimate)
                {
                    WaveName.text = waves[CurrentWaveNumber + 1].wavename;
                    animator.SetTrigger("WaveComplete");
                    canAnimate = false;
                }
            }
            else
            {
                if (GameWon == true)
                {
                    FindObjectOfType<GameManager>().WinningScreen();
                    GameWon = false;
                }

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
                canAnimate = true;

            }
        }
    }



}




