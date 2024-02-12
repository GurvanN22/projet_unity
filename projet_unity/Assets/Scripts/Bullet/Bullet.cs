using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mouse_position;
    private Camera main_camera;
    private Rigidbody2D rb;
    public float force = 5f;
    // Start is called before the first frame update
    void Start()
    {
        main_camera = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mouse_position = main_camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mouse_position - transform.position;
        Vector3 rotation = transform.position - mouse_position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float z_axe_rotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, z_axe_rotation);

        Invoke("destroy_bullet", 2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void destroy_bullet()
    {
        Destroy(gameObject);
    }
}
