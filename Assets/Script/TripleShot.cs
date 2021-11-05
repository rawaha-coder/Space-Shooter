using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour
{
    void Update()
    {
        DestroyTripleShotObject();
    }

    private void DestroyTripleShotObject()
    {
        if (transform.position.y >= 7f)
        {
            Destroy(this.gameObject);
        }
    }
}
