using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct WeaponData
{
    public int uniqueID;
    public int price;
    public float fireRate;
    public float damage;
    // icon

    public WeaponData(int ID, int iPrice, float fFireRate, float fDamage)
    {
        uniqueID = ID;
        price = iPrice;
        fireRate = fFireRate;
        damage = fDamage;
    }
};

public class ShopMenu : MonoBehaviour
{
    public static ShopMenu instance; 
    public GameObject shopMenu; 
    public int goldAmount = 1000;

    public WeaponData[] allWeapons;

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

    public void RequestBuy(int WeaponID)
    {
        Debug.Log("request buy weapon " + WeaponID);
        for(int i = 0; i < allWeapons.Length; ++i)
        {
            if(allWeapons[i].uniqueID == WeaponID)
            {
                Debug.Log("find request weapon:" + allWeapons[i].price);

                if(allWeapons[i].price <= goldAmount)
                {
                    goldAmount -= allWeapons[i].price;
                    PlayerController.instance.OnWeaponPurchased(allWeapons[i]);
                }
                return;
            }
        }

        Debug.Log("failed to find request weapon");
    }
}
