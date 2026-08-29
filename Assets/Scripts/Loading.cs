using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Loading : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    private float waitSecond = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("hi");
        if (waitSecond > 0f)
        {
            waitSecond -= Time.deltaTime;
            print(waitSecond);
        }
        else
        {
            StartCoroutine(LoadNewScene());
            print("too");
        }
    }

    private IEnumerator LoadNewScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("scene01");

        print(operation.progress);
        while (!operation.isDone)
        {
            slider.value = operation.progress / 0.9f;
            yield return null;
        }
    }
}
