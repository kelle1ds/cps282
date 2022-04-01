using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class girl : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public Text myText;
    //public GameObject bad;
    public Sprite sickGirl;
    public Sprite happyGirl;
    public Sprite hungryGirl;
    private Vector2 screenBounds;
    private Camera cam;
    private float time;
    public AudioSource audioSource;

    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = hungryGirl;
        audioSource = GetComponent<AudioSource>();
        //cam = Camera.main;
        //screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //GameObject a = Instantiate(character) as GameObject;
        // a.transform.position = new Vector2((-screenBounds.x + screenBounds.x)/2, -screenBounds.y + 15);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit Detected");
        if(other.gameObject.tag == "cherry")
        {
            addScore();
            Debug.Log("Cherry Detected");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = happyGirl;
            Destroy(other.gameObject);

        } else if (other.gameObject.tag == "spider")
        {
            deductScore();
            Debug.Log("Spider Detected");
            audioSource.Play();
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sickGirl;
            
            Destroy(other.gameObject);

            StartCoroutine(ExecuteAfterTime(2));
        }
        else
        {
            Debug.Log("nothing Detected");
        }
    }

    void addScore()
    {
        score++;
        myText.text = score.ToString();
    }
    void deductScore()
    {
        score--;
        myText.text = score.ToString();
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        
        yield return new WaitForSeconds(time);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = hungryGirl;

        // Code to execute after the delay
    }

    



}
