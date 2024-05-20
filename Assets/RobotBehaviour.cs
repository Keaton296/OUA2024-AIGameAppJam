using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class RobotBehaviour : MonoBehaviour,IRewindable
{
    public MovementController playerController;
    [SerializeField] Animator animator;
    [SerializeField] NavMeshAgent agent;
    List<Vector3> positionRecords;
    List<Quaternion> rotationRecords;
    [SerializeField] int captureCount;

    public void OnRewindEnd()
    {
        agent.enabled = true;
    }

    public void OnRewindStart()
    {
        agent.enabled = false;
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
        if (positionRecords.Count > 0)
        {
            transform.position = positionRecords[0];
            positionRecords.RemoveAt(0);
            transform.rotation = rotationRecords[0];
            rotationRecords.RemoveAt(0);
        }
    }

    private void Awake()
    {
        agent ??= GetComponent<NavMeshAgent>();
        positionRecords = new List<Vector3>();
        rotationRecords = new List<Quaternion>();
    }
    private void Start()
    {
        Rewinder.Singleton.rewindables.Add(this);
    }
    private void Update()
    {
        if (playerController != null && agent.enabled)
        {
            agent.destination = playerController.transform.position;
            if (Vector3.Distance(playerController.transform.position, transform.position) < 1f)
            {
                SceneManager.LoadScene(0);
            }
        }
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
