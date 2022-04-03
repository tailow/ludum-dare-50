using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wavespawning : MonoBehaviour
{

    public GameObject Hammerman;
    GameObject player;
    AudioSource aS;

    float runTime;
    int wave = 1;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        aS = GetComponent<AudioSource>();
    }


    void Update()
    {
        runTime += Time.deltaTime;
        
        if (runTime > 10 * wave)
        {
            for(int i = 0; i < 2 + (2 * wave); i++)
            {
                Vector3 randomPosition = player.transform.position + Random.insideUnitSphere * Random.Range(80, 150);
                if (randomPosition.y < 3) { randomPosition.y = 3; }
                Instantiate(Hammerman, randomPosition, Quaternion.identity);
                Debug.Log(randomPosition.ToString());
            }

            aS.Play();
            wave += 1;

        }
    }
}
