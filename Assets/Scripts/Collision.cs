using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Collision : MonoBehaviour
{

    float delay = 3f;
    bool statu;
    [SerializeField] Color32 statu_color;
    SpriteRenderer sprite_renderer;
    [SerializeField] public GameObject driverObject; //Driver scriptinin içinde bulunduğu oyun objesi inspectordan referans verilir. public olmalı
    
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Başka bir obje ile temas edildi.");
    }

    private void OnTriggerEnter2D(Collider2D other) {

        Driver boost_speed = driverObject.GetComponent<Driver>(); //part1


        if (other.tag == "customer" && statu == false) {
            Debug.Log("Müşteri alındı.");
            statu = true;
            Destroy(other.gameObject, 0.2f);
        }

        if (other.tag == "stop" && statu == true) {
            Debug.Log("Müşteri hedefe ulaştırıldı.");
            sprite_renderer = other.GetComponent<SpriteRenderer>();
            sprite_renderer.color = statu_color;
            statu = false;
        }

        if (other.tag == "boost") { // part2 driver scripttindeki moveSpeed değişkenine erişim, not: moveSpeed değişkeni public olmalı!
            boost_speed.moveSpeed *= 1.4f;
            Destroy(other.gameObject, 0.15f);
            Invoke("TurnNormalSpeed", delay);
        }

        if (other.tag == "debuff"){
            boost_speed.moveSpeed = 4f;
            Destroy(other.gameObject, 0.15f);
            Invoke("TurnNormalSpeed", delay); //delaylı olarak methodu tetikleyip hız eski haline getirilir.
        }
    }

    public void TurnNormalSpeed() {
        Driver boost_speed = driverObject.GetComponent<Driver>(); 
        boost_speed.moveSpeed = 8f;
    }
}
