using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject[] cubes ;
    public Transform[] points ;
    public float beat ;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        float tempo = (60 / beat) * 2;
        if (timer > tempo)
        {
            GameObject cube =Instantiate(cubes[Random.Range(0, cubes.Length)], points[Random.Range(0, points.Length)]);
            cube.transform.localPosition = Vector3.zero;
            if( ! cube.CompareTag( "bomb" ) )
                cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
            
            timer -= tempo;
        }
            
        timer += Time.deltaTime;
    }
}
