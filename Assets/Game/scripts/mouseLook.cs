using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        Vector3 NewRotaton = transform.localEulerAngles;
        NewRotaton.y += _mouseX;
        transform.localEulerAngles = NewRotaton;
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y + _mouseX, transform.localEulerAngles.z); 





    }
}
