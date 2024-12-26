using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanYaratici : MonoBehaviour
{
    public GameObject dusmanObje;
    float dusmanOlusmaSuresi = 5f;
    void Start()
    {
        Invoke("DusmanYarat", dusmanOlusmaSuresi);
        InvokeRepeating("DusmanSayisindaArtis", 0f, 30f);
    }

    void Update()
    {

    }

    public void DusmanYarat()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject dusman = (GameObject)Instantiate(dusmanObje);
        dusman.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        SonrakiDusmanOlusumSuresi();

    }
    void SonrakiDusmanOlusumSuresi()
    {
        float olusturmaSuresi;
        if (dusmanOlusmaSuresi > 1f)
        {
            olusturmaSuresi = Random.Range(1f, dusmanOlusmaSuresi);
        }
        else
        {
            olusturmaSuresi = 1f;
        }
        Invoke("DusmanYarat", olusturmaSuresi);
    }

    void DusmanSayisindaArtis()
    {
        if (dusmanOlusmaSuresi > 1f)
        {
            dusmanOlusmaSuresi--;
        }
        if (dusmanOlusmaSuresi == 1f)
        {
            CancelInvoke("DusmanSayisindaArtis");
        }
    }
    public void DusmanYaratmayiBaslat()
    {
        Invoke("DusmanYarat", dusmanOlusmaSuresi);
        InvokeRepeating("DusmanSayisindaArtis", 0f, 30f);
    }
    public void DusmanYaratmayiDurdur()
    {
        CancelInvoke("DusmanYarat");
        CancelInvoke("DusmanSayisindaArtis");
    }
}