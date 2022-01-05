using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Saber : MonoBehaviour
{

    public LayerMask layer;
    private Vector3 previousPos;

    public AudioClip explosion;
    public AudioClip[] hitSound;
    public AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
        audio.GetComponent<AudioSource>();
    }
    // Update is called once per frame                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
    void Update()
    {

        RaycastHit hit;
        gameData.multiplicatorChange = true;
        Debug.DrawRay(transform.position, transform.forward, Color.green);

        if (Physics.Raycast(transform.position, transform.TransformDirection(transform.forward), out hit, 1, layer))
        {

            // Debug.Log(hit.transform.tag);
            if (hit.transform.gameObject.CompareTag("bomb"))
            {
                PlaySoundInterval(explosion,0.0f,0.2f);
                hit.transform.gameObject.GetComponent<BombScript>().removePoints();
                    Destroy(hit.transform.gameObject);
                }

                else if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
                {
                   
                    if (hit.transform.gameObject.CompareTag("blue") || hit.transform.gameObject.CompareTag("red"))
                    {
                        audio.PlayOneShot(hitSound[Random.Range(0,hitSound.Length-1)]);
                        hit.transform.gameObject.GetComponent<CubeScript>().addPoints();

                    }
                    Destroy(hit.transform.gameObject);
                }
            }

            previousPos = transform.position;
        }
    
    
    void PlaySoundInterval(AudioClip clip,float fromSeconds, float toSeconds)
    {
        
        audio.time = fromSeconds;
        audio.PlayOneShot(clip);
        audio.SetScheduledEndTime(AudioSettings.dspTime+(toSeconds-fromSeconds));
    }
}
