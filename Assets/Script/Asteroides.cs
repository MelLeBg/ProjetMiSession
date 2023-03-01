using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroides : MonoBehaviour
{
    public GameObject Explosion;
    public AudioSource SonExplosion;




    private void Destroy()
    {
        GameObject CopieExplosion = Instantiate(Explosion, transform.position, transform.rotation);
        CopieExplosion.transform.localScale = transform.localScale;

        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Missile")
        {
            SonExplosion.Play();
            Destroy();

        }


    }




}
