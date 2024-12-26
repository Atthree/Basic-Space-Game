using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float hiz;
    public GameObject mermiPrefab;
    public GameObject mermiKonumSol;
    public GameObject mermiKonumSag;
    public GameObject Patlama;
    public GameObject oyunYoneticisiObje;

    public Text CanText;
    const int MaxCan = 3;
    int canSayisi;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject mermi1 = (GameObject)Instantiate(mermiPrefab);
            mermi1.transform.position = mermiKonumSol.transform.position;
            GameObject mermi2 = (GameObject)Instantiate(mermiPrefab);
            mermi2.transform.position = mermiKonumSag.transform.position;

        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 yon = new Vector2(x, y).normalized;
        Hareket(yon);
    }

    void Hareket(Vector2 yon)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y - 0.285f;

        Vector2 konum = transform.position;

        konum += yon * hiz * Time.deltaTime;

        konum.x = Mathf.Clamp(konum.x, min.x, max.x);
        konum.y = Mathf.Clamp(konum.y, min.y, max.y);

        transform.position = konum;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DusmanGemi" || collision.tag == "DusmanMermi")
        {
            canSayisi--;
            CanText.text = canSayisi.ToString();
            PatlamaAnimasyonu();

            if (canSayisi == 0)
            {
                oyunYoneticisiObje.GetComponent<OyunYoneticisi>().OyunDurumunuAyarlar(OyunYoneticisi.OyunYoneticisiDurumu.OyunSonu);
                Destroy(gameObject);
            }
        }
    }
    void PatlamaAnimasyonu()
    {
        GameObject patlama = (GameObject)Instantiate(Patlama);
        patlama.transform.position = transform.position;
    }
    public void ilkDurum()
    {
        canSayisi = MaxCan;
        CanText.text = canSayisi.ToString();
        transform.position = new Vector2(0, 0);
        gameObject.SetActive(true);
    }
}