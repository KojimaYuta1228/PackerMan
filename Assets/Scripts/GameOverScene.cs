using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        LoadReStart();
    }
    void LoadReStart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ScoreManager._score = 0;
            PlayerCon._playerStamina = 1000;
            audioSource.PlayOneShot(sound1);
            SceneManager.LoadScene("GameScene");
        }
    }
}
