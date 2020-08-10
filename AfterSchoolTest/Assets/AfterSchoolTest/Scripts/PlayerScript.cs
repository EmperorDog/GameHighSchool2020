using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject Particle;
    public float Speed = 8;
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        float speed = 5f;

        transform.position += new Vector3(xAxis, 0, yAxis) * Speed * Time.deltaTime;

        RaycastHit hit;
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = Vector3.forward;
        if (Physics.Raycast(ray, out hit, 10f, LayerMask.GetMask("1", "2"), QueryTriggerInteraction.Collide))
        {
            GameObject.Instantiate(Particle, hit.point, Quaternion.identity);
        }
        Debug.DrawLine(Vector3.zero, Vector3.zero + Vector3.forward * 100f, Color.red);
    }
}
