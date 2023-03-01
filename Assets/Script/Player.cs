using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform bulletPosition;
    public GameObject bullet;
    public GameObject explosion;
    public Rigidbody2D rbPlayer;
    public Rigidbody2D rbBullet;
    

    Vector2 mouvements;
   
    public float vitesseVaisseau = 5f;
    public float BulletSpeed = 24f;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void FixedUpdate()
    {
       

        // mouvements avec fleches ou wasd
        mouvements.x = Input.GetAxisRaw("Horizontal");
        mouvements.y = Input.GetAxisRaw("Vertical");
        rbPlayer.MovePosition(rbPlayer.position + mouvements * vitesseVaisseau * Time.deltaTime);

        // rotation vaisseau avec la souris
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }

    private void Shoot()
    {
        GameObject bullet = ObjectPool.instance.GetObjectInPool();
        


        if (bullet != null)
        {
            bullet.transform.rotation = bulletPosition.rotation;
            bullet.transform.position = bulletPosition.position;
            bullet.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ennemy Bullet")
        {
            PlayerDie();
        }
    }

    public void PlayerDie()
    {
       
        
        Instantiate(explosion, transform.position, transform.rotation);
        
      
        FindObjectOfType<GameManager>().GameOver();
        Destroy(this.gameObject);
       // gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        


    }
}
