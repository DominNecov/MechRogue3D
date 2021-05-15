using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform heroTransform;
    [SerializeField]
    private float moveToTargetSpeed = 0.125f;
    [SerializeField]
    public Vector3 offSetVector3;
    private Transform myTransform;
    private Vector3 targetPosition;
    private Vector3 lerpPosition;

    private void Awake()
    {
        myTransform = this.transform;
    }

    private void FixedUpdate()
    {
        if (heroTransform != null)
        {
            targetPosition = heroTransform.position + offSetVector3;
            lerpPosition = Vector3.Lerp(myTransform.position, targetPosition, moveToTargetSpeed);
            this.transform.position = lerpPosition;
        }
    }
    public void SetHeroTransform(Transform transformtoset)
    {
        heroTransform = transformtoset;
    }
}
