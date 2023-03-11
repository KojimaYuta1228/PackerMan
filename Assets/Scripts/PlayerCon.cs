using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerCon : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    [Header("�ړ����x"), SerializeField]
    public static float _speed = 1f;
    [Header("�W�����v��"), SerializeField]
    public float jumpPower = 0.5f;
    [Header("�W�����v��"), SerializeField]
    public int jumpCount = 0;
    [Header("�X�R�A���Z"), SerializeField]
    int _scoreAddItem1;
    [Header("�X�R�A����"), SerializeField]
    int _scoreDecreaseItem1;
    [Header("�v���C���[�X�^�~�i"), SerializeField]
    public static float _playerStamina = 1000;
    [Header("�_�b�V���p���["), SerializeField]
    public float _dashPower = 1.2f;
    [Header("HP�񕜃A�C�e��"), SerializeField]
    int _helthRecoverItem1;
    [Header("HP�����A�C�e��"), SerializeField]
    int _helthDecreaseItem1;
    [Header("�X�s�[�hUP�A�C�e��"), SerializeField]
    float _speedUpItem1;
    [Header("�X�s�[�hDOWN�A�C�e��"), SerializeField]
    float _speedDownItem1;
    [Header("��ԕω�����1"), SerializeField]
    float _stateTime;
    [Header("��ԕω�����2"), SerializeField]
    float _stateTime2;
    [Header("��ԕω�����3"), SerializeField]
    float _stateTime3;
    [Header("��ԕω���������"), SerializeField]
    float _stateLimitTime;
    [Header("sound1"), SerializeField]
    public AudioClip sound1;
    [Header("sound2"), SerializeField]
    public AudioClip sound2;
    [Header("sound3"), SerializeField]
    public AudioClip sound3;
    [Header("sound4"), SerializeField]
    public AudioClip sound4;
    [Header("sound5"), SerializeField]
    public AudioClip sound5;

    bool _stateFlag = false;//speedUpFlag
    bool _stateFlag2 = false;//speedDownFlag
    bool _keyChangeFlag = false;
    bool _staminaFlag = false;

    float _interval = 1.0f;
    float _elapsed;

    
    AudioSource audioSource;

    




    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
       
        PlayerMove();
        PlayerState();
        LoadScene();
        
    }
    private void PlayerState()
    {
        if (transform.position.y < -10)
        {
            transform.position = new Vector2(0, 0);
        }
        if (_stateFlag == true)
        {
            Debug.Log(_stateFlag);
            _stateTime += Time.deltaTime;
            if (_stateTime > _stateLimitTime)
            {
                _speed = 1;
                _stateTime = 0;
                _stateFlag = false;
            }
        }
        if (_stateFlag2 == true)
        {
            _stateTime2 += Time.deltaTime;
            if (_stateTime2 > _stateLimitTime)
            {
                _speed = 3;
                _stateTime2 = 0;
                _stateFlag2 = false;
            }
        }
        if (_keyChangeFlag == true)
        {
            _stateTime3 += Time.deltaTime;

            if (_stateTime3 > _stateLimitTime)
            {
                _stateTime3 = 0;
                _keyChangeFlag = false;
            }
        }
        _elapsed += Time.deltaTime;
        if (_playerStamina < 10)
        {
            _staminaFlag = true;
        }
        else if (_playerStamina >= 1000)
        {
            _staminaFlag = false;
        }
        if (_staminaFlag == true)
        {
            if (_elapsed > _interval && _playerStamina <= 1000)
            {
                _playerStamina += 20;
                _elapsed = 0;
            }
        }
    }
    private void PlayerMove()
    {
        var moveVec = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            moveVec.x = _keyChangeFlag  ? _speed : -_speed;
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveVec.x = _keyChangeFlag ? -_speed : _speed;
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            _rigidbody.AddForce(Vector2.up * jumpPower,ForceMode2D.Impulse);
            jumpCount++;
        }
        if (Input.GetKey(KeyCode.LeftShift)&& _playerStamina > 0)
        {
            moveVec.x *= _dashPower;
            _playerStamina -= 0.1f;
        }
        Debug.Log(moveVec.x);
        _rigidbody.AddForce(moveVec);
        //transform.Translate(_move * _speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //----------------Tag�Ŕ���----------------//
        //Stage�Ƃ̔���
        if (collision.gameObject.CompareTag("Stage"))
        {
            jumpCount = 0;
        }
        //�X�R�A���Z
        if (collision.gameObject.CompareTag("_scoreAddItemNameTag"))
        {
            audioSource.PlayOneShot(sound1);
            Destroy(collision.gameObject);
            ScoreManager._score += _scoreAddItem1;
        }
        //�X�R�A����
        else if (collision.gameObject.CompareTag("_scoreRemoveAddItemNameTag"))
        {
            audioSource.clip = sound2;
            audioSource.PlayOneShot(sound2);
            Destroy(collision.gameObject);
            ScoreManager._score -= _scoreDecreaseItem1;
        }
        //�X�s�[�hUP
        else if (collision.gameObject.CompareTag("_speedUpItemNameTag"))
        {
            audioSource.clip = sound5;
            audioSource.PlayOneShot(sound5);
            Destroy(collision.gameObject);
            _stateFlag = true;
            _speed *= _speedUpItem1;
            StateText._state = ("�X�s�[�hUP��");
            
          
        }
        //�X�s�[�hDOWN
        else if (collision.gameObject.CompareTag("_speedDownItemNameTag"))
        {
            audioSource.clip = sound4;
            audioSource.PlayOneShot(sound4);
            Destroy(collision.gameObject);
            _stateFlag = true;
            _speed *= _speedDownItem1;
            StateText._state = ("�X�s�[�hDOWN��");     
        }
        //Key�̔��]
        else if (collision.gameObject.CompareTag("_keyChangeItem"))
        {
            audioSource.clip = sound3;
            audioSource.PlayOneShot(sound3);
            Destroy (collision.gameObject);
            _keyChangeFlag = true;
            StateText._state = ("������");
        }
        if (collision.gameObject.CompareTag("_topTag"))
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void LoadScene()
    {
   
        if(ScoreManager._score > 100)
        {
            SceneManager.LoadScene("GameClearScene");
        }
    }
}
