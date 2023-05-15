using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint; 
    public int maxHealth = 100;
    public int currentHealth;
    public int score = 0; 
    public int enemiesKilled = 0; 

    private Rigidbody rb;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI enemiesKilledText; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        UpdateHealthText(); 
        UpdateScoreText();
        UpdateEnemiesKilledText();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = rb.velocity;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        score -= 5; 
        UpdateHealthText();
        UpdateScoreText();
    }

    public void AddScore()
    {
        score += 10;
        enemiesKilled++; 
        UpdateScoreText();
        UpdateEnemiesKilledText();
    }

    private void UpdateHealthText()
    {
        healthText.text = "Vida: " + currentHealth.ToString();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Puntos: " + score.ToString();
    }

    // Método para actualizar el texto de los enemigos asesinados
    private void UpdateEnemiesKilledText()
    {
        enemiesKilledText.text = "Muertes: " + enemiesKilled.ToString();
    }
}