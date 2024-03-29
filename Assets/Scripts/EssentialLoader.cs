﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialLoader : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject uiMgr;
    [SerializeField] private GameObject gameMan;
    [SerializeField] private GameObject frameMgr;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerMgr.Instance == null)
        {
            PlayerMgr clone = Instantiate(player).GetComponent<PlayerMgr>();
            PlayerMgr.Instance = clone;
        }

        if (UIMgr.Instance == null)
        {
            UIMgr.Instance = Instantiate(uiMgr).GetComponent<UIMgr>();
        }

        if(GameManager.Instance == null)
        {
            GameManager.Instance =  Instantiate(gameMan).GetComponent<GameManager>();
        }

        if(FrameMgr.Instance == null)
        {
            FrameMgr.Instance =  Instantiate(frameMgr).GetComponent<FrameMgr>();
        }

    }
}
