using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Events.Bool;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    [SerializeField] private float gauge;
    [SerializeField] private float valueUse;

    private float currentGauge;

    public float CurrentGauge => currentGauge;

    [SerializeField] private Slider gaugeUI;

    [SerializeField] private Image fillColor;
    [SerializeField] private Material blue;
    [SerializeField] private Material red;
    [SerializeField] private float invincibleLength;
    private float invincibleLengthCounter;
    [SerializeField] private Camera camera;
    [SerializeField]
    private EventBool gameOverEvent, stopGameEvent;
    // Start is called before the first frame update
    void Start()
    {
        currentGauge = gauge/2;
        gaugeUI.maxValue = gauge;
        gaugeUI.value = currentGauge;
    }

    // Update is called once per frame
    public void OnUpdate(bool isStarted)
    {
        if (isStarted)
        {
            currentGauge -= valueUse * Time.deltaTime;
            gaugeUI.value -= valueUse * Time.deltaTime;
            if (currentGauge <= 0)
            {
                gameOverEvent.Raise(false);
                stopGameEvent.Raise(false);
            }

            if (invincibleLengthCounter > 0)
            {
                invincibleLengthCounter -= Time.deltaTime;
            }
        }
    }

    public void AddGauge(float value)
    {
        currentGauge += value;
        // gaugeUI.value = currentGauge;
        DOTween.To(() => camera.fieldOfView, x => camera.fieldOfView = x, 70f, .2f).SetEase(Ease.OutSine).OnStart(() =>
        {
            StartCoroutine(ChangeFov());
        });
        
        DOTween.To(() => gaugeUI.value, x => gaugeUI.value = x, currentGauge, .6f).SetEase(Ease.OutSine);
    }

    IEnumerator ChangeFov()
    {
        yield return new WaitForSeconds(1.5f);
        DOTween.To(() => camera.fieldOfView, x => camera.fieldOfView = x, 60f, .2f).SetEase(Ease.OutSine);
    }

    public void UseGauge(float value)
    {
        currentGauge -= value;

        DOTween.To(() => gaugeUI.value, x => gaugeUI.value = x, currentGauge, .6f).SetEase(Ease.OutSine);
    }

    public void HitPlayer(float dmg)
    {
        if (invincibleLengthCounter  <= 0)
        {
            fillColor.color = red.color;
            currentGauge -= dmg;
            invincibleLengthCounter = invincibleLength;
            DOTween.To(() => gaugeUI.value, x => gaugeUI.value = x, currentGauge, .6f).SetEase(Ease.OutSine).OnComplete(
                () =>
                {
                    fillColor.color = blue.color;
                }); 
        }
    }

    public void GameOver(bool isWin)
    {
        if (!isWin)
        {
            currentGauge = 0;
            fillColor.color = red.color;

            DOTween.To(() => gaugeUI.value, x => gaugeUI.value = x, currentGauge, .6f).SetEase(Ease.OutSine);
        }
    }
}