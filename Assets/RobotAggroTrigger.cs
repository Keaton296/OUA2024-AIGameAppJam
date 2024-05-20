using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAggroTrigger : MonoBehaviour
{
    [SerializeField] RobotBehaviour robot;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            robot.playerController = other.GetComponent<MovementController>();
        }
    }
}
