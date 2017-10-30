using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement2D : MonoBehaviour {

    [SerializeField]
    private Vector2 currentSpeed;
    public Vector2 GetCurrentSpeed()                            { return currentSpeed; }

    [SerializeField]
    private float maxWalkSpeed;
    public float GetMaxWalkSpeed()                               { return maxWalkSpeed; }
    public void    SetMaxWalkSpeed(float _maxWalkSpeed)            { maxWalkSpeed = _maxWalkSpeed; }

    [SerializeField]
    private float maxRunSpeed;
    public float GetMaxRunSpeed()                               { return maxRunSpeed; }
    public void SetMaxRunSpeed(float _maxRunSpeed)              { maxRunSpeed = _maxRunSpeed; }

    [SerializeField]
    private bool running;
    public bool GetRunning()                                    { return running; }
    public void SetRunning( bool _running )                     { running = _running; }

    [SerializeField]
    //[Range(0, 1)]
    private float moveAcceleration;
    public float GetMoveAcceleration()                          { return moveAcceleration; }
    public void SetMoveAcceleration(float _moveAcceleration)    { moveAcceleration = _moveAcceleration; }

    [SerializeField]
    private bool grounded;
    public bool GetGrounded()                                   { return grounded; }
    public void SetGrounded(bool _grounded)                     { grounded = _grounded; }

    [SerializeField]
    private float jumpForce;
    public float GetJumpForce()                                  { return jumpForce; }
    public void SetJumpForce( float _jumpForce )                { jumpForce = _jumpForce; }

    [SerializeField]
    [Range(0, 1)]
    private float dampening;
    public float GetDampening()                                  { return dampening; }
    public void SetDampening(float _dampening)                  { dampening = _dampening; }

    [SerializeField]
    [Range(0, 1)]
    private float friction;
    public float GetFriction() { return friction; }
    public void SetFriction(float _friction) { friction = _friction; }

    [SerializeField]
    private float gravity;
    public float GetGravity() { return gravity; }
    public void SetGravity(float _gravity) { gravity = _gravity; }


    public enum GameType2D
    {
        SIDE_SCROLLER,
        TOP_DOWN_VIEW
    }

    [SerializeField]
    private GameType2D gameType;
    public GameType2D GetGameType()                             { return gameType; }
    public void SetGameType(GameType2D _gameType)
    {
        gameType = _gameType;

        if (gameType == GameType2D.TOP_DOWN_VIEW)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else if (gameType == GameType2D.SIDE_SCROLLER)
        {
            GetComponent<Rigidbody2D>().gravityScale = gravity;
        }
    }

    private Rigidbody2D body;

    // Use this for initialization
    void Start ()
    {
		if(gameType == GameType2D.TOP_DOWN_VIEW)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else if (gameType == GameType2D.SIDE_SCROLLER)
        {
            GetComponent<Rigidbody2D>().gravityScale = gravity;
        }

        body = GetComponent<Rigidbody2D>();

    }

    //Must be called in FixedUpdate.
    public void move(Vector2 direction)
    {
        direction.Normalize();

        currentSpeed += direction * moveAcceleration * Time.deltaTime;

        if(gameType == GameType2D.TOP_DOWN_VIEW)
        {
            if (!running &&
            body.velocity.magnitude > maxWalkSpeed)
            {
                body.velocity = body.velocity.normalized * maxWalkSpeed;
            }
            else if (running &&
                body.velocity.magnitude > maxRunSpeed)
            {
                body.velocity = body.velocity.normalized * maxRunSpeed;
            }

            currentSpeed *= (1 - dampening);

        }

        if (gameType == GameType2D.SIDE_SCROLLER)
        {
            if (!running &&
            body.velocity.x > maxWalkSpeed)
            {
                body.velocity = new Vector2(maxWalkSpeed, body.velocity.y);
            }

            if (!running &&
            body.velocity.x < maxWalkSpeed * -1)
            {
                body.velocity = new Vector2(maxWalkSpeed * -1, body.velocity.y);
            }

            else if (running &&
                body.velocity.x > maxRunSpeed)
            {
                body.velocity = new Vector2(maxRunSpeed, body.velocity.y);
            }

            else if (running &&
                body.velocity.x < maxRunSpeed * -1)
            {
                body.velocity = new Vector2(maxRunSpeed * -1, body.velocity.y);
            }

            if(grounded && direction == Vector2.zero)
            {
                body.velocity = new Vector2(body.velocity.x * (1 - friction), body.velocity.y);
            }

            currentSpeed.x *= (1 - dampening);

        }

        

        //transform.position = new Vector3(transform.position.x + currentSpeed.x, transform.position.y + currentSpeed.y, transform.position.z);
        body.AddForce(currentSpeed);

    }

    public void jump()
    {
        if (gameType == GameType2D.SIDE_SCROLLER &&
            grounded)
        {
            //currentSpeed.y += jumpForce;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }

}