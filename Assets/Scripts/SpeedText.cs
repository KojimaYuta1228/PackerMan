using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedText : MonoBehaviour
{
    static public string _state;
    Text _stateText;

    void Start()
    {
        _stateText = GetComponent<Text>();
    }


    void Update()
    {
        _stateText.text = "スピード:" + PlayerCon._speed.ToString("F2");
    }
}
