using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float DodgeSpeed = 300f;
    public float DodgeTimer = 0f;
    public float TimeBetweenDodges = 6f;

    private bool havedodged = false;
    private Vector3 movement;
    private Rigidbody rigidbodyreference;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbodyreference = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DodgeTimer += Time.deltaTime;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        movement.y = 0f;

        if (Input.GetKeyDown("space") && DodgeTimer > TimeBetweenDodges)
        {
            havedodged = true;
        }
    }

    void FixedUpdate()
    {
        rigidbodyreference.velocity = movement * MoveSpeed;
        if (havedodged)
        {
            //call event to trigger animations? ref animator directly?
            rigidbodyreference.velocity = movement * DodgeSpeed;
            havedodged = false;
            DodgeTimer = 0;
        }
    }
}
