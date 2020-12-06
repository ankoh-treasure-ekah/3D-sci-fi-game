using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructable : MonoBehaviour
{
    [SerializeField]
    private GameObject _destructable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destroyCrate()
    {

        Instantiate(_destructable, transform.position, transform.rotation);
        Destroy(this.gameObject);

    }


}
