using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingShootingController : MonoBehaviour
{
    public Transform TurretRigidbodyMainCharacter;
    public Transform BulletSpawnLocation;
    public GameObject BulletPrefab;
    public Camera MainCamera;
    public bool CanRotate = false;

    private float rotationangle;
    private Ray cameraRay;
    private float rayLength;
    private Vector3 pointToLookAt;
    [SerializeField]
    private float max_shoot_timer;
    [SerializeField]
    public float shoot_timer;
    private bool canshoot;
    private bool shoot_pressed;
    [SerializeField]
    private float lerpvalue;


    // Update is called once per frame
    void Update()
    {
        cameraRay = MainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            pointToLookAt = cameraRay.GetPoint(rayLength);
            pointToLookAt.y += 1f;
        }
        shoot_timer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            shoot_pressed = true;
        }
    }
    void FixedUpdate()
    {
        //New to be changed to just rotate on the Y axis instead of using look at.
       TurretRigidbodyMainCharacter.LookAt(pointToLookAt);
        if (shoot_timer >= max_shoot_timer && shoot_pressed)
        {
            shoot_timer = 0;
            GetComponentInParent<Hero>().SpawnProjectile(BulletPrefab, BulletSpawnLocation, TurretRigidbodyMainCharacter.forward);
        }
        shoot_pressed = false;
    }
    public void UpdateTimer(float NewTimerAmount)
    {
        max_shoot_timer = NewTimerAmount;
    }
}
