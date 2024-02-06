using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ipRenderer : MonoBehaviour
{
    LineRenderer lineRenderer;

    float cizgi_Genisligi = 0.05f;

    [SerializeField]
    Transform baslangicTransfrom;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.startWidth = cizgi_Genisligi;
    }

    public void ipGosterFNC(Vector3 hedefPos,bool enableRenderer)
    {
        if(enableRenderer)
        {
            if(!lineRenderer.enabled)
            {
                lineRenderer.enabled = true;
            }
            lineRenderer.positionCount = 2;
        } else
        {
            lineRenderer.positionCount = 0;

            if(lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }
        }

        if(enableRenderer)
        {
            Vector3 temp = baslangicTransfrom.position;
            temp.z = -3f;

            baslangicTransfrom.position = temp;


            temp = hedefPos;
            temp.z = 0f;
            hedefPos = temp;

            lineRenderer.SetPosition(0, baslangicTransfrom.position);
            lineRenderer.SetPosition(1, hedefPos);
        }



    }
}
