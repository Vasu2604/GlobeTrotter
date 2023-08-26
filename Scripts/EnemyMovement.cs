using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
  
    [SerializeField] float EnemyRunSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFacingRight())
        {
            rb.velocity = new Vector2(EnemyRunSpeed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(- EnemyRunSpeed, 0f);
        }

        bool IsFacingRight()
        {
            return transform.localScale.x > 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1f);
    }
}
