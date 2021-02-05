using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Events.Bool;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private EventBool startGameEvent;
    [SerializeField] private Vector3 newSize;
    private Vector3 originalSize;

    [SerializeField] private string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        originalSize = transform.localScale;
        transform.DOScale(newSize, .4f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    public void StartGameClick()
    {
        startGameEvent.Raise(true);
        transform.DOKill();
        gameObject.SetActive(false);
    }

    public void RetryGameClick()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void NextSceneClick()
    {
        // SceneManager.LoadSceneAsync(sceneToLoad);
        StartCoroutine(LoadAsyncOperation());
    }
    
    IEnumerator LoadAsyncOperation()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(sceneToLoad);

        while (gameLevel.progress < 1)
        {
            yield return new WaitForEndOfFrame();
        }
    }
}
