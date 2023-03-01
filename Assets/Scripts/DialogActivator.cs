using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    [SerializeField]
    private string[] newLines;

    [SerializeField]
    private bool isPerson = true;

    private bool canActive;
    private DialogManager uiDialogSystem;

    // Start is called before the first frame update
    void Start()
    {
        uiDialogSystem = UIMgr.Instance.UIDialogSystem;
    }

    // Update is called once per frame
    void Update()
    {
        if(canActive && Input.GetButtonDown("Fire1") && !uiDialogSystem.GetActiveStatus())
        {
            uiDialogSystem.ShowDialog(newLines, isPerson);
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
