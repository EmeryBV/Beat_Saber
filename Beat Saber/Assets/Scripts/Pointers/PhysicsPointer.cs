using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PhysicsPointer : MonoBehaviour
{
    public float defautLenght = 3.0f;

    private LineRenderer lineRenderer = null;
    
    private AudioSource audio;
    public AudioClip cursorOnButton;
    public AudioClip soundStartButton;
    private string predHit="";
    private void Awake()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        updateLenght();
    }

    private void updateLenght()
    {
        lineRenderer.SetPosition(0, transform.parent.position);
       
        lineRenderer.SetPosition(1,CalculateEnd());
    }
    private Vector3 CalculateEnd()
    {
        RaycastHit hit = CreateForwardRaycast();
        Vector3 endPosition = DefaultEnd(defautLenght);

        if (hit.collider)
        {
            
            endPosition = hit.point;
            bool putButton = false;
            if (OVRInput.Get(OVRInput.Button.One)&& !putButton)
            {
                if(hit.collider.CompareTag("play"))
                {
                    StartCoroutine(LoadSceneAsync("Game"));

                }else if (hit.collider.CompareTag("highscore"))
                {
                    GameObject mainMenuGo = GameObject.Find("MainMenuButton");
                    foreach (Transform child in mainMenuGo.transform)
                    {
                        child.gameObject.SetActive(false);
                    }
                    
                    GameObject highscoreGo = GameObject.Find("Highscore");
                    foreach (Transform child in highscoreGo.transform)
                    {
                        child.gameObject.SetActive(true);
                    }
                    playSound(hit);
                }
                else if (hit.collider.CompareTag("return"))
                {
                    GameObject mainMenuGo = GameObject.Find("MainMenuButton");
                    foreach (Transform child in mainMenuGo.transform)
                    {
                        child.gameObject.SetActive(true);
                    }
                    
                    GameObject highscoreGo = GameObject.Find("Highscore");
                    foreach (Transform child in highscoreGo.transform)
                    {
                        child.gameObject.SetActive(false);
                    }
                    
                    playSound(hit);
                }
                else if (hit.collider.CompareTag("exit"))
                {
                    playSound(hit);
                    Application.Quit();
                } 
            }

           
        }
        
       
        return endPosition;
    }

    public void playSound(RaycastHit hit)
    {
        Debug.Log( "tag = " + hit);
        Debug.Log( "predHit = " + predHit);
      
        if (hit.collider.tag != predHit)
        {
            audio.PlayOneShot(cursorOnButton);
            predHit = hit.collider.tag;
        }
    }
    private IEnumerator LoadSceneAsync (string levelName)
    { 
        audio.PlayOneShot(soundStartButton);
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        yield return null;
        // SceneManager.UnloadSceneAsync("MainMenu");
    }
    private RaycastHit CreateForwardRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray( transform.parent.position,  transform.parent.forward);

        Physics.Raycast(ray, out hit, defautLenght);
        return hit;
    }

    private Vector3 DefaultEnd(float lenght)
    {
        return  transform.parent.position = ( transform.parent.forward * lenght);
    }
}