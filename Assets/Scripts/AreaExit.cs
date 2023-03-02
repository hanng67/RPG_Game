using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField]
    private string areaToLoad;

    [SerializeField]
    private string areaTransitionName;

    [SerializeField]
    private AreaEntrance areaEntrance;

    [SerializeField]
    private float waitToLoad;

    private bool shouldLoadAfterFade;

    // Start is called before the first frame update
    void Start()
    {
        areaEntrance.AreaEntranceName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shouldLoadAfterFade = true;
            GameManager.Instance.fadingBetweenAreas = true;
            UIFade.Instance.FadeToBlack();

            PlayerController.Instance.AreaTransistionName = areaTransitionName;
        }
    }
}
