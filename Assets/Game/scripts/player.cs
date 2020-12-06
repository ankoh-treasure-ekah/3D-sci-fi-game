using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float _speed = 3.5f;
    private float _gravity = 9.81f;
    private CharacterController _characterController;
    private player _player;
    [SerializeField]
    private GameObject _MuzzleFlash;
    [SerializeField]
    private GameObject _hitMarker;
    /* [SerializeField]
     private AudioClip hitSoundPrefab;*/
    // Start is called before the first frame update
    [SerializeField]
    private AudioSource _shootAudio;
    [SerializeField]
    private int currentAmmo;
    private int maxAmmo = 50;
    private bool _isReloading;

    private UIManager _uimanager;
    //[SerializeField]
    public bool _hasCoin;

    private destructable _destructable;

   
    void Start()
    {

        _characterController = GetComponent<CharacterController>();
        _player = GetComponent<player>();

        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();

        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;


        _MuzzleFlash.SetActive(false);

        currentAmmo = maxAmmo;

        _isReloading = false;

        _hasCoin = false;

        _uimanager._hideCoin();


    }

    // Update is called once per frame
    void Update()
    {

        movement();

       

        if (Input.GetMouseButton(0) && currentAmmo > 0)
        {
            shoot();
            //sscurrentAmmo--;         
        }
        else
        {
            _MuzzleFlash.SetActive(false);
            _shootAudio.Stop();
        }


        //if r is pressed
        //refill the currentammo for 2 seconds
        if(Input.GetKeyDown(KeyCode.R) && _isReloading == false)
        {
            _isReloading = true;
            
            StartCoroutine(weaponReloadRoutine());
        }

    }

 

    void movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.transform.TransformDirection(velocity);
        _characterController.Move(velocity * Time.deltaTime);
    }


    void shoot()
    {
        Ray rayPoint = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit rayInfo;

        if (Physics.Raycast(rayPoint, out rayInfo))
        {
            Debug.Log("hit: " + rayInfo.transform.name);

            _destructable = rayInfo.transform.GetComponent<destructable>();

            if(_destructable != null)
            {

                _destructable.destroyCrate();

            }


        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {


            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }

       
        _MuzzleFlash.SetActive(true);
        currentAmmo--;
        _uimanager._displayAmmo(currentAmmo);
       
        if (_shootAudio.isPlaying == false)
        {
            _shootAudio.Play();
        }

        //AudioSource.PlayClipAtPoint(hitSoundPrefab, this.gameObject.transform.position);
        GameObject hitmarkerprefab = Instantiate(_hitMarker, rayInfo.point, Quaternion.LookRotation(rayInfo.normal)) as GameObject;
        Destroy(hitmarkerprefab, 1f);
       



    }





    IEnumerator weaponReloadRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        currentAmmo = maxAmmo;
        _isReloading = false;
        _uimanager._displayAmmo(currentAmmo);
    }


    







}
