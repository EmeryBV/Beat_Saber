using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class musicScript : MonoBehaviour
{
    private AudioSource music;

    private float duration;
    
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        duration = music.clip.length ;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(music.time);
        if (duration-5 <= music.time)
        {
            gameData.scores.Add(gameData.score);
            Save.save();
            StartCoroutine(LoadSceneAsync("MainMenu"));
        }
    }

    public void saveScore()
    {
        
    }
    
    private IEnumerator LoadSceneAsync (string levelName)
    {
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        yield return null;
    }
}
