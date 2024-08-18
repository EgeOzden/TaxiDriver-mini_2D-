using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float turnSpeed = 90f;
    [SerializeField] float moveSpeed = 8f;
    void Start()
    {

    }


    void Update()
    {
        float donusDegeri = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;//dönüş değeri = A,D tuşlarına basma * dönüş hızı * zaman fps
        float hareketDegeri = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -donusDegeri); //dönüş
        transform.Translate(0, hareketDegeri, 0); //hareket
    }
}
