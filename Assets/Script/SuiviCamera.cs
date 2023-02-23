
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuiviCamera : MonoBehaviour
{

    public Transform player;
    Vector3 position;


 
    void FixedUpdate()
    {
       
        position = player.position;
        position.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);

    }
}
