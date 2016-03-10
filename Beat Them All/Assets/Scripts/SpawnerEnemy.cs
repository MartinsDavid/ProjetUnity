using UnityEngine;
using System.Collections;

public class SpawnerEnemy : MonoBehaviour
{
    //----------------------------------
    // All the Enums
    //----------------------------------
    // Spawn types
    public enum SpawnTypes
    {
        Normal,
        Once,
        Wave,
        TimedWave
    }

    // The different Enemy levels
    public enum EnemyLevels
    {
        Distance,
        Boss
    }
    //---------------------------------
    // End of the Enums
    //---------------------------------


    // Enemy level to be spawnedEnemy
    public EnemyLevels enemyLevel;


    //----------------------------------
    // Enemy Prefabs
    //----------------------------------
    public GameObject BossEnemy;
    public GameObject DistanceEnemy;
    //----------------------------------
    // End of Enemy Prefabs
    //----------------------------------


    //----------------------------------
    // Enemies and how many have been created and how many are to be created
    //----------------------------------
    public int totalEnemy;
    public int numEnemy = 0;
    public int spawnedEnemy = 0;
    //----------------------------------
    // End of Enemy Settings
    //----------------------------------


    // The ID of the spawner
    private int SpawnID;

    public int lifeTime;
    //----------------------------------
    // Different Spawn states and ways of doing them
    //----------------------------------
    private bool waveSpawn = false;
    public bool Spawn = true;
    public SpawnTypes spawnType = SpawnTypes.Normal;
    // Timed wave controls
    public float waveTimer;
    private float timeTillWave = 0.0f;
    // Wave controls
    public int totalWaves;
    private int numWaves = 0;
    //----------------------------------
    // End of Different Spawn states and ways of doing them
    //----------------------------------


    void Start()
    {
        // Sets a random number for the id of the spawner
        SpawnID = Random.Range(1, 500);
    }

    // Draws a cube to show where the spawn point is... Useful if you don't have a object that show the spawn point
    void OnDrawGizmos()
    {
        // Sets the color to red
        Gizmos.color = Color.red;
        // Draws a small cube at the location of the gam object that the script is attached to
        Gizmos.DrawCube(transform.position, new Vector3(1f, 1f, 1f));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.isTrigger == true && collider.gameObject.tag == "Player")
        {
            InvokeRepeating("SpawnUpdate", 0.2f, 1f);
            //Destroy the spawner after 40 sec
            Destroy(gameObject, lifeTime);
        }
    } 

    // This is the update replacement
    private void SpawnUpdate()  
    {
        if (Spawn)
        {
            // Spawns enemies everytime one dies
            if (spawnType == SpawnTypes.Normal)
            {
                // Checks to see if the number of spawned enemies is less than the max num of enemies
                if (numEnemy < totalEnemy)
                {
                    // Spawns an enemy
                    spawnEnemy();
                }
            }
            // Spawns enemies only once
            else if (spawnType == SpawnTypes.Once)
            {
                // Checks to see if the overall spawned num of enemies is more or equal to the total to be spawned
                if (spawnedEnemy >= totalEnemy)
                {
                    // Sets the spawner to false
                    Spawn = false;
                }
                else
                {
                    // Spawns an enemy
                    spawnEnemy();
                }
            }
            // Spawns enemies in waves, so once all are dead, spawns more
            else if (spawnType == SpawnTypes.Wave)
            {
                if (numWaves < totalWaves + 1)
                {
                    if (waveSpawn)
                    {
                        // Spawns an enemy
                        spawnEnemy();
                    }
                    if (numEnemy == 0)
                    {
                        // Enables the wave spawner
                        waveSpawn = true;
                        // Increase the number of waves
                        numWaves++;
                    }
                    if (numEnemy == totalEnemy)
                    {
                        // Disables the wave spawner
                        waveSpawn = false;
                    }
                }
            }
            // Spawns enemies in waves but based on time.
            else if (spawnType == SpawnTypes.TimedWave)
            {
                // Checks if the number of waves is bigger than the total waves
                if (numWaves <= totalWaves)
                {
                    // Increases the timer to allow the timed waves to work
                    timeTillWave += Time.deltaTime;
                    if (waveSpawn)
                    {
                        // Spawns an enemy
                        spawnEnemy();
                    }
                    // Checks if the time is equal to the time required for a new wave
                    if (timeTillWave >= waveTimer)
                    {
                        // Enables the wave spawner
                        waveSpawn = true;
                        // Sets the time back to zero
                        timeTillWave = 0.0f;
                        // Increases the number of waves
                        numWaves++;
                        // A hack to get it to spawn the same number of enemies regardless of how many have been killed
                        numEnemy = 0;
                    }
                    if (numEnemy >= totalEnemy)
                    {
                        // Disables the wave spawner
                        waveSpawn = false;
                    }
                }
                else
                {
                    Spawn = false;
                }
            }
        }

    }

    // Spawns an enemy based on the enemy level that you selected
    private void spawnEnemy()
    {
        // To check which enemy prefab to instantiate
        if (enemyLevel == EnemyLevels.Boss)
        {
            // Checks to see if there is a gameobject in the boss enemy var
            if (BossEnemy != null)
            {
                // Spawns the enemy
                GameObject Enemy = (GameObject)Instantiate(BossEnemy, gameObject.transform.position, Quaternion.identity);
                // Calls a function on the enemy that applies the spawner's ID to the enemy
                Enemy.SendMessage("setName", SpawnID);
            }
            else
            {
                //Shows a debug message if there is no prefab
                Debug.Log("ERROR: No boss enemy Prefab loaded");
            }
        }
        else if (enemyLevel == EnemyLevels.Distance)
        {
            // Checks to see if there is a gameobject in the Distance enemy var
            if (DistanceEnemy != null)
            {
                // Spawns the enemy
                GameObject Enemy = (GameObject)Instantiate(DistanceEnemy, gameObject.transform.position, Quaternion.identity);
                // Calls a function on the enemy that applies the spawner's ID to the enemy
                Enemy.SendMessage("setName", SpawnID);
            }
            else
            {
                // Shows a debug message if there is no prefab
                Debug.Log("ERROR: No enemy Prefab loaded");
            }
        }
        // Increase the total number of enemies spawned and the number of spawned enemies
        numEnemy++;
        spawnedEnemy++;
    }
    // Call this function from the enemy when it "dies" to remove an enemy count
    public void killEnemy(int sID)
    {
        // If the enemy's spawnId is equal to this spawnersID then remove an enemy count
        if (SpawnID == sID)
        {
            numEnemy--;
        }
    }
    // Enable the spawner based on spawnerID
    public void enableSpawner(int sID)
    {
        if (SpawnID == sID)
        {
            Spawn = true;
        }
    }
    // Disable the spawner based on spawnerID
    public void disableSpawner(int sID)
    {
        if (SpawnID == sID)
        {
            Spawn = false;
        }
    }
    // Returns the Time Till the Next Wave, for a interface, ect.
    public float TimeTillWave
    {
        get
        {
            return timeTillWave;
        }
    }
    // Enable the spawner, useful for trigger events because you don't know the spawner's ID.
    public void enableTrigger()
    {
        Spawn = true;
    }
}
