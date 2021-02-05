using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Events.Float;
using Lean.Touch;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float activeSpeed;
    [SerializeField] private float swipeSpeed;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject speedParticles;
    // Start is called before the first frame update
    void Start()
    {
        activeSpeed = moveSpeed;
    }

    // Update is called once per frame
    public void OnUpdate(bool isStarted)
    {
        if (isStarted)
        {
            transform.position += Vector3.forward * (activeSpeed * Time.deltaTime);
        }
    }

    public void StartRunning(bool isStarted)
    {
        if (isStarted)
        {
            anim.SetTrigger("Start");
            LeanTouch.OnFingerUpdate += Move;
        }
        else
        {
            LeanTouch.OnFingerUpdate -= Move;
        }
    }

    private void Move(LeanFinger obj)
    {
        var position = transform.position;
        var movement = Vector3.right * (obj.ScreenDelta.x * swipeSpeed);
        var pos = position;
        pos.x =  Mathf.Clamp(position.x+movement.x, -3f, 3f);
        position = pos;
        transform.position = position;
    }

    private void OnDestroy()
    {
        transform.DOKill();
        LeanTouch.OnFingerUpdate -= Move;
    }

    public void GameOver(bool isGameOver)
    {
        if (!isGameOver)
        {
            anim.SetTrigger("Die");
            LeanTouch.OnFingerUpdate -= Move;
        }
        else
        {
            anim.SetTrigger("Win");
            LeanTouch.OnFingerUpdate -= Move;
            transform.DORotate(new Vector3(0, 180f, 0), .3f).SetEase(Ease.Linear);
        }
    }

    public void AddCurrentSpeed(float newSpeed)
    {
        speedParticles.SetActive(true);
        activeSpeed = moveSpeed;
        activeSpeed *= 1.1f;
        StartCoroutine(ChangeSpeed());
    }

    IEnumerator ChangeSpeed()
    {
        yield return new WaitForSeconds(1.5f);
        activeSpeed = moveSpeed;
        speedParticles.SetActive(false);
    }

    public void SlowCurrentSpeed(float speed)
    {
        activeSpeed = moveSpeed;
        activeSpeed *= .9f;
    }
    
}
