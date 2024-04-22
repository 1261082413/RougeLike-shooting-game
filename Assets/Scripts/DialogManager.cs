using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;
    public int currentLine;
    public static DialogManager instance;

    public bool bCanShowDialog;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //dialogText.text = dialogLines[currentLine];
    }

    public void EndDialogAndOpenShop()
    {
        if (currentLine >= dialogLines.Length)
        {
            dialogBox.SetActive(false);
            PlayerController.instance.canMove = true;
            ShopMenu.instance.ToggleShopMenu();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bCanShowDialog)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                dialogBox.SetActive(true);
                if (currentLine < dialogLines.Length)
                {
                    dialogText.text = dialogLines[currentLine];
                    currentLine++;
                    PlayerController.instance.canMove = false;
                }
                else
                {
                    EndDialogAndOpenShop();
                    bCanShowDialog = false;
                }
            }
        }
    }

    public void InitDialogMessages(string[] newLines)
    {
        dialogLines = newLines;
        currentLine = 0;
    }
    
}
