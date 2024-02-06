using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadenciAnimasyonController : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void DurmaAnimasyonu()
    {
        anim.Play("durma");
    }

    public void IpSarmaAnimasyonu()
    {
        anim.Play("ipSarma");
    }
}
