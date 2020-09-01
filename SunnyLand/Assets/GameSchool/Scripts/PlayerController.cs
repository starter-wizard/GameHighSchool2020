using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum MoveState
    {
        Run,
        Jump,
        Climb
    }

    private Rigidbody2D m_Rigidbody2D;
    private Animator m_Animator;

    [Header("참조")]
    public Transform m_Sprite;

    [Header("속성")]
    public float m_XAxisSpeed = 3f;
    public float m_YJumpPower = 3f;

    [Header("내부 속성(차후 private)")]
    public MoveState m_MoveState;
    public int m_JumpCount = 0;

    public bool m_IsTouchLadder = false;
    public bool m_IsClimbing = false;
    public bool m_IsJumping = false;

    public float m_FlightTime = 0f;

    protected void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        //Device Input 받아오기
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        //좌우 이동
        Vector2 velocity = m_Rigidbody2D.velocity;
        velocity.x = xAxis * m_XAxisSpeed;
        m_Rigidbody2D.velocity = velocity;

        //캐릭터 좌우 반전
        if (xAxis > 0)
            m_Sprite.localScale = new Vector3(1, 1, 1);
        else if (xAxis < 0)
            m_Sprite.localScale = new Vector3(-1, 1, 1);

        //점프 처리
        if (Input.GetKeyDown(KeyCode.Space) 
            && m_JumpCount <= 0)
        {
            m_Rigidbody2D.AddForce(Vector2.up * m_YJumpPower); ;
            m_JumpCount++;
        }

        //사다리에 접근했음
        if (m_IsTouchLadder)
        {
            //사다리 타고 있는 중이거나, 
            //사타리 타기를 시도할 경우,
            if (m_IsClimbing
                || Mathf.Abs(yAxis) > 0.1f)
            {
                m_MoveState = MoveState.Climb;
            }
        }


        //이거 추가
        m_IsJumping = Mathf.Abs(velocity.y) >= 0.1f ? true : false;
        
        //스크립트 2줄 작성
        m_Animator.SetBool("IsJumping", m_IsJumping);
        m_Animator.SetFloat("VelocityX", Mathf.Abs(xAxis));

        //이거 추가
        m_Animator.SetFloat("VelocityY", velocity.y);


        if (m_IsClimbing)
        {
            m_Rigidbody2D.constraints
                = m_Rigidbody2D.constraints | RigidbodyConstraints2D.FreezePositionY;

            transform.position += Vector3.up * yAxis * Time.deltaTime * 3f;

            var animator = GetComponent<Animator>();
            animator.SetBool("IsClimbing", true);
            animator.SetFloat("ClimbSpeed", Mathf.Abs(yAxis));
        }
        else
        {
            m_Rigidbody2D.constraints
                = m_Rigidbody2D.constraints & ~RigidbodyConstraints2D.FreezePositionY;

            var animator = GetComponent<Animator>();
            animator.SetBool("IsClimbing", false);
        }

    }

    private void MoveProcessRun()
    {
        //Do nothing;
    }

    private void MoveProcessJump()
    {
        //Do nothing;
    }

    private void MoveProcessClimb()
    {
        //Do nothing;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ladder")
        {
            m_IsTouchLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            m_IsTouchLadder = false;
            m_IsClimbing = false;
        }
    }
}