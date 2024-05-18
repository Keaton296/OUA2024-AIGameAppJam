using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosRotRewindable : MonoBehaviour,IRewindable
{
    [SerializeField] private Rigidbody rb;
    private List<Vector3> positionRecords;
    private List<Quaternion> rotationRecords;
    [SerializeField] int captureCount = 400; 
    void Awake()
    {
        positionRecords = new List<Vector3>();
        rotationRecords = new List<Quaternion>();
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        Rewinder.Singleton.rewindables.Add(this);
    }
    public void OnRewindEnd()
    {
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void OnRewindStart()
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }
    }

    public void Record()
    {
        positionRecords.Insert(0, transform.position);
        rotationRecords.Insert(0, transform.rotation);
        if (positionRecords.Count > captureCount)
        {
            positionRecords.RemoveAt(captureCount);
            rotationRecords.RemoveAt(captureCount);
        }
    }

    public void Rewind()
    {
        if(positionRecords.Count > 0)
        {
            transform.position = positionRecords[0];
            positionRecords.RemoveAt(0);
            transform.rotation = rotationRecords[0];
            rotationRecords.RemoveAt(0);
        }
    }

}
