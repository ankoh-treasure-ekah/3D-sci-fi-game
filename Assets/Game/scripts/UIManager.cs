using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _ammoText;

    [SerializeField]
    private GameObject _coinImage;
    
  

    public void _displayAmmo(int count)
    {
        _ammoText.text = "Score: " + count;
        
    }


    //create a function to activate our coin in the inventory
    //if hascoin is true
    //display our coin 
    //else
    //hide our coin

    public void _displayCoin()
    {
        _coinImage.SetActive(true);
    }


    public void _hideCoin()
    {

        _coinImage.SetActive(false);

    }
}
