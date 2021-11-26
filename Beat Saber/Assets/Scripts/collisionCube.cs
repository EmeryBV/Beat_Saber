using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionCube : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("blue") || other.CompareTag("red") )
        {
            gameData.succesion = 0;
            gameData.life -= 10;
            gameData.multiplierCurrent = 1;
            Destroy(other.gameObject);

        }else if (other.CompareTag("bomb"))
        {
            Destroy(other.gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
