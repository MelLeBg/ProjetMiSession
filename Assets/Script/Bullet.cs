
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject impacte;

    public float BulletSpeed = 5f;
    public Transform bulletPosition;
    private Rigidbody2D rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyBullet());
        
    }

    private void FixedUpdate()
    {
        
        rb.AddForce(transform.up * BulletSpeed, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Asteroide")
        {

            gameObject.SetActive(false);
        }

        if (collision.collider.tag == "Ennemie")
        {
            Instantiate(impacte, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }



    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }






}
