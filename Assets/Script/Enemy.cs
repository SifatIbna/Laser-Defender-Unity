using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Laser")]
    [SerializeField] GameObject enemyLaser;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;

    [Header("Explotion")]
    [SerializeField] GameObject explotion;

    [Header("Health")]
    [SerializeField] float health = 100;

    [Header("SFX")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip laserSFX;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.7f;

    void Start()
    {
        ResetShotCounter();
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }
    private void ResetShotCounter()
    {
        this.shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);

    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            ResetShotCounter();
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(enemyLaser, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10f);
        AudioSource.PlayClipAtPoint(laserSFX, Camera.main.transform.position, 0.7f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        if (!damageDealer) { return; }
        Debug.Log(damageDealer.GetDamage());
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        Debug.Log(damageDealer.GetDamage());
        this.health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();

        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(10);
        Destroy(gameObject);
        GameObject star_explotion = Instantiate(explotion, transform.position, transform.rotation);
        Destroy(star_explotion, 0.2f);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
    }

}
