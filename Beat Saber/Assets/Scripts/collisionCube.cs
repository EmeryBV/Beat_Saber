using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionCube : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "blue" || other.tag == "red")
        {
            Destroy(other.gameObject);
            gameData.succesion = 0;
            gameData.life -= 10;
            gameData.multiplierCurrent = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
