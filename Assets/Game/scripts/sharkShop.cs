using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sharkShop : MonoBehaviour
{
    private UIManager _uimanager;
    [SerializeField]
    private GameObject _weapon;

    private AudioSource __winAudio;
    // Start is called before the first frame update
    void Start()
    {
        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();

        __winAudio = GetComponent<AudioSource>();

        _weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      






    }

    //check for collisions 
    //check if its the player we collided
    //check for player key e press
    //check if player has coin
    //take the coin
    //give player weapon

    private void OnTriggerStay(Collider other)
    {

        Debug.Log(other.name + " wants to buy");
        if(other.name == "player")
        {
            player _player = other.GetComponent<player>();
            if(_player != null)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {

                    if(_player._hasCoin == true)
                    {
                        _uimanager._hideCoin();

                        __winAudio.Play();
                        _weapon.SetActive(true);
                        


                    }
                    else
                    {
                        Debug.Log("You have no coin to make this purchase");

                    }


                }


            }


        }


    }


}
