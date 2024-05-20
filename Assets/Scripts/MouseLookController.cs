using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookController : MonoBehaviour
{
    [SerializeField] float RotMaxX = 70f;
    [SerializeField] float RotMinX = -90f;
    Vector3 lookingEuler;
    bool Tilting = true;
    [SerializeField] Rigidbody rb;
    [SerializeField] float interactDistance = 1f;
    [SerializeField] LayerMask interactableLayerMask;
    IInteractable selectedInteractable;
    public IInteractable SelectedInteractable { get { return selectedInteractable; } }
    
    private void Awake()
    {
        lookingEuler = transform.rotation.eulerAngles;
        Cursor.visible = false;
    }
    void Update()
    {
        lookingEuler = new Vector3(Mathf.Clamp(lookingEuler.x - Input.GetAxis("Mouse Y"),RotMinX,RotMaxX), lookingEuler.y + Input.GetAxis("Mouse X"));
        transform.localRotation = Quaternion.Euler(lookingEuler);
        SearchInteractables();
    }
    public void SetRotationToCurrent()
    {
        lookingEuler = transform.rotation.eulerAngles;
    }
    private void SearchInteractables()
    {
        if(Physics.Raycast(transform.position,transform.forward,out RaycastHit hitInfo, interactDistance, interactableLayerMask))
        {
            selectedInteractable = hitInfo.collider.GetComponent<IInteractable>();
        }
        else
        {
            selectedInteractable = null;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            selectedInteractable?.Interact();
        }
    }
}
