using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }     
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Ending_Bad")
        {
            instance.GetComponent<AudioSource>().Pause();
        }

        if(SceneManager.GetActiveScene().name == "Ending_Fairy")
        {
            instance.GetComponent<AudioSource>().Pause();
        }

        if(SceneManager.GetActiveScene().name == "RoomScene")
        {
            instance.GetComponent<AudioSource>().Pause();
        }

        if(SceneManager.GetActiveScene().name == "Talk_Egg")
        {
            if (!instance.GetComponent<AudioSource>().isPlaying)
            {
                instance.GetComponent<AudioSource>().UnPause();
            }

        }

        if (SceneManager.GetActiveScene().name == "Ending_True")
        {
            if (!instance.GetComponent<AudioSource>().isPlaying)
            {
                instance.GetComponent<AudioSource>().UnPause();
            }

        }


    }
}
