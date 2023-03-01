using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ennemy : MonoBehaviour
{

  

    public float vitesse;
    public float DistanceStop;
    public float DistanceRetraite;
    private float TimeBtwShot;
    public float StartTimeShot;

    public Transform player;
    public GameObject Balle;
    public GameObject Explosion;
    public AudioSource SonLaser;
    
      
    
    void Start()
    {
      
       

        player = GameObject.FindGameObjectWithTag("Player").transform;
        TimeBtwShot = StartTimeShot;
    }

    
    void Update()
    {
        Rotation(player.position);
        EnemyBehavior();
        EnemyShoot();
       
    }


    private void Rotation(Vector2 Player)
    {
        var offset = -90f;
        Vector2 direction = Player - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }


    private void EnemyBehavior()
    {
        if (Vector2.Distance(transform.position, player.position) > DistanceStop)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, vitesse * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < DistanceStop && Vector2.Distance(transform.position, player.position) > DistanceRetraite)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < DistanceRetraite)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -vitesse * Time.deltaTime);
        }

    }


    private void EnemyShoot()
    {
        if (TimeBtwShot <= 0 && Vector2.Distance(transform.position, player.position) < DistanceStop)
        {

            Instantiate(Balle, transform.position, transform.rotation);
            TimeBtwShot = StartTimeShot;
            SonLaser.Play();
        }
        else
        {
            TimeBtwShot -= Time.deltaTime;
        }

    }


  


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Missile")
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


  
}
