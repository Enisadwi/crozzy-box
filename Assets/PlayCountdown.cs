using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PlayCountdown : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text tmpText;
    [SerializeField] AudioSource audioSource;
    public UnityEvent OnStart;
    public UnityEvent OnEnd;

   private void Start()
    {
        OnStart.Invoke();
        var sequence = DOTween.Sequence();
        tmpText.transform.localScale = Vector3.zero;
        tmpText.text="3";

        sequence.Append(tmpText.transform.DOScale(
            Vector3.one,1).OnComplete(()=>
            {
                audioSource.Play();
                tmpText.transform.localScale=Vector3.zero;
                tmpText.text="2";

            }));
         sequence.Append(tmpText.transform.DOScale(
            Vector3.one,1).OnComplete(()=>
           {
            audioSource.Play();
                tmpText.transform.localScale=Vector3.zero;
                tmpText.text="1";

            }));
        
        sequence.Append(tmpText.transform.DOScale(
            Vector3.one,1).OnComplete(()=>
           {
            audioSource.Play();
                tmpText.transform.localScale=Vector3.zero;
                tmpText.text="Go!";

            }));
        
         sequence.Append(tmpText.transform.DOScale(
            Vector3.one,1).OnComplete(()=> 
           {
            audioSource.Play();
                tmpText.transform.localScale=Vector3.zero;
                tmpText.text="Go";
                OnEnd.Invoke();
            }));


    }

  
}
