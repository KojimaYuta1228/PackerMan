using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWallMove : MonoBehaviour
{
    [Header("�i�s�Ԋu"), SerializeField]
    float _interval = 1.0f;
    [Header("�o�ߎ���"), SerializeField]
    float _elapsed;

    public int _treshold = 50;

    bool _rightwallFlag = false;
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
            pos.x -= 0.25f;

        }
       
        mytransform.position = pos;
        if (ScoreManager._score / 50 == 1 && _rightwallFlag == false)
        {
            _rightwallFlag = true;

            if (_rightwallFlag == true)
            {
                Debug.Log("RightWall�����Ɉʒu��");
                transform.position = new Vector2(14.47f, -0.26f);
            }
        }
    }
}
