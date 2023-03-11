using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStartButton : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        TimeStart();
    }
    public void TimeStart()
    {
        Time.timeScale = 1.0f;
    }
}
