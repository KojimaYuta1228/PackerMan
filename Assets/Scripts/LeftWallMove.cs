using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWallMove : MonoBehaviour
{
    [Header("isŠÔŠu"), SerializeField]
    float _interval = 1.0f;
    [Header("Œo‰ßŽžŠÔ"), SerializeField]
    float _elapsed;

    bool _leftWallFlag = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform mytransform = this.transform;
        Vector2 pos = mytransform.position;
        _elapsed += Time.deltaTime;
        
        if (_elapsed > _interval)
        {
            _elapsed = 0;
            pos.x += 0.25f;
        }
        mytransform.position = pos;
        if (ScoreManager._score / 50 == 1 && _leftWallFlag == false)
        {
            _leftWallFlag = true;
            if (_leftWallFlag == true)
            {

                transform.position = new Vector2(-14.47f, -0.26f);
                
                Debug.Log("bbbbbbbbbbb");
            }


        }
    }
}

