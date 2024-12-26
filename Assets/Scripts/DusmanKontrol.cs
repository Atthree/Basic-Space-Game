using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanKontrol : MonoBehaviour
{
    public GameObject Patlama;
    float hiz;
    GameObject skoreTextObje;
    void Start()
    {
        hiz = 2f;
        skoreTextObje = GameObject.FindGameObjectWithTag("SkorTxtTag");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 konum = transform.position;
        konum = new Vector2(konum.x, konum.y - hiz * Time.deltaTime);
        transform.position = konum;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "PlayerMermi")
        {
            PatlamaAnimasyonu();            
            Destroy(gameObject);
            if (skoreTextObje != null) 
            {
                skoreTextObje.GetComponent<OyunSkor>().Skor += 100;
            }            
        }
    }
    void PatlamaAnimasyonu()
    {
        GameObject patlama = (GameObject)Instantiate(Patlama);
        patlama.transform.position = transform.position;
    }
}
