using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct WeaponData
{
    public int uniqueID;
    public int price;
    public float fireRate;
    public float damage;
    public Sprite icon; 

    public GameObject weaponPrefab;
    

    public WeaponData(int ID, int iPrice, float fFireRate, float fDamage, Sprite iIcon,GameObject wPrefab)
    {
        uniqueID = ID;
        price = iPrice;
        fireRate = fFireRate;
        damage = fDamage;
        icon = iIcon;
        weaponPrefab = wPrefab;
        
        
    }
};


public class ShopMenu : MonoBehaviour
{
    public static ShopMenu instance;
    public GameObject shopMenu;
    public TextMeshProUGUI goldText;
    public Button[] weaponPurchaseButtons;
    public Image[] weaponImages;
    public WeaponData[] allWeapons;
    public Button exitButton;

    private void Awake()
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
        exitButton.onClick.AddListener(CloseShopMenu);
    }


    

    private void Start()
    {
        UpdateGoldAmount();
        InitializeShopMenu();
    }

    public void ToggleShopMenu()
    {
        shopMenu.SetActive(!shopMenu.activeSelf);
        PlayerController.instance.canMove = !shopMenu.activeSelf;
        UpdateShopMenu();
    }

    public void RequestBuy(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < allWeapons.Length)
        {
            WeaponData selectedWeapon = allWeapons[weaponIndex];
            if (PlayerController.instance.goldAmount >= selectedWeapon.price)
            {
                PlayerController.instance.SpendGold(selectedWeapon.price);
                PlayerController.instance.OnWeaponPurchased(selectedWeapon);
                UpdateShopMenu();
            }
            else
            {
                Debug.Log("Not enough gold to buy weapon.");
            }
        }
        else
        {
            Debug.Log("Weapon index out of range.");
        }
    }

    private void UpdateGoldAmount()
    {
        goldText.text = "GoldAmount: " + PlayerController.instance.goldAmount.ToString();
    }

    private void InitializeShopMenu()
    {
        
        for (int i = 0; i < allWeapons.Length; i++)
        {
            //weaponImages[i].sprite = allWeapons[i].icon;
            int index = i; 
            weaponPurchaseButtons[i].onClick.AddListener(() => RequestBuy(index));
            
        }
    }

    private void UpdateShopMenu()
    {
        
        for (int i = 0; i < allWeapons.Length; i++)
        {
            WeaponData weapon = allWeapons[i];
            bool isPurchased = PlayerController.instance.purchasedWeapons.Contains(weapon);
            weaponPurchaseButtons[i].interactable = !isPurchased && PlayerController.instance.goldAmount >= weapon.price;

        }

        
        UpdateGoldAmount();
    }
     public void CloseShopMenu()
    {
        shopMenu.SetActive(false);
        PlayerController.instance.canMove = true;  
    }

}
