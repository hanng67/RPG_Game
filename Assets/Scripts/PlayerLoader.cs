﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    [SerializeField]
    public GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController.instance == null)
        {
            Instantiate(_player);
        }
    }
}
