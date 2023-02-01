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
    private GameObject dialogBox;

    [SerializeField]
    private GameObject nameBox;

    [SerializeField]
    private string[] dialogLines;

    private int currentLine;

    private bool justStarted;

    public static DialogManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!justStarted)
                {
                    currentLine++;
                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);
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
        dialogBox.SetActive(true);
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

    public bool GetActiveDialogBox()
    {
        return dialogBox.activeInHierarchy;
    }
}
