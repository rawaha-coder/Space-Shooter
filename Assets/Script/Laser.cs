using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 8.0f;

    void Update()
    {
        FireUpLaser();
        DestroyLaserObj();
    }

    private void FireUpLaser()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void DestroyLaserObj()
    {
        if (transform.position.y >= 7f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
