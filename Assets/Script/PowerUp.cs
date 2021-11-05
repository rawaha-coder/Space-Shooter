using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField] //powerUpType: TripleShot = 0, Speed = 1, Shields = 2
    private int powerUpType;

    void Start()
    {
       transform.position = new Vector3(UnityEngine.Random.Range(-8, 8), 6f, 0);

    }

    void Update()
    {
        MoveDown();
        if(transform.position.y < -6f)
            Destroy(this.gameObject);
    }
    private void MoveDown()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            if(player != null)
            {
                if(powerUpType == 0)
                {
                    player.ActiveTripleShot();
                }else if(powerUpType == 1)
                {
                    player.ActiveSpeedUp();
                }else if(powerUpType == 2)
                {
                    player.ActiveSheild();
                }

            }
            Destroy(this.gameObject);
        }
    }

}
