using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] obstaclePrefabs;
    public GameObject coinPrefab;

    public float spawnDistance = 5f;
    public float minX = -4f;
    public float maxX = 4f;
    public float coinHeightOffset = 1f;

 
    public GameObject cylinderGatePrefab;
    public float cylinderGateX = -5f;
    public float cylinderGateExtraHeight = 3f;
    public int cylinderGateEvery = 4;

 
    public float cylinderGateCoinOffsetX = -1f;


    public GameObject staticObstaclePrefab;

   
    public float staticObstacleX = -0.87057f;

    public int staticObstacleEvery = 6;

    public float staticCoinOffsetX = -0.3f;
    public float staticCoinOffsetY = 2f;

    private float nextSpawnY;
    private int spawnCount = 0;

    void Start()
    {
        nextSpawnY = player.transform.position.y + spawnDistance;
    }

    void Update()
    {
        if (player.transform.position.y + spawnDistance > nextSpawnY)
        {
            SpawnObstacle();

     
            if (spawnCount % cylinderGateEvery == 0)
            {
                nextSpawnY += spawnDistance + cylinderGateExtraHeight;
            }
            else
            {
                nextSpawnY += spawnDistance;
            }
        }
    }

    void SpawnObstacle()
    {
        spawnCount++;

  

        if (spawnCount % cylinderGateEvery == 0)
        {
            Vector3 gatePosition = new Vector3(
                -5f,
                nextSpawnY,
                0f
            );

            Instantiate(
                cylinderGatePrefab,
                gatePosition,
                Quaternion.identity
            );

            Vector3 coinPosition = new Vector3(
                -5f + cylinderGateCoinOffsetX,
                nextSpawnY + coinHeightOffset,
                0f
            );

            Instantiate(
                coinPrefab,
                coinPosition,
                Quaternion.identity
            );
        }

      

        else if (spawnCount % staticObstacleEvery == 0)
        {
            Vector3 staticPosition = new Vector3(
                -0.87057f,
                nextSpawnY,
                0f
            );

            Instantiate(
                staticObstaclePrefab,
                staticPosition,
                Quaternion.identity
            );
            Vector3 coinPosition = new Vector3(
                -0.87057f + staticCoinOffsetX,
                nextSpawnY + coinHeightOffset + staticCoinOffsetY,
                0f
            );

            Instantiate(
                coinPrefab,
                coinPosition,
                Quaternion.identity
            );
        }



        else
        {
            float randomX = Random.Range(minX, maxX);

            Vector3 spawnPosition = new Vector3(
                randomX,
                nextSpawnY,
                0f
            );

            int randomIndex = Random.Range(
                0,
                obstaclePrefabs.Length
            );

            Instantiate(
                obstaclePrefabs[randomIndex],
                spawnPosition,
                Quaternion.identity
            );

           
            Vector3 coinPosition = new Vector3(
                randomX,
                nextSpawnY + coinHeightOffset,
                0f
            );

            Instantiate(
                coinPrefab,
                coinPosition,
                Quaternion.identity
            );
        }
    }
}
