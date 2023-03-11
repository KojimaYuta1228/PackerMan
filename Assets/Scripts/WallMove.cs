using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    [Header("isŠÔŠu"), SerializeField]
    float _interval = 1.0f;
    [Header("Œo‰ßŽžŠÔ"), SerializeField]
    float _elapsed;

    bool _topWallFlag = false;

    void Start()
    {
        
    }

    void Update()
    {
        Transform mytransform = this.transform;
        Vector2 pos = mytransform.position;
        _elapsed += Time.deltaTime;
        if (_elapsed > _interval)
        { 
            _elapsed = 0;
            pos.y -= 0.15f;   
        }
        mytransform.position = pos;
        if (ScoreManager._score /50 == 1 && _topWallFlag == false)
        {
            _topWallFlag = true;
            if(_topWallFlag == true)
            {
                transform.position = new Vector2(0, 5.1f);
               
            }
            
           
        }
       
    }
}
