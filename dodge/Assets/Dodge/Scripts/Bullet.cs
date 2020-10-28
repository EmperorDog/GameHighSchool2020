using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //\여기
        //m_Velocity = transform.forward;
    }
    //여기
    public Vector3 m_Velocity;

    public float m_Speed = 5f;

    public float m_DestoryCooltime = 5f;

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = /*gameObject.*/GetComponent<Rigidbody>();

        //여기
        rigidbody.velocity = m_Velocity * m_Speed;

        m_DestoryCooltime -= Time.deltaTime;

        if (m_DestoryCooltime <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null && other.attachedRigidbody.tag == "Player")
        {
            var player = other.attachedRigidbody.GetComponent<PlayerController>();
            var player_dunguen = other.attachedRigidbody.GetComponent<PlayerController_Dungeon>();

            if(player_dunguen != null)
                player_dunguen.Die();

            if (player != null)
                player.Die();
        }
        else if(other.tag != "Enemy")
        {
            
            Destroy(gameObject);
        }
    }
}
