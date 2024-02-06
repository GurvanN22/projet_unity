using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : MonoBehaviour
{

    private Camera main_camera;
    private Vector3 mouse_position;
    public GameObject bullet;
    public Transform fire_point;
    public bool shoot_anable = true;

    private float timer;
    public float fire_rate = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        main_camera = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Camera>();
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
        }
    }
}
