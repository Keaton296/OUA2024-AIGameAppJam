using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRewindable : MonoBehaviour,IRewindable
{
    private Rigidbody rb;
    [SerializeField] Transform camPoint;
    [SerializeField] MouseLookController mouseLookController;
    [SerializeField] MovementController movementController;
    [SerializeField] HeadTilter headTilter;
    List<Vector3> positionRecords;
    List<Quaternion> rotationRecords;
    [SerializeField] int captureCount;
    public void OnRewindEnd()
    {
        if (rb != null)
        {
            rb.isKinematic = false;
            //headTilter.enabled = true;
            mouseLookController.SetRotationToCurrent();
            mouseLookController.enabled = true;
            movementController.enabled = true;
            rb.velocity = Vector3.zero;
        }
    }

    public void OnRewindStart()
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            //headTilter.enabled = false;
            mouseLookController.enabled = false;
            movementController.enabled = false;
            rb.isKinematic = true;
        }
    }

    public void Record()
    {
        positionRecords.Insert(0, transform.position);
        rotationRecords.Insert(0, camPoint.rotation);
        if (positionRecords.Count > captureCount)
        {
            positionRecords.RemoveAt(captureCount);
            rotationRecords.RemoveAt(captureCount);
        }
    }

    public void Rewind()
    {
        if (positionRecords.Count > 0)
        {
            transform.position = positionRecords[0];
            positionRecords.RemoveAt(0);
            camPoint.rotation = rotationRecords[0];
            rotationRecords.RemoveAt(0);
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        positionRecords = new List<Vector3>();
        rotationRecords = new List<Quaternion>();
    }
    void Start()
    {
        Rewinder.Singleton.rewindables.Add(this);
    }

    void Update()
    {
        
    }
}
