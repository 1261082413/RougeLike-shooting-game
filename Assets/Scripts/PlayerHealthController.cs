using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth;

    public int maxHealth;

    public string example;

    public float damageInvinclength =1f;

    private float invincCount;

    

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        currentHealth = maxHealth;
        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCount > 0){
            invincCount -= Time.deltaTime;

            if(invincCount <= 0){
                PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, 1f);


            }
        }
    }

    public void addHealth(int healthAmount)
    {
        currentHealth += healthAmount;
        currentHealth = (int)Mathf.Min(currentHealth,maxHealth);
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();

    }
    public void DamagePlayer()
    {
        if(invincCount <= 0){
            currentHealth-- ;
            invincCount = damageInvinclength;
            AudioManager.instance.PlaySFX(11);
            PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, .5f);
        if(currentHealth <=0)
        {
            PlayerHealthController.instance.gameObject.SetActive(false);
            AudioManager.instance.PlaySFX(11);
            UIController.instance.deathScreen.SetActive(true);
            AudioManager.instance.GameOver();
        }

        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();

        }
        
    }
    public void MakeInvincible(float length)
    {
        invincCount = length;
        PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, .5f);
        
    }
}
