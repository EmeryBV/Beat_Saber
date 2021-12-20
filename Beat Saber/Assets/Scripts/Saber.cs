using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{

    public LayerMask layer;
    private Vector3 previousPos;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
    void Update()
    {
        RaycastHit hit;
        gameData.multiplicatorChange = true;
        Debug.DrawRay(transform.position, transform.forward, Color.green );
        if (Physics.Raycast(transform.position, transform.TransformDirection( transform.forward ), out hit, 1, layer))
        {
            Debug.Log( hit.transform.tag );
            
            if (hit.transform.gameObject.CompareTag("bomb"))
            {
                hit.transform.gameObject.GetComponent<BombScript>().removePoints();
                Destroy( hit.transform.gameObject );
            }
            
            else if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {

                if( hit.transform.gameObject.CompareTag("blue") || hit.transform.gameObject.CompareTag("red") )
                {
                    AudioSource soundDestruction = GetComponent<AudioSource>();
                    soundDestruction.Play();
                    hit.transform.gameObject.GetComponent<CubeScript>().addPoints();
                }
                
                Destroy(hit.transform.gameObject);

            }
        }

        previousPos = transform.position;
    }
    
}
