using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookController : MonoBehaviour
{
    [SerializeField] float RotMaxX = 70f;
    [SerializeField] float RotMinX = -90f;
    Vector3 rotationEuler;
    private void Awake()
    {
        rotationEuler = transform.rotation.eulerAngles;
        Cursor.visible = false;
    }
    void Update()
    {
        rotationEuler = new Vector3(Mathf.Clamp(rotationEuler.x - Input.GetAxis("Mouse Y"),RotMinX,RotMaxX), rotationEuler.y + Input.GetAxis("Mouse X"));
        transform.rotation = Quaternion.Euler(rotationEuler);
    }
}
