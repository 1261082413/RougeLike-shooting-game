using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public static ShopMenu instance; 
    public GameObject shopMenu; 
    public int goldAmount; 

    void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            shopMenu.SetActive(false); 
        }
        else if (instance != this)
        {
            Destroy(gameObject); 
        }
    }
    
    

    public void ToggleShopMenu()
    {
        
        shopMenu.SetActive(!shopMenu.activeSelf);
        
        PlayerController.instance.canMove = !shopMenu.activeSelf;
    }
}
