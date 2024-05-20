using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{
    [SerializeField] Animator doorAnimator;
    bool isOpen = false;
    private void Awake()
    {
        if(doorAnimator == null) doorAnimator = GetComponent<Animator>();
    }
    public void Interact()
    {
        ToggleDoor();
    }
    private void ToggleDoor()
    {
        isOpen = !isOpen;
        doorAnimator.SetBool("IsOpen", isOpen);
    }

}
