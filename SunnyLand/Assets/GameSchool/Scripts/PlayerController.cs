using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform m_Sprite;

    private Rigidbody2D m_Rigidbody2D;

    public float m_XAxisSpeed = 3f;
    public float m_YJumpPower = 3f;

    public int m_JumpCount = 0;

    protected void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector2 velocity = m_Rigidbody2D.velocity;
        velocity.x = xAxis * m_XAxisSpeed;
        m_Rigidbody2D.velocity = velocity;

        if (xAxis > 0)
            m_Sprite.localScale = new Vector3(1, 1, 1);
        else if(xAxis < 0)
            m_Sprite.localScale = new Vector3(-1, 1, 1);


        if (Input.GetKeyDown(KeyCode.UpArrow)
            && m_JumpCount <= 0)
        {
            m_Rigidbody2D.AddForce(Vector3.up 
                * m_YJumpPower);

            m_JumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
            if (contact.normal.y > 0.5f)
            {
                m_JumpCount = 0;
            }
        }
    }
}