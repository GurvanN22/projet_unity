using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class GunHandler : MonoBehaviour
{

    private Camera main_camera;
    private Vector3 mouse_position;
    public GameObject bullet;
    public Transform fire_point;
    public bool shoot_anable = true;

    public GameObject gun_sprite; 

    private float timer;
    public float fire_rate = 0.5f;

    //public int bulletNbrMax = 15;
    //public int bulletNbr = 15;
    //public float reloadTime = 2f;

    private bool reloading = false;

    //public GameObject bulletDisplay;


    // Start is called before the first frame update
    void Start()
    {
        main_camera = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Camera>();
        //bulletDisplay = GameObject.FindGameObjectsWithTag("ammo")[0];
    }

    // Update is called once per frame
    void Update()
    {
        // Code the gun folowing the mouse
        mouse_position = main_camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mouse_position - transform.position;

        float z_axe_rotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, z_axe_rotation);

        if (!shoot_anable)
        {
            timer += Time.deltaTime;
            if (timer >= fire_rate)
            {
                shoot_anable = true;
                timer = 0;
            }
        }

        // Code the shooting
        if (Input.GetMouseButtonDown(0) && shoot_anable)
        {
            shoot_anable = false;
            Instantiate(bullet, fire_point.position, Quaternion.identity);
            //bulletNbr--;
            //updateShootingDisplay();
        }
    }
    
    // private void handle_reload()
    // {
    //     if (Input.GetKeyDown(KeyCode.R) && !reloading )
    //     {
    //         reloading = true;
    //         Invoke("FinishReload", reloadTime);
    //     }
    // }
    //     private void updateShootingDisplay()
    // {
    //     bulletDisplay.GetComponent<TextMeshProUGUI>().text = bulletNbr.ToString() + "/" + bulletNbrMax.ToString();
    // }
    // private void FinishReload()
    // {
    //     bulletNbr = bulletNbrMax;
    //     updateShootingDisplay();
    //     reloading = false;
    // }
}
