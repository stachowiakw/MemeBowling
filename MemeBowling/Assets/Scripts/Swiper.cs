using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiper : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Pin_Collider")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }

}
