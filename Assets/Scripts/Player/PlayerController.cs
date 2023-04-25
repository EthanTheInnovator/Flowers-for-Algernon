using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the main class used to implement control of the player.
/// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Max horizontal speed of the player.
    /// </summary>
    public float maxSpeed = 7;
    public bool controlEnabled = true;
    
    Vector2 move;
    SpriteRenderer spriteRenderer;
    new Rigidbody2D rigidbody;
//  internal Animator animator;
    public Collider2D collider2d;
    
    public Bounds Bounds => collider2d.bounds;
    
    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (controlEnabled)
        {
            move.x = Input.GetAxis("Horizontal");
            move.y = Input.GetAxis("Vertical");

            if (move.x > 0.01f) {
                spriteRenderer.flipX = false;
            }
            else if (move.x < -0.01f) {
                spriteRenderer.flipX = true;
            }

            if (move.y > 0.01f) {
                spriteRenderer.flipY = false;
            }
            else if (move.y < -0.01f) {
                spriteRenderer.flipY = true;
            }

            rigidbody.velocity = move * maxSpeed;
        } else {
            move.x = 0;
            move.y = 0;
        }   
    }
}