using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject uiMgr;

    [SerializeField]
    private GameObject gameMan;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController.Instance == null)
        {
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.Instance = clone;
        }

        if (UIMgr.Instance == null)
        {
            UIMgr.Instance = Instantiate(uiMgr).GetComponent<UIMgr>();
        }

        if(GameManager.Instance == null)
        {
            GameManager.Instance =  Instantiate(gameMan).GetComponent<GameManager>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
