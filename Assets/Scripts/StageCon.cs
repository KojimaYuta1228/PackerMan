using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCon : MonoBehaviour
{
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("_scoreAddItemNameTag") || collision.gameObject.CompareTag("_scoreRemoveAddItemNameTag") ||
            collision.gameObject.CompareTag("_speedUpItemNameTag") || collision.gameObject.CompareTag("_speedDownItemNameTag")
            || collision.gameObject.CompareTag("_keyChangeItem") )
        {
            Destroy(collision.gameObject,2f);
        }
    }

}
