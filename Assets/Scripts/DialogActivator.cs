using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    public string[] lines;
    private bool canActivate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(canActivate && Input.GetButtonDown("Fire1") && !DialogManager.instance.dialogBox.activeInHierarchy)
        //{
        //    DialogManager.instance.ShowDialog(lines);
        //    Debug.Log("DialogActivator ShowDialog");
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            //canActivate = true;
            Debug.Log("DialogActivator OnTriggerEnter2D");

            DialogManager.instance.bCanShowDialog = true;
            DialogManager.instance.InitDialogMessages(lines);
        }
    
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //canActivate = true;
            Debug.Log("DialogActivator OnTriggerExit2D");

            DialogManager.instance.bCanShowDialog = false;
        }
    }



}
