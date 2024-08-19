using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool statu;
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Başka bir obje ile temas edildi.");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "customer" && statu == false) {
            Debug.Log("Müşteri alındı.");
            statu = true;
            Destroy(other.gameObject, 0.2f);
        }

        if (other.tag == "stop" && statu == true) {
            Debug.Log("Müşteri hedefe ulaştırıldı.");
            statu = false;
        }
    }
}
