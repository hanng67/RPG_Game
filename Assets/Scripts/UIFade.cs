using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public static UIFade Instance;

    [SerializeField] private Image fadeScene;
    [SerializeField] private float fadeSpeed;

    private bool shouldFadeToBlack;
    private bool shouldFadeFromBlack;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScene.color = new Color(fadeScene.color.r, fadeScene.color.g, fadeScene.color.b, 
                                        Mathf.MoveTowards(fadeScene.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(fadeScene.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            fadeScene.color = new Color(fadeScene.color.r, fadeScene.color.g, fadeScene.color.b,
                                        Mathf.MoveTowards(fadeScene.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScene.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }
}
