using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{   
    public ParticleSystem ps;
    public Material color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward* 2;


    }

    public void addPoints()
    {
        
        if (gameData.succesion >= 5) 
            gameData.multiplierCurrent = gameData.succesion / 5;
                
        gameData.succesion += 1;
        gameData.score += 10 * gameData.multiplierCurrent;
        
        showParticles();
    }
    void showParticles()
    {
        GameObject go = Instantiate(ps.gameObject, transform.position, Quaternion.identity);
        ParticleSystem.EmissionModule pt = go.GetComponent<ParticleSystem>().emission;
        ParticleSystemRenderer psRenderer = go.GetComponent<ParticleSystemRenderer>();

        psRenderer.material = color;
        
     
        
        pt.enabled = true;
        Destroy(go, 5.0f);
    }

    private void OnDestroy()
    {

    }
}
