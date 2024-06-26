using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public GameManagerScript gameManager;

    public int maxHealth = 100;
    public int health;
    public int damage;
    
    public Player player;
    public GameObject deathEffect;
    public GameObject projectile;
    public HealthBar healthBar;
    public bool boss;

    public float LaunchForce;
    public AudioSource Damage;

    private Animator anim;

    void Start(){
        //StartCoroutine(Phase1());
        healthBar.SetMaxHealth(maxHealth);
        

        anim = GetComponent<Animator>();


        if (boss) {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Freeze rotation to keep the object upright
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        }
    }
    public void TakeDamage(int damage)
    {
       // Debug.Log("Enemy takes damage: " + damage); // Debug log
        health -= damage;
        //Debug.Log("Enemy health: " + health); // Debug log
        healthBar.SetHealth(health);
        Damage.Play();       
        if(health <= 0)
        {
            this.Die();
        }
    }


    private void Update()
    {
        if (health <= 1750 && boss) {
           // Debug.Log("HEALTH IS LESS THAN 250");
            anim.SetTrigger("stageTwo");
        }
    }

    /*
    private IEnumerator Phase1(){
        while(phase == 1){
            
            GameObject ThrownProjectile1 = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
            GameObject ThrownProjectile2 = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
            ThrownProjectile2.GetComponent<Rigidbody2D>().velocity = -transform.right * LaunchForce;
            ThrownProjectile1.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
            yield return new WaitForSeconds(5);
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.TakeDamage(damage);
        }
    }

    void Die()
    {
        //Uncomment later when have deatheeffects
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //gameManager.gameOver(); // to load game over screen - will remove when boss is implemented

    }
}