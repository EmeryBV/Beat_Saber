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
       
        RunCo();
    }

    private IEnumerator Pulse()
    {
        for ( float i = 10; i <=100;i+=1)
        {
            multiplicator.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        int multiplicatorNumber = gameData.multiplierCurrent;
        multiplicator.text= multiplicatorNumber.ToString();
        for ( float i = 100; i <=10;i-=1)
        {
            multiplicator.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        multiplicator.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void RunCo()
    {
        StartCoroutine(Pulse());

    }
}
