using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Simulation;
using static KinematicObject;

/// <summary>
/// This is the main class used to implement control of the player.
/// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
/// </summary>
public class PlayerController : KinematicObject
{
    /// <summary>
    /// Max horizontal speed of the player.
    /// </summary>
    public float maxSpeed = 7;
    
    public Health health;
    public bool controlEnabled = true;
    
    Vector2 move;
    SpriteRenderer spriteRenderer;
//  internal Animator animator;
    public Collider2D collider2d;
    readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();
    
    public Bounds Bounds => collider2d.bounds;
    
    void Awake()
    {
        health = GetComponent<Health>();
        collider2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
//      animator = GetComponent<Animator>();
    }
    
    protected override void Update()
    {
        if (controlEnabled)
        {
            move.x = Input.GetAxis("Horizontal");
            move.y = Input.GetAxis("Vertical");
        }
        else
        {
            move.x = 0;
            move.y = 0;
        }
        base.Update();
    }
    
    protected override void ComputeVelocity()
    {   
        if (move.x > 0.01f)
            spriteRenderer.flipX = false;
        else if (move.x < -0.01f)
            spriteRenderer.flipX = true;

        if (move.y > 0.01f)
            spriteRenderer.flipY = false;
        else if (move.y < -0.01f)
            spriteRenderer.flipY = true;
        
//      animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
//      animator.SetFloat("velocityY", Mathf.Abs(velocity.y) / maxSpeed);
        
        targetVelocity = move * maxSpeed;
    }
}