using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformController : MonoBehaviour
{
    float targetPoint = -6.22f;
    public float speed = 1f;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!(oyunKontrol.instantiate.stop))
        {
            MoveToWardsPlatform();
        }
        
    }

    private void MoveToWardsPlatform()
    {

        Vector2 _vector = transform.position;
        _vector.x = Mathf.MoveTowards(_vector.x, targetPoint, 0.03f * speed);
        if (Mathf.Abs(_vector.x - targetPoint) < 0.01f)
        {
            _vector.x = targetPoint;

        }
        transform.position = _vector;
        


    }
}
