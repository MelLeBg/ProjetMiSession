using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform bulletPosition;
    public Rigidbody2D rb;
    Vector2 mouvements;
    
    public float vitesse = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        

        // mouvements avec fleches ou wasd
        mouvements.x = Input.GetAxisRaw("Horizontal");
        mouvements.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + mouvements * vitesse * Time.deltaTime);

        // rotation vaisseau avec la souris
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }

    private void Shoot()
    {
        GameObject bullet = ObjectPool.instance.GetObjectInPool();

        if(bullet != null)
        {
            bullet.transform.position = bulletPosition.position;
            bullet.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }
}
