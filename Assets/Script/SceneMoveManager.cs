using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneMoveManager : MonoBehaviour
{
    [SerializeField] GameObject screen;
    [SerializeField] Image progressImage;

    public void SceneMove()
    {
        StartCoroutine(SceneLoad(1));
    }

    IEnumerator SceneLoad(int index)
    {
        screen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        yield return null;
    }
}

