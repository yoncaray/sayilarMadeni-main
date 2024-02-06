using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject baslaYazi, baslaBtn, nasilOynanirBtn;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BaslangicRoutine());
    }



    IEnumerator BaslangicRoutine()
    {
        baslaYazi.GetComponent<RectTransform>().DOScale(1, 0.4f).SetEase(Ease.OutBack);
        baslaYazi.GetComponent<CanvasGroup>().DOFade(1, 0.4f);

        yield return new WaitForSeconds(0.5f);

        baslaBtn.GetComponent<RectTransform>().DOScale(1, 0.4f).SetEase(Ease.OutBack);
        baslaBtn.GetComponent<CanvasGroup>().DOFade(1, 0.4f);

       

       
    }


    public void OyunaBasla()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
