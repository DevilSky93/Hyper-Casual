using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform retryButton, nextButton;
    [SerializeField] private Transform loseTextDisplay;
    [SerializeField] private Transform winTextDisplay;

    [SerializeField] private Image darkenImg;

    public void DarkenScreen()
    {
        darkenImg.DOFade(.3f, .3f).SetEase(Ease.OutSine);
        StartCoroutine(BrightScreen());
    }

    IEnumerator BrightScreen()
    {
        yield return new WaitForSeconds(1.5f);
        darkenImg.DOFade(0, .3f);
    }
    
    public void GameOver(bool isWin)
    {
        if (!isWin)
        {
            retryButton.gameObject.SetActive(true);
            loseTextDisplay.gameObject.SetActive(true);
            loseTextDisplay.transform.DOLocalMove(Vector3.zero, .5f).SetEase(Ease.OutCubic);
        }
        else
        {
            nextButton.gameObject.SetActive(true);
            winTextDisplay.gameObject.SetActive(true);
            winTextDisplay.transform.DOLocalMove(Vector3.zero, .5f).SetEase(Ease.OutCubic);
        }
    }
}
