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

    private bool justStarted;
    
    // Start is called before the first frame update
    void Start()
    {
        instance =this;
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
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!justStarted)
                {
                    currentLine++;
                    if (currentLine >= dialogLines.Length)
                    {
                        // 当对话结束时，打开商店菜单
                        EndDialogAndOpenShop();
                    }
                    else
                    {
                        dialogText.text = dialogLines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;
                    PlayerController.instance.canMove = false;
                }
            }
        }
    }    public void ShowDialog(string[] newLines)
        {
            dialogLines =newLines;
            currentLine = 0;
            dialogText.text= dialogLines[0];
            dialogBox.SetActive(true);
            justStarted = true;
            
        }
    
}
