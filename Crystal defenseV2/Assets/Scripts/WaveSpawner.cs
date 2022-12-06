using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Wave
{
    public string waveName;
    public int numberEnemy;
    public GameObject[] typeEnemies;
    public float spawnInterval;
}


public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;
    //public Animator anim;
    //public Text waveName;

    private Wave currentWave;
    private int currentWaveNumber;

    private bool canSpawn = true;
    private bool canAnimate = false;
    private float nextSpawnTime;

    [SerializeField] GameObject nextSpawnButton;
    [SerializeField] GameObject finalSpawnButton;

    private void Start()
    {
        nextSpawnButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0)
        {
            if (currentWaveNumber + 1 != waves.Length)
            {
                if (canAnimate)
                {
                    if(currentWaveNumber == 4)
                    {
                        finalSpawnButton.gameObject.SetActive(true);
                        nextSpawnButton.gameObject.SetActive(false);
                    }
                    else
                    {
                        nextSpawnButton.gameObject.SetActive(true);
                    }
                    

                }

            }
            else
            {
                SceneManager.LoadScene(2);
            }


        }

    }

    public void SpawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeEnemies[Random.Range(0, currentWave.typeEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.numberEnemy--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if (currentWave.numberEnemy == 0)
            {
                canSpawn = false;
                canAnimate = true;
            }
        }

    }
}
