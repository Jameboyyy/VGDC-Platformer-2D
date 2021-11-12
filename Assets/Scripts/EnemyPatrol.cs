using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float moveSpeed;
    public bool moveRight;
    public Rigidbody2D body;
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;
    private float xScale;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        xScale = transform.localScale.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall)
        {
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
            body.velocity = new Vector2(moveSpeed, body.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
            body.velocity = new Vector2(-moveSpeed, body.velocity.y);
        }
    }
}
