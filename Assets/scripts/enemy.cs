using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    //adjustable char speed
    [SerializeField]
    public float speed;
    //players direction
    private Vector2 direction;
    //character rigit body
    private Rigidbody2D EnemyRigitBody;
    private CapsuleCollider2D box;
    private Vector2 subdir = Vector2.left;
    private Animator animator;
    public bool isDead = false;
    public bool isDead2 = false;
    private AudioSource cheese;
    // Use this for initialization
    void Start()
    {
        box = GetComponent<CapsuleCollider2D>();
        EnemyRigitBody = GetComponent<Rigidbody2D>();
        subdir=subdir* (Random.Range(0, 2) * 2 - 1);
        cheese = GetComponent<AudioSource>();
            animator = GetComponent<Animator>();
            cheese = GetComponent<AudioSource>();
        
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject spawnerss = GameObject.Find("spawn2");
        if (this.gameObject.tag == "ufo" && collision.collider.tag!="border")
        {
            isDead = true;
            box.enabled = false;
            cheese.enabled = true;
            isDead2 = true;
            
        }
        else if (this.gameObject.name.StartsWith("slime") && collision.collider.tag != "border")
        {
            box.enabled = false;
            if (collision.collider.tag == "Player" || collision.collider.tag == "food"||collision.collider.name.StartsWith("slime"))
                cheese.enabled = true;
            EnemyRigitBody.simulated = false;
            animator.enabled = false;
            this.GetComponent<Renderer>().enabled = false;
            Destroy(this.gameObject, 0.5f);

        }
        else if (this.gameObject.name.StartsWith("lizzard") && collision.collider.tag != "border")
        {
            box.enabled = false;
            if (collision.collider.tag == "Player" || collision.collider.tag == "enemy"|| collision.collider.tag == "food")
                cheese.enabled = true;
            EnemyRigitBody.simulated = false;
            animator.enabled = false;
            this.GetComponent<Renderer>().enabled = false;
            Destroy(this.gameObject, 0.5f);

        }
        else
        if (this.gameObject.name.StartsWith("alien") && collision.collider.tag != "border")
        {
            box.enabled = false;
            if(collision.collider.tag=="Player")
                cheese.enabled = true;
            EnemyRigitBody.simulated = false;
            animator.enabled = false;
            this.GetComponent<Renderer>().enabled = false;
            Destroy(this.gameObject, 0.5f);

        }
        else
            box.enabled = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("border"))
        subdir = -subdir;
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
    private void FixedUpdate()
    {
        direction = Vector2.zero;
        direction += Vector2.down;        
        if (this.gameObject.tag == "ufo")
        {
            direction += subdir * 2;
            animator.SetBool("dead", isDead);
            isDead = false;
        }
        EnemyRigitBody.velocity = direction.normalized * speed;
        if (this.transform.position.y < -15)
            Destroy(this.gameObject);
        if (isDead2)
        {
            EnemyRigitBody.simulated = false;
            Destroy(this.gameObject, 1.5f);
        }
    }
}
