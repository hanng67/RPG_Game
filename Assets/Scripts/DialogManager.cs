using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private Text dialogText;

    [SerializeField]
    private Text nameText;

    [SerializeField]
    private GameObject nameBox;

    [SerializeField]
    private string[] dialogLines;

    private int currentLine;

    private bool justStarted;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!justStarted)
                {
                    currentLine++;
                    if (currentLine >= dialogLines.Length)
                    {
                        gameObject.SetActive(false);
                        GameManager.Instance.dialogActive = false;
                    }
                    else
                    {
                        CheckIfName();
                        dialogText.text = dialogLines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;
                }
            }
        }   
    }

    public void ShowDialog(string[] newlines, bool isPerson)
    {
        dialogLines = newlines;

        currentLine = 0;
        CheckIfName();
        dialogText.text = dialogLines[currentLine];
        gameObject.SetActive(true);
        nameBox.SetActive(isPerson);

        GameManager.Instance.dialogActive = true;

        justStarted = true;
    }

    public void CheckIfName()
    {
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }

    public bool GetActiveStatus()
    {
        return gameObject.activeInHierarchy;
    }
}
