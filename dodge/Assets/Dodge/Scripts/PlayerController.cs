using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public float Speed = 8;

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

         float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        rigidbody.AddForce(new Vector3(xAxis,0,yAxis) * Speed);

        float fire = Input.GetAxis("Fire1");

        if (fire != 0) Die();


        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //
        //    Debug.Log("스페이스 누름");
        //}
        //if (Input.GetKey(KeyCode.Space))
        //{
        //
        //    Debug.Log("스페이스 눌려져있음");
        //}
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //
        //    Debug.Log("스페이스 땜");
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    rigidbody.AddForce(Vector3.left * 10f);
        //    Debug.Log("왼");
        //
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    rigidbody.AddForce(Vector3.right * 10f);
        //    Debug.Log("오른쪽");
        //}
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    rigidbody.AddForce(Vector3.forward * 10f);
        //    Debug.Log("위 쪽");
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    rigidbody.AddForce(Vector3.back * 10f);
        //    Debug.Log("아래 쪽");
        //}
            
    }

    public void Die()
    {
        Debug.Log("뒤짐");
        gameObject.SetActive(false);
    }
}
