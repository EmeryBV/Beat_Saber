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
        // 
        // Debug.Log(Physics.Raycast(transform.position, transform.forward, out hit, 100, layer));
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10, layer))
        {
            Debug.Log("here");
            if (Vector3.Angle(transform.position-previousPos, hit.transform.up) > 130)
            {
                Destroy(hit.transform.gameObject);
                if (gameData.succesion >= 10) gameData.multiplierCurrent = gameData.succesion / 10;
                gameData.succesion += 1;
                gameData.score += 10 * gameData.multiplierCurrent;
            }
        }

        previousPos = transform.position;
    }
}
