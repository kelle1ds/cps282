using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));


    }



    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < (-screenBounds.y + 5))
        {
            Destroy(this.gameObject);
        }
    }
}
