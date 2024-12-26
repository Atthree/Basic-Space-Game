using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMermi : MonoBehaviour
{
    float hiz;

    void Start()
    {
        hiz = 8f;
    }

    
    void Update()
    {
        Vector2 konum = transform.position;
        konum = new Vector2(konum.x, konum.y+ hiz *Time.deltaTime);
        transform.position = konum;
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DusmanGemi")
        {
            Destroy(gameObject);
        }
    }
}
