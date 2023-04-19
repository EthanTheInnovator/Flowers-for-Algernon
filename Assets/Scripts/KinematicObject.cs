using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implements game physics for some in game entity.
/// </summary>
public class KinematicObject : MonoBehaviour
{
    
    /// <summary>
    /// The current velocity of the entity.
    /// </summary>
    public Vector2 velocity;
    
    protected Vector2 targetVelocity;
    protected Rigidbody2D body;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    
    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;
    
    
    /// <summary>
    /// Bounce the object's vertical velocity.
    /// </summary>
    /// <param name="value"></param>
    public void Bounce(float value)
    {
        velocity.y = value;
    }
    
    /// <summary>
    /// Bounce the objects velocity in a direction.
    /// </summary>
    /// <param name="dir"></param>
    public void Bounce(Vector2 dir)
    {
        velocity.y = dir.y;
        velocity.x = dir.x;
    }
    
    /// <summary>
    /// Teleport to some position.
    /// </summary>
    /// <param name="position"></param>
    public void Teleport(Vector3 position)
    {
        body.position = position;
        velocity *= 0;
        body.velocity *= 0;
    }
    
    protected virtual void OnEnable()
    {
        body = GetComponent<Rigidbody2D>();
        body.isKinematic = true;
    }
    
    protected virtual void OnDisable()
    {
        body.isKinematic = false;
    }
    
    protected virtual void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }
    
    protected virtual void Update()
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
    }
    
    protected virtual void ComputeVelocity()
    {
        
    }
    
    protected virtual void FixedUpdate()
    {
//      //if already falling, fall faster than the jump speed, otherwise use normal gravity.
//      if (velocity.y < 0)
//          velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
//      else
//          velocity += Physics2D.gravity * Time.deltaTime;
        
        velocity.y = targetVelocity.y;
        velocity.x = targetVelocity.x;
        
//      IsGrounded = false;
        
        var deltaPosition = velocity * Time.deltaTime;
        PerformMovement(deltaPosition, true);
    }
    
    void PerformMovement(Vector2 move, bool yMovement)
    {
        var distance = move.magnitude;
        
        if (distance > minMoveDistance)
        {
            //check if we hit anything in current direction of travel
            var count = body.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
            for (var i = 0; i < count; i++)
            {
                var currentNormal = hitBuffer[i].normal;
                
                //remove shellDistance from actual move distance.
                var modifiedDistance = hitBuffer[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }
        body.position = body.position + move.normalized * distance;
    }
    
}