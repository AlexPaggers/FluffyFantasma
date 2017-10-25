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
    public float GetMaxRunSpeed()                                { return maxRunSpeed; }
    public void SetMaxRunSpeed(float _maxRunSpeed)              { maxRunSpeed = _maxRunSpeed; }

    [SerializeField]
    private bool running;
    public bool GetRunning()                                    { return running; }
    public void SetRunning( bool _running )                     { running = _running; }

    [SerializeField]
    //[Range(0, 1)]
    private float moveAcceleration;
    public float GetMoveAcceleration()                           { return moveAcceleration; }
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
    private Vector2 gravity;
    public Vector2 GetGravity()                                    { return gravity; }
    public void SetGravity(Vector2 _gravity)                    { gravity = _gravity; }

    [SerializeField]
    [Range(0, 1)]
    private float dampening;
    public float GetDampening()                                  { return dampening; }
    public void SetDampening(float _dampening)                  { dampening = _dampening; }

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
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    // Use this for initialization
    void Start ()
    {
		if(gameType == GameType2D.TOP_DOWN_VIEW)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else if (gameType == GameType2D.SIDE_SCROLLER)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }


    }

    //Must be called in FixedUpdate.
    public void move(Vector2 direction)
    {
        direction.Normalize();

        currentSpeed += direction * moveAcceleration * Time.deltaTime;

        if (!running &&
            currentSpeed.magnitude > maxWalkSpeed)
        {
            currentSpeed = currentSpeed.normalized * maxWalkSpeed;
        }
        else if (running &&
            currentSpeed.magnitude > maxRunSpeed)
        {
            currentSpeed = currentSpeed.normalized * maxRunSpeed;
        }

        transform.position = new Vector3(transform.position.x + currentSpeed.x, transform.position.y + currentSpeed.y, transform.position.z);

        currentSpeed *= (1 - dampening);

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