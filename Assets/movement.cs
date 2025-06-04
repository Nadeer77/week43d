using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float sidemovespeed= 100f;
    public float fbmovespeed = 100f;
    
    public void FixedUpdate()
    {
        float movehr = Input.GetAxis("Horizontal");
        float movevr = Input.GetAxis("Vertical");

        Vector3 movement1 = new Vector3(-movevr, 0, movehr) *sidemovespeed * Time.deltaTime;
        Vector3 movement2 = new Vector3(-movevr, 0, movehr) * fbmovespeed * Time.deltaTime;

        transform.Translate(movement1);
        transform.Translate(movement2);
    }
}
