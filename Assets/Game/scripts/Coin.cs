using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private AudioClip _coinSound;

    private UIManager _uimanager;
    // private player _player;
    // Start is called before the first frame update
    void Start()
    {

        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //check for collisions
        //check if player collided with us 
        //creat a variable to hold player coin
        //give player the coin
        //destroy coin
        


    }
    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            Debug.Log(other.name);

            player _player = other.GetComponent<player>();

            if (other.name == "player")
            {
                if (_player != null)
                {
                    AudioSource.PlayClipAtPoint(_coinSound, this.transform.position);
                    _player._hasCoin = true;
                    _uimanager._displayCoin();
                    Destroy(this.gameObject);

                }
                //Destroy(this.gameObject);


            }
        }
    }
   
      
    
}
