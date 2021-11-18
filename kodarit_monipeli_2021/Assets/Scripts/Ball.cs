using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int _SininenPisteet = 0;
    public int _PunainenPisteet = 0;
    

    Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();


    }

    void OnTriggerEnter(Collider other) {
        
        Vector3 startPoint = new Vector3(0, 1, 0);

        if(other.tag == "SininenMaali"){

            _PunainenPisteet += 1;

        }

        if(other.tag == "PunainenMaali"){

            _SininenPisteet += 1;

        }
        
        transform.position = startPoint;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        
    }


}