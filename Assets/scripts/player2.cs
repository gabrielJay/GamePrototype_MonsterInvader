using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class player2 : MonoBehaviour
{
    //adjustable char speed
    [SerializeField]
    private float speed;
    //players direction
    private Vector2 direction;
    //character rigit body
    private Rigidbody2D PlayerRigitBody;
    // Keep Track of Tail
    //List<Transform> tail = new List<Transform>();
    public int health = 0;
    // Tail Prefab
    //public GameObject tailprefab;
    public bool isImgOn1;
    public Image img1;
    public bool isImgOn2;
    public Image img2;
    public bool isImgOn3;
    public Image img3;
    [SerializeField]
    private AudioClip clip;
    private AudioSource cheese;

    // Use this for initialization
    void Start()
    {
        PlayerRigitBody = GetComponent<Rigidbody2D>();
        cheese = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        getimput();
        imageMangager();
    }

    private void imageMangager()
    {
        if( health<=0)
            SceneManager.LoadScene("GameOverSingle");

        if (health >= 1)
        {
            img1.enabled = true;
            isImgOn1 = true;
        }
        else
        {
            img1.enabled = false;
            isImgOn1 = false;
        }
        if (health >= 2)
        {
            img2.enabled = true;
            isImgOn2 = true;
        }
        else
        {
            img2.enabled = false;
            isImgOn2 = false;
        }
        if (health >= 3)
        {
            img3.enabled = true;
            isImgOn3 = true;
        }
        else
        {
            img3.enabled = false;
            isImgOn3 = false;
        }
    }
    private void FixedUpdate()
    {
        PlayerRigitBody.velocity = direction.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy" || collision.collider.tag == "ufo"  )
        {
            //player2.GetComponent<player1>().health++;
             health -= 1;
         
        }
        if (collision.collider.tag == "food")
        {
            health += 1;
            if (health >= 4)
                health = 3;
            cheese.PlayOneShot(clip);

        }
       

    }

    private void getimput()
    {
        //set the default direction to zero, or no movement
        direction = Vector2.zero;
        GameObject follower = GameObject.Find("follower1");
        Vector2 position = follower.transform.position;
        position.x = this.transform.position.x;
        follower.transform.position = position;
        if (health > 0)
            follower.GetComponent<SpriteRenderer>().enabled = true;
        else
            follower.GetComponent<SpriteRenderer>().enabled = false;

        //if one of the movement key is pressed move
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            position.x = this.transform.position.x + 0.25f;
            follower.transform.position = position;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            position.x = this.transform.position.x - 0.25f;
            follower.transform.position = position;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if(this.gameObject.transform.position.y<3.6)
            direction += Vector2.up;   
        }

        if (Input.GetKey(KeyCode.N))
        {
            SceneManager.LoadScene("singleplayer");

        }
        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene("multiplayer");

        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("GameStart");

        }

    }

}
