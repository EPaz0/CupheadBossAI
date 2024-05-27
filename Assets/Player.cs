﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("Health")]

	public int maxHealth = 3;
	public int currentHealth;

	public HealthBar healthBar;
	
	[Header("iFrames")]
	[SerializeField]private float iFramesDuration;
	[SerializeField]private int numberOfFlashes;
	private SpriteRenderer spriteRend;

	private void Awake(){
		// a function from video for iframes: https://www.youtube.com/watch?v=YSzmCf_L2cE
		spriteRend = GetComponent<SpriteRenderer>();
	}

	// Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
		
		if (currentHealth > 0){
			//set animation in future here
			StartCoroutine(Invulnerability());
		}
		
		
		if (currentHealth <= 0)
		{
			Destroy(gameObject);
		}
	}


	private IEnumerator Invulnerability(){
		// 6 = Player Layer, 8 = Enemy Layer
		Physics2D.IgnoreLayerCollision(6, 8, true);
		for (int i = 0; i < numberOfFlashes; i++){
			// will flash red character (will change to white)
			spriteRend.color = new Color (1, 0, 0, 0.5f);
			yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
			spriteRend.color = Color.white;
			yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
		}
		Physics2D.IgnoreLayerCollision(6, 8, false);

	}
}