using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float XXXX = 0;
    public int XX = 0;
    public double X = 0;
    public long XU = 0;
    public byte x = 0;
    public string srtr = "";
    public bool b = false;

    public Transform trans = null;

    public Test()
    {

    }

    public void Awake()
    {
        trans = FindObjectOfType<Transform>();
        trans = GetComponent<Transform>();

    }

    public void Start()
    {
        x = default;
    }

}
