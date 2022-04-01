using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCherry : MonoBehaviour
{
    public GameObject cherryPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {

        cam = Camera.main;
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(cherryWave());
    }

    private void spawnCherry()
    {
        GameObject a = Instantiate(cherryPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x),  screenBounds.y * 1);
    }

    IEnumerator cherryWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnCherry();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
