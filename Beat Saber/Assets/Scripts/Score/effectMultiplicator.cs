using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class effectMultiplicator : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(gameData.multiplicatorChange){
 		RunCo();
       
        }
       
    }

    private IEnumerator Pulse()
    {
        Text multiplicator = GetComponent<Text>();
        
        multiplicator.color= new Color(1f, 1f - gameData.multiplierCurrent*0.10f, 1f-gameData.multiplierCurrent*0.10f, 1.0f); 
        for ( float i = 1.0f; i <=1.4f; i+=0.05f)
        {
            multiplicator.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        int multiplicatorNumber = gameData.multiplierCurrent;
        multiplicator.text= "x" + multiplicatorNumber.ToString();
        for ( float i = 1.4f; i <=1.0f; i-=0.05f)
        {
            multiplicator.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        multiplicator.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        gameData.multiplicatorChange = false;
        // gameData.multiplierCurrent += 1;
        yield return new WaitForSecondsRealtime(1);
    }

    public void RunCo()
    {
        StartCoroutine(Pulse());

    }
}
