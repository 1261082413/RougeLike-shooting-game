using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed;
    private Vector2 moveInput;
    public Rigidbody2D theRB;

    public Transform gunArm;

    private Camera theCam;

    public Animator anim;

    public GameObject bulletToFire;

    public Transform firePoint;

    public float timeBetweenShots;
    private float shotCounter;

    public SpriteRenderer bodySR;

    private float activeMoveSpeed;

    public string areaTransitionName;

    public List<WeaponData> purchasedWeapons = new List<WeaponData>();

    public void OnWeaponPurchased(WeaponData weaponInfo)
    {
        Debug.Log("receive message weapon purchased" + weaponInfo.uniqueID);
        purchasedWeapons.Add(weaponInfo);
        foreach(WeaponData weapon in purchasedWeapons)
        {
            Debug.Log("has weapon " + weapon.uniqueID);
        }
    }

    public float dashSpeed = 8f, dashLength = .5f,dashCooldown = 1f, dashInvinvibility = .5f;

    
    [HideInInspector]
    public float dashCounter;

    private float dashCoolCounter;

    public bool canMove = true;

    public int goldAmount;

    public TextMeshProUGUI goldText;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;

        }else
        {
            Destroy(gameObject);
        }
        goldAmount = 0;

        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
       
        

        activeMoveSpeed = moveSpeed;

        WeaponData InitWeapon = new WeaponData(100, 0, 20.0f, 20.0f);
        purchasedWeapons.Add(InitWeapon);

    }

    // Update is called once per frame
    void Update()

    {
        
        theCam = Camera.main;
        if(canMove)
        {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        
        moveInput.Normalize();

        //transform.position += new Vector3(moveInput.x * Time.deltaTime * moveSpeed ,moveInput.y * Time.deltaTime * moveSpeed,0f);
        theRB.velocity = moveInput * activeMoveSpeed;
        }else
        {
            theRB.velocity = Vector2.zero;
        }
        

        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = theCam.WorldToScreenPoint(transform.localPosition);

        if(mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
            gunArm.localScale = new Vector3(-1f,-1f,1f);
        }else
        {
            transform.localScale =  Vector3.one;
            gunArm.localScale =  Vector3.one;

        }

        //rotate gun arm

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y,offset.x) * Mathf.Rad2Deg;
        gunArm.rotation = Quaternion.Euler(0,0,angle);


        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletToFire, firePoint.position,firePoint.rotation);
            shotCounter = timeBetweenShots;
        }

        if(Input.GetMouseButtonDown(0))
        {
            shotCounter -= Time.deltaTime;

            if(shotCounter <= 0)
            {
                Instantiate(bulletToFire, firePoint.position,firePoint.rotation);
                shotCounter = timeBetweenShots;

            }
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            if(dashCoolCounter<= 0 && dashCounter <= 0)
            {
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLength;

            anim.SetTrigger("dash");

            PlayerHealthController.instance.MakeInvincible(dashInvinvibility);

            }
           
        }

        if (dashCounter > 0){
            dashCounter -= Time.deltaTime;
            if (dashCounter<=0){
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter >0){
            dashCoolCounter -= Time.deltaTime;
        }








        if(moveInput != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }else
        {
            anim.SetBool("isMoving", false);

        }


    }
    public void AddGold(int goldToAdd)
    {
        goldAmount += goldToAdd;
        UpdateGoldUI();
    }
    public bool SpendGold(int goldToSpend)
    {
        if (goldAmount >= goldToSpend)
        {
            goldAmount -= goldToSpend;
            UpdateGoldUI();
            return true;
        }
        else
        {
            Debug.Log("Not enough gold");
            return false;
        }
    }
    private void UpdateGoldUI()
    {
        
        if (goldText != null)
        {
            goldText.text = goldAmount.ToString(); 
        }
        else
        {
            Debug.LogWarning("GoldText reference not set in the PlayerController.");
        }
    }
}
