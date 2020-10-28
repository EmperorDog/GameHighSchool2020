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
    public Collider2D m_WorkCollider;
    public Collider2D m_SideCollider;

    [Header("속성")]
    public float m_XAxisSpeed = 3f;
    public float m_YJumpPower = 3f;
    public float m_ClimbSpeed = 2f;

    [Header("내부 속성(차후 private)")]
    public MoveState m_MoveState;
    public int m_JumpCount = 0;

    public bool m_IsTouchLadder = false;
    public bool m_IsClimbing = false;
    public bool m_IsJumping = false;

    public float m_FlightTime = 0f;

    public float m_HitRecoveringTime = 0;

    //추가
    private bool m_InputJump = false;
    public void Jump()
    {
        m_InputJump = true;
    }

    public VariableJoystick m_Joystick;
    protected void Update()
    {
        //Device Input 받아오기
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        xAxis += m_Joystick.Horizontal;
        yAxis += m_Joystick.Vertical;

        //추가
        var inputJump = m_InputJump;
        m_InputJump = false;

        //+= => -=    <=  =>  >
        m_HitRecoveringTime -= Time.deltaTime;
        if (m_HitRecoveringTime > 0)
        {
            ClimbingExit();

            m_Animator.SetBool("TakingDamage", true);
            return;
        }
        else
        {
            m_Animator.SetBool("TakingDamage", false);
        }

        if (m_IsTouchLadder == true
            && Mathf.Abs(yAxis) > 0.5f)
        {
            m_IsClimbing = true;
        }

        if (!m_IsClimbing)
        {
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
            if ((Input.GetKeyDown(KeyCode.Space)
                || inputJump)
                && m_JumpCount <= 0)
            {
                m_Rigidbody2D.AddForce(Vector2.up * m_YJumpPower); ;
                m_JumpCount++;
            }

            //이거 추가
            m_IsJumping = Mathf.Abs(velocity.y) >= 0.1f ? true : false;

            //스크립트 2줄 작성
            m_Animator.SetBool("IsJumping", m_IsJumping);
            m_Animator.SetFloat("VelocityX", Mathf.Abs(xAxis));

            //이거 추가
            m_Animator.SetFloat("VelocityY", velocity.y);
        }
        else
        {
            //사다리 타는 도중의 이동기능
            m_Rigidbody2D.constraints =
                m_Rigidbody2D.constraints 
                | RigidbodyConstraints2D.FreezePosition;

            Vector3 movement = Vector3.zero;
            movement.x = xAxis * m_ClimbSpeed * Time.deltaTime;
            movement.y = yAxis * m_ClimbSpeed * Time.deltaTime;

            transform.position += movement;

            if (Input.GetKeyDown(KeyCode.Space) 
                || inputJump)
            {
                ClimbingExit();
            }

            // Update 사다리타기 점프 캔슬하는데 
            //여기랑
            m_Animator.SetBool("IsClimbing", m_IsClimbing);
            m_Animator.SetFloat("ClimbSpeed",
                Mathf.Abs(xAxis) + Mathf.Abs(yAxis));
        }
    }

    protected void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }


    private void ClimbingExit()
    {
        m_Rigidbody2D.constraints =
            m_Rigidbody2D.constraints
            & ~RigidbodyConstraints2D.FreezePosition;
        m_IsClimbing = false;

        //여기
        m_Animator.SetBool("IsClimbing", m_IsClimbing);
    }


    private void OnCollisionStay2D(Collision2D collision)
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                m_JumpCount = 0;

                if (contact.rigidbody)
                {
                    var hp = contact.rigidbody.GetComponent<HPComponet>();
                    if (hp)
                    {
                        //Destroy(hp.gameObject);
                        hp.TakeDamage(10);
                    }
                }
            }
            else if(contact.rigidbody && contact.rigidbody.tag == "Enemy")
            {
                //피격시 무적
                if (m_HitRecoveringTime <= 0)   
                {
                    var hp = GetComponent<HPComponet>();
                    hp.TakeDamage(10);

                    m_HitRecoveringTime = 1f;

                    //m_Animator.SetTrigger("TakeDamage");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ladder")
        {
            m_IsTouchLadder = true;
        }
        else if(collision.tag == "Item")
        {
            ItemComponet item = collision.
                GetComponent<ItemComponet>();
            if(item != null)
                item.BeAte();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            m_IsTouchLadder = false;

            ClimbingExit();
        }

    }

}