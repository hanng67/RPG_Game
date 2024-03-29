﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    [SerializeField]
    private string[] newLines;

    [SerializeField]
    private bool isPerson = true;

    private bool canActive;

    // Update is called once per frame
    void Update()
    {
        if(canActive && Input.GetButtonDown("Fire1") && !DialogManager.Instance.GetActiveStatus())
        {
            DialogManager.Instance.ShowDialog(newLines, isPerson);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActive = false;
        }
    }
}
