using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KancaHareketController : MonoBehaviour
{
    [SerializeField]
    float min_Z = -70f, max_Z = 70f;

    [SerializeField]
    float donusHizi = 8f;

    float donusAcisi;
    bool sagaDonsunmu;
    bool donebilirmi;


  
   public float inmeHizi = 4f;

    float baslangicInmeHizi;

    [SerializeField]
    float min_Y = -2.5f;

    float baslangicY;

    bool asagiGitsinmi;

    ipRenderer ipRendererClass;

    SesManager sesManager;
    GameManager gameManager;
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
        ipRendererClass = GetComponent<ipRenderer>();
        sesManager = Object.FindObjectOfType<SesManager>();
    }

    void Start()
    {
        baslangicY = transform.position.y;
        baslangicInmeHizi = inmeHizi;


        donebilirmi = true;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        MouseBasildi();
        KancaHareketi();
    }

    void Rotate()
    {
        if (gameManager.oyunBittimi)
            return;

        if (!donebilirmi)
            return;


        if(sagaDonsunmu)
        {
            donusAcisi += donusHizi * Time.deltaTime;
        } else
        {
            donusAcisi -= donusHizi * Time.deltaTime;
        }


        transform.rotation = Quaternion.AngleAxis(donusAcisi, Vector3.forward);


        if (donusAcisi >= max_Z)
        {
            sagaDonsunmu = false;
        } else if(donusAcisi<=min_Z)
        {
            sagaDonsunmu = true;
        }
            

    }


    void MouseBasildi()
    {
        if(Input.GetMouseButtonDown(0) && !gameManager.oyunBittimi)
        {
            if(donebilirmi)
            {

                sesManager.KancaSesiCikar(true);
                donebilirmi = false;
                asagiGitsinmi = true;
            }
        }
    }

    void KancaHareketi()
    {
        if (gameManager.oyunBittimi)
            return;

        if (donebilirmi)
            return;

        if(!donebilirmi)
        {

            Vector3 temp = transform.position;

            if(asagiGitsinmi)
            {
                temp -= transform.up * Time.deltaTime * inmeHizi;
            } else
            {
                temp += transform.up * Time.deltaTime * inmeHizi;
            }

            transform.position = temp;

            if(temp.y<=min_Y)
            {
                asagiGitsinmi = false;
                sesManager.KancaSesiCikar(false);
            }

            if(temp.y>=baslangicY)
            {
                donebilirmi = true;
                inmeHizi = baslangicInmeHizi;

                ipRendererClass.ipGosterFNC(temp, false);
              
            }

            ipRendererClass.ipGosterFNC(temp, true);
        }
    }

    public void KancaYukariDonsun()
    {
        asagiGitsinmi = false;
    }
}
