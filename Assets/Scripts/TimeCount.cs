using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCount : MonoBehaviour
{
    [Header("Timer"), SerializeField]
    float _timeCount;
    PlayerCon _playerCon;
    public Text CountText;
    [Header("StartCount"), SerializeField]
    float CountdownTime = 3.0f;
    int _count;
    void Start()
    {
        
    }

    void Update()
    {
        _timeCount -= Time.deltaTime;

        GetComponent<Text>().text = _timeCount.ToString("F2");

        if( _timeCount < 0f)
        {
            Time.timeScale = 0;
            _playerCon.transform.position = Vector2.zero;
            SceneManager.LoadScene("GameOverScene");
        }
        
        
    }
}
