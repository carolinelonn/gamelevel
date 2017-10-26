using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerNew: MonoBehaviour {

    public float moveSpeed;
    public int count;

    private Animator anim;
    private Rigidbody2D playerRigidbody;
    public GameObject Lawnmover;

    private GameObject LawnmoverLimit;
    private Collider2D playerCollider;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        moveSpeed = 5;
        count = 0;
        Lawnmover = GameObject.Find("Lawnmover");
        Lawnmover.SetActive(false);

        LawnmoverLimit = GameObject.Find("LawnmoverLimit");
        //gets the lawnmover limit's collider and the players colliders and ignores their collitions
        Physics2D.IgnoreCollision(LawnmoverLimit.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, playerRigidbody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            playerRigidbody.velocity = new Vector2(0f, playerRigidbody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

        if(count == 3){
            count = 0;
            //new vector3 is added so that the lawnmover does not spawn directly onto player
            Lawnmover.transform.position = playerRigidbody.transform.position + new Vector3(1.0f, 0.0f, 0.0f);
            Lawnmover.SetActive(true);
        }

    }
}
