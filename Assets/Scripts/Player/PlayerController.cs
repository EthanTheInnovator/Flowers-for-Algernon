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
    public float aggression = 0;
    
    Vector2 move;
    SpriteRenderer spriteRenderer;
    new Rigidbody2D rigidbody;
//  internal Animator animator;
    public Collider2D collider2d;
    
    public Bounds Bounds => collider2d.bounds;

    private float timeSinceLastAggression = 0;
    
    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        timeSinceLastAggression += Time.deltaTime;
        if (timeSinceLastAggression > Mathf.Max(10 - aggression, 2)) {
            bool shouldActOnAggression = Random.Range(0, 10) < aggression;
            if (shouldActOnAggression) {
                timeSinceLastAggression = -Random.Range(0, (aggression / 2));
                spriteRenderer.color = Color.red;
                move.x = Random.Range(-1f, 1f);
                move.y = Random.Range(-1f, 1f);
            }
        }

        if (timeSinceLastAggression >= 0) {
            spriteRenderer.color = Color.white;
            move.x = Input.GetAxis("Horizontal");
            move.y = Input.GetAxis("Vertical");
            Debug.Log(move);
        }

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
    }
}