using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AudioClip Sound;
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }
    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        JhonMovement jhon = collision.GetComponent<JhonMovement>();
        GruntScript grunt = collision.GetComponent<GruntScript>();

        if(jhon != null)
        {
            jhon.Hit();
        }
        if(grunt != null)
        {
            grunt.Hit();
        }
        DestroyBullet();

    }
}
