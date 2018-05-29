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
    private AudioSource damageSound;
    private Scene currentScene;
    
    [SerializeField]
    public AudioClip[] playerDamageSounds;

    public AudioClip playerBumpSound;

    private GameObject clickbox;
    // Use this for initialization
    void Start () {

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
        //currentHealth = maxHealth;
            //PlayerPrefs.GetFloat("health");


        lastFrameHealth = currentHealth;
        damageSound = gameObject.AddComponent<AudioSource>();

        clickbox = GameObject.FindGameObjectWithTag("ClickBox").gameObject;
        Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), clickbox.GetComponent<BoxCollider2D>());

        /*if(playerSounds != null)
        {
            damageSound.clip = playerSounds[0];
        }*/
    }

    void Update()
    {
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
        //PlayDamageSound();
        Debug.Log("Test 1: " + currentHealth);
        currentHealth -= (baseDamage * strenght);
        Debug.Log("Test damage: " + (baseDamage * strenght));
        Debug.Log("Test 2: " + currentHealth);

        SetHealth(CalculateHealth(currentHealth));
        //Debug.Log("Test3");
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }

    private float CalculateHealth(float health)
    {
        float toReturn;
        toReturn = health / maxHealth;
        Debug.Log(toReturn);
        return toReturn;
    }

    void SetHealth(float myHealth)
    {
        healthBar.fillAmount = myHealth;
        //Debug.Log("Test 4");
    }

    void TriggerLoss()
    {
        SceneManager.LoadScene(0);
    }

    private void PlayDamageSound()
    {    
        if(playerDamageSounds != null || playerDamageSounds.Length > 0)
        {
            damageSound.clip = playerDamageSounds[Random.Range(0, 2)];
            damageSound.Play();
        }
        else
        {
            Debug.LogError("The AudioClip list \"playerDamageSounds\" is empty");
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
            damageSound.clip = playerBumpSound;
            damageSound.Play();
          
    }
}
