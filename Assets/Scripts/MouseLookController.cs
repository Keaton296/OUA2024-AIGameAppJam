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
    private void Awake()
    {
        lookingEuler = transform.rotation.eulerAngles;
        Cursor.visible = false;
    }
    void Update()
    {
        lookingEuler = new Vector3(Mathf.Clamp(lookingEuler.x - Input.GetAxis("Mouse Y"),RotMinX,RotMaxX), lookingEuler.y + Input.GetAxis("Mouse X"));
        transform.localRotation = Quaternion.Euler(lookingEuler);
    }
    public void SetRotationToCurrent()
    {
        lookingEuler = transform.rotation.eulerAngles;
    }
}
