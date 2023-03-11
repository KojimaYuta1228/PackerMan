using UnityEngine;


public class Spawner : MonoBehaviour
{
    [Header("生成間隔"), SerializeField]
    float _interval = 1.0f;
    [Header("生成確立"), SerializeField]
    static float _probability = 1.0f;
    [Header("生成上限"), SerializeField]
    int _limitNum;
    [Header("生成オブジェクト"),SerializeField]
    private GameObject _original = null;
    [Header("生成オブジェクト2"), SerializeField]
    private GameObject _original2 = null;
    [Header("生成オブジェクト5"), SerializeField]
    private GameObject _original5 = null;
    [Header("生成オブジェクト6"), SerializeField]
    private GameObject _original6 = null;
    [Header("生成オブジェクト7"), SerializeField]
    private GameObject _original7 = null;
    [Header("生存時間"), SerializeField]
    float _liveTime =0;

    private GameObject item = null;



    private float _elapsed;//経過時間

     Rigidbody2D _rb2d;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _elapsed += Time.deltaTime;

        if (_elapsed > _interval)
        {
            _elapsed = 0;

            //生成上限
            if (transform.childCount >= _limitNum) { return; }

            float Calc = Random.value;
            Debug.Log(Calc);
            //生成確立
            if (Calc < 0.65)
            {
                //AddPoint
                Debug.Log("_original1生成");
                item = Instantiate(_original.gameObject);
                ItemState();
            }
            else if (Calc >= 0.65 && Calc < 0.8)
            {
                //DecreasePoint
                Debug.Log("_original2生成");
                item = Instantiate(_original2.gameObject);
                ItemState();
            }
            else if (Calc >= 0.8 && Calc < 0.85)
            {
                //SpeedUp
                Debug.Log("_original5生成");
                item = Instantiate(_original5.gameObject);
                ItemState();
            }
            else if (Calc >= 0.85 && Calc < 0.9)
            {
                //SpeedDown
                Debug.Log("_original6生成");
                item = Instantiate(_original6.gameObject);
                ItemState();
            }
            else if (Calc >= 0.9)
            {
                //KeyChange
                Debug.Log("_original7生成");
                item = Instantiate(_original7.gameObject);
                ItemState();
            }
        }      
    }

    void ItemState()
    {
       // item.transform.SetParent(transform, false);
       _liveTime += Time.deltaTime;
        var x = Random.Range(-8, 8);
        var y = Random.Range(3, 10);
        _rb2d = item.GetComponent<Rigidbody2D>();
        _rb2d.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
        if(_liveTime > 2.0f)
        {
            Destroy(gameObject);
            Debug.Log("destory");
        }

    }
    
}
