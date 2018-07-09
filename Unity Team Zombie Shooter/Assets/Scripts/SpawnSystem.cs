using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour {

    //Everything is set to public for testing purposes
    //totalZombies per wave will be (5 * wave), 5 more zombies will be added each wave. - change this later if needed

    public GameObject zombiePrefab; //Single prefab for the zombies, rewrite the code if we would use different zombie prefabs
    public GameObject Player;

    public int wave = 0; //wave number
    public int totalZombies; //total zombies in the current wave
    public int aliveZombies; //alive zombiesi in the current wave

    public bool spawnEnable = true; //set true if game is ready to spawn, turn off while spawning.

	// Use this for initialization
	void Start ()
    {
        //Spawn first wave of zombies
        wave = 1;
        Spawn();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Spawn()
    {
        if(spawnEnable == true)
        {
            float randomX;
            float randomZ;

            spawnEnable = false; //Set spawn to false during spawning so it wont be triggered multiple times
            totalZombies = wave * 5; //Add the right amount of zombies each spawn round

            for (int i = 0; i < totalZombies; i++)
            {
                /*This can definitely be done in a better way*/
                //This will give the zombies different locations for all of them
                do
                {
                    randomX = Random.Range(-10.0f, 10.0f); //change this for maximum length
                    randomZ = Random.Range(-10.0f, 10.0f);

                    //eliminates every position 5 feet from the player
                    if ((randomX + Player.gameObject.transform.position.x > 5.0f || randomX < -5.0f) && (randomZ + Player.gameObject.transform.position.y > 5.0f || randomZ < -5.0f)) //change this for minimum length
                    {
                        break;
                    }
                } while (true);

                randomX = randomX + Player.gameObject.transform.position.x;
                randomZ = randomZ + Player.gameObject.transform.position.y;
                Instantiate(zombiePrefab, new Vector3(randomX, 1, randomZ), Quaternion.identity);

                Debug.Log("Spawn at X: " + randomX + " and Y: " + randomZ);
            }
            Debug.Log("Spawning complete");
            spawnEnable = true;
        }
    }

}
