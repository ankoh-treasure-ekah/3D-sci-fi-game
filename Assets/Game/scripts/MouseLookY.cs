using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookY : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float _MouseY = Input.GetAxis("Mouse Y");
        Vector3 newPosition = transform.localEulerAngles;
        newPosition.x -= _MouseY;
        transform.localEulerAngles = newPosition;

        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x - _MouseY, transform.localEulerAngles.y, transform.localEulerAngles.z);

    }
}
