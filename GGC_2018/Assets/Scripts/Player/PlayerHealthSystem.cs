using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerStats))]
public class PlayerHealthSystem : MonoBehaviour {

    private float maxHealth;
    public float currentHealth;
    public float lastFrameHealth;
    public float baseDamage = 20f;
    public Image healthBar;
    private AudioSource playerSound;
    private Scene currentScene;
    private Color originalColor;
    public Color damageColor;
    private float timerDamageColorChange = 0;

    [SerializeField]
    public AudioClip[] playerDamageSounds;

    public AudioClip playerBumpSound;

    public AudioClip playerDrinkingPickupSound;

    public AudioClip playerPickupSound;

    private GameObject clickbox;

    public GameObject angel;
    // Use this for initialization
    void Start () {
        originalColor = GetComponent<SpriteRenderer>().color;

        currentScene = SceneManager.GetActiveScene();

        maxHealth = GetComponent<PlayerStats>().maxHealth;
    
        if (currentScene.name == "Gameplay")
        {
            currentHealth = maxHealth;
            if (PlayerPrefs.HasKey("health"))
            {
                PlayerPrefs.DeleteKey("health");
                PlayerPrefs.SetFloat("health", currentHealth);
            }
            else
            {
                PlayerPrefs.SetFloat("health", currentHealth);
            }
        }
        else
        {
            currentHealth = PlayerPrefs.GetFloat("health");
        }


        lastFrameHealth = currentHealth;
        playerSound = gameObject.AddComponent<AudioSource>();

        clickbox = GameObject.FindGameObjectWithTag("ClickBox").gameObject;
        Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), clickbox.GetComponent<BoxCollider2D>());

        SetHealth(CalculateHealth(currentHealth));
    }

    void Update()
    {
        if (this.GetComponent<SpriteRenderer>().color != originalColor)
        {
            timerDamageColorChange++;
            DamageEffect(timerDamageColorChange);
        }

        if (currentHealth != lastFrameHealth)
        {
            PlayerPrefs.SetFloat("health", currentHealth);
        }
    
        lastFrameHealth = currentHealth;
        if (currentHealth <= 0)
        {
            PlayerPrefs.SetFloat("health", maxHealth);
            gameObject.SetActive(false);
            TriggerLoss();
        }
        
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void DamageEffect(float timer)
    {
        if (timer > ((1 / Time.deltaTime) / 2))
        {
            this.GetComponent<SpriteRenderer>().color = originalColor;
            timerDamageColorChange = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //Debug.Log("Test1");
            TakeDamage(1);
            LevelManager.deaths++;
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(0.5f);
        }
        if (other.CompareTag("Hitbox"))
        {
            TakeDamage(0.1f);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Lasor"))
        {
            TakeDamage(0.005f);
        }
    }

    public void TakeDamage(float strenght)
    {
        if(strenght > 0)
        {
            PlayDamageSound();
            DamageVisualisation();
        }
        //else{   PlayDrinkingPickUpSound(); }
        
        currentHealth -= (baseDamage * strenght);

        SetHealth(CalculateHealth(currentHealth));

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            Instantiate(angel, transform.position, Quaternion.identity);
        }
    }

    public void PlayDrinkingPickUpSound()
    {
        playerSound.clip = playerDrinkingPickupSound;
        playerSound.Play();
    }

    public void PlayPickUpSound()
    {
        playerSound.clip = playerPickupSound;
        playerSound.Play();
    }

    private float CalculateHealth(float health)
    {
        float toReturn;
        toReturn = health / maxHealth;
        return toReturn;
    }

    void SetHealth(float myHealth)
    {
        healthBar.fillAmount = myHealth;
    }

    void TriggerLoss()
    {
        SceneManager.LoadScene(0);
    }

    private void PlayDamageSound()
    {    
        if(playerDamageSounds != null || playerDamageSounds.Length > 0)
        {
            playerSound.clip = playerDamageSounds[UnityEngine.Random.Range(0, 2)];
            playerSound.Play();
        }
        else
        {
            Debug.LogError("The AudioClip list \"playerDamageSounds\" is empty");
        }
        
    }

    private void DamageVisualisation()
    {
        GetComponent<SpriteRenderer>().color = damageColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
            playerSound.clip = playerBumpSound;
            playerSound.Play();
          
    }
}
