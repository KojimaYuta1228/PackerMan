using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    static public int _score = 0;
    [Header("�X�R�A��_"), SerializeField]
    public int _treshold = 50;
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }


    void Update()
    {
        scoreText.text = "SCORE :" + _score;
    }
}
