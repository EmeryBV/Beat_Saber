using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class effectMultiplicator : MonoBehaviour
{
    public Text multiplicator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(gameData.multiplicatorChange)
        RunCo();
    }

    private IEnumerator Pulse()
    {
        for ( float i = 1.0f; i <=1.4f; i+=0.05f)
        {
            multiplicator.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        int multiplicatorNumber = gameData.multiplierCurrent;
        multiplicator.text= multiplicatorNumber.ToString();
        for ( float i = 1.4f; i <=1.0f; i-=0.05f)
        {
            multiplicator.rectTransform.localScale = new Vector3(i, i, i);
            // Debug.Log("here" +i );
            yield return new WaitForEndOfFrame();
        }
        multiplicator.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        gameData.multiplicatorChange = false;
    }

    public void RunCo()
    {
        StartCoroutine(Pulse());

    }
}
