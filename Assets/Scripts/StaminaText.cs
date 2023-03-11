using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StaminaText : MonoBehaviour
{
    static public string _state;
    Text _stateText;

    void Start()
    {
        _stateText = GetComponent<Text>();
    }


    void Update()
    {
        _stateText.text = "スタミナ:"+PlayerCon._playerStamina.ToString("F2");
    }
}
