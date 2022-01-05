using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionCube : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("blue") || other.CompareTag("red") )
        {
            PlaySoundInterval(0.0f,1.0f);
            gameData.succesion = 0;
            gameData.life -= 10;
            if(gameData.multiplierCurrent!=1)
            gameData.multiplierCurrent /= 2;
            Destroy(other.gameObject);

        }else if (other.CompareTag("bomb"))
        {
            Destroy(other.gameObject);

        }
    }

    // Update is called once per frame
    
    void PlaySoundInterval(float fromSeconds, float toSeconds)
    {
        AudioSource errorSound = GetComponent<AudioSource>();
        errorSound.time = fromSeconds;
        errorSound.Play();
        errorSound.SetScheduledEndTime(AudioSettings.dspTime+(toSeconds-fromSeconds));
    }


}
