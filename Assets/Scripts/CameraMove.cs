using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("進行間隔"), SerializeField]
    float _interval = 1.0f;
    [Header("経過時間"), SerializeField]
    float _elapsed;
    [Header("ズームスピード"), SerializeField]
    float _zoomSpeed = 1.5f;
    [Header("ズーム最小拡大率"), SerializeField]
    float _zoomMin = 2.0f;
    [Header("ズーム最大拡大率"), SerializeField]
    float _zoomMax = 5.7f;
    [Header("カメラの位置"), SerializeField]
    float _camPosY;


    private Camera _camera;
    bool _camFlag = false;
   
    
    void Start()
    {
        _camera = GetComponent<Camera>();
        
    }

    
    void Update()
    {
        CameraMovement();  
    }
    public void CameraMovement()
    {
        _elapsed += Time.deltaTime;
        
        if (_elapsed > _interval)
        {
            _elapsed = 0;
            if (_zoomMax > 2.6f)
            {
                _zoomMax -= 0.1f;
                _camera.orthographicSize = _zoomMax;
            }
            if (_camPosY > -1.5f)
            {
                _camPosY -= 0.1f;
                transform.position = new Vector3(0, _camPosY, -10);
                //Debug.Log("campos");
            }
        }
        if (ScoreManager._score / 50 == 1 && _camFlag == false)
        {
            Debug.Log("CameraMovement()");
            _camFlag = true;
            if (_camFlag == true)
            {
                //Debug.Log("カメラを元の位置に");
                _camPosY = 0;
                transform.position = new Vector3(0, _camPosY, -10);
                _zoomMax = 5.7f;
                _camera.orthographicSize = _zoomMax;
                
            }
        }
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    _camera.orthographicSize = _zoomMax;
        //    Debug.LogWarning("P");

        //}
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    _camera.orthographicSize = _zoomMin;
        //    Debug.LogWarning("O");
        //}
       
    }
    
}
