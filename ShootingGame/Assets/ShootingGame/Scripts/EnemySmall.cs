using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall : MonoBehaviour
{
    public float m_Speed = 3f ;

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = transform.up * m_Speed;
        Vector3 movement = velocity * Time.deltaTime;
        transform.position += movement;
    }
}
