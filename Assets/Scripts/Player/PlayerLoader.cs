﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerMgr.Instance == null)
        {
            Instantiate(Player);
        }
    }
}
