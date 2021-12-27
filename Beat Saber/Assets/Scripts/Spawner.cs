using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject[] cubes ;
    public Transform[] points ;
    public float beat ;
    private float timer;
    private int latestSpawnPoint = -1;
    private float tempo;

    private int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        tempo = (60f / beat) * 1.25f;

    }

    void create( int cubeType, int spawn )
    {
        GameObject cube =Instantiate(cubes[cubeType], points[spawn]);
        cube.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {   
        int spawnPoint = Random.Range(0, points.Length);
        while( spawnPoint == latestSpawnPoint )
            spawnPoint = Random.Range(0, points.Length);
        if (timer > tempo)
        {          
            GameObject cube ;

            if (count % 20 != 0)
            {
                cube = Instantiate(cubes[Random.Range(0, 2)], points[spawnPoint]);
            }
            else
            {
                cube =Instantiate(cubes[2], points[spawnPoint]);

            }
            cube.transform.localPosition = Vector3.zero;
            
            if( ! cube.CompareTag( "bomb" ) )
                if( spawnPoint < points.Length/2 )
                    cube.transform.Rotate(transform.forward, -45 * Random.Range(0, 5));
                else
                    cube.transform.Rotate(transform.forward, 45 * Random.Range(0, 5));
            
            timer -= tempo;
            latestSpawnPoint = spawnPoint;
            count++;
        }
        
        timer += Time.deltaTime;
    }
}
