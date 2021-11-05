using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.5f;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject tripleShotPrefab;
    [SerializeField]
    private bool isTripleShotActive = false;
    [SerializeField]
    private bool isShieldActive = false;
    [SerializeField]
    private float fireRate = 0.1f;
    private float nextFire = 0.0f;
    [SerializeField]
    public int lives = 3;
    [SerializeField]
    private int _score;
    private SpawnManager spawnManager;
    private UIManager _uiManager;
    [SerializeField]
    private GameObject shieldsVisualizer;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        if(true)
            FireLaser();
    }

    private void FireLaser()
    {
        nextFire = Time.time + fireRate;
        if (isTripleShotActive)
        {
            Instantiate(tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 0.9f, 0), Quaternion.identity);
        }
    }

    private void CalculateMovement()
    {
        Vector3 deriction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.Translate(deriction * _speed * Time.deltaTime);
        if (transform.position.x >= 11.5)
        {
            transform.position = new Vector3(-11.5f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.5)
        {
            transform.position = new Vector3(11.5f, transform.position.y, 0);
        }
        if (transform.position.y >= 5)
        {
            transform.position = new Vector3(transform.position.x, 5, 0);
        }
        else if (transform.position.y <= -4)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }
    }

    public void AddScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }

    public void Damage()
    {
        if (isShieldActive)
        {
            isShieldActive = false;
            shieldsVisualizer.SetActive(false);
            return;
        }
            
        lives--;
        _uiManager.UpdateLives(lives);
        if (lives <1 )
        {
            if (spawnManager != null)
                spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void ActiveTripleShot()
    {
        isTripleShotActive = true;
        StartCoroutine(TripleShotPowerUpRoutine());
    }

    IEnumerator TripleShotPowerUpRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }

    internal void ActiveSpeedUp()
    {
        _speed = 8.0f;
        StartCoroutine(SpeedUpRoutine());
    }

    IEnumerator SpeedUpRoutine()
    {
        yield return new WaitForSeconds(5);
        _speed = 4.5f;
    }

    internal void ActiveSheild()
    {
        isShieldActive = true;
        shieldsVisualizer.SetActive(true);
    }

}
