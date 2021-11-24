using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{

    public LayerMask layer;
    public ParticleSystem ps;
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
        // Debug.DrawRay(transform.position, transform.TransformDirection(transform.forward)*1,Color.green );
        if (Physics.Raycast(transform.position, transform.TransformDirection( transform.forward ), out hit, 1, layer))
        {
            if (Vector3.Angle(transform.position-previousPos, hit.transform.up) > 130)
            {
                Debug.Log("hey");
                GameObject go = Instantiate(ps.gameObject, hit.transform.position, Quaternion.identity );
                ParticleSystem.EmissionModule pt = go.GetComponent<ParticleSystem>().emission;
                pt.enabled = true;
                Destroy(go, 5.0f);
                Destroy(hit.transform.gameObject);
                
                if (gameData.succesion >= 10) 
                    gameData.multiplierCurrent = gameData.succesion / 10;
                
                gameData.succesion += 1;
                gameData.score += 10 * gameData.multiplierCurrent;
            }
        }

        previousPos = transform.position;
    }
    
}
