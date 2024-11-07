using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PosolZone : MonoBehaviour
{
    //public int tutorialPart;
    //public int tutorialPart;
    [SerializeField] Image image;
    public GameObject player;
    [SerializeField] GameObject posol;
    [SerializeField] float posolSpeed;
    Rigidbody2D body;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        //tutorialPart = 0;
        //scene = false;
        body = player.GetComponent<Rigidbody2D>(); 
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HeroController>(out var vorplayer))
        {
            player = GameObject.FindWithTag("Player");
            Debug.Log("Триггер свершён");
            PosolMessage();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HeroController>(out var vorplayer))
        {
            posol.transform.position = Vector2.MoveTowards(posol.transform.position, player.transform.position, posolSpeed * Time.deltaTime);
            //print("Stay");
        }
        if(Vector3.Distance(posol.transform.position, player.transform.position) <= 3)
        {
            //posolSpeed = 0;
            ShowTutorial();
            this.gameObject.SetActive(false);
            posol.SetActive(false);
        }
    }
    public void PosolMessage()
    {
        print("fhgfhfhfghfh");
        posol.SetActive(true); 
        Vector2 pos = new Vector2(player.transform.position.x - 9, posol.transform.position.y);
        //Vector2 pos = new Vector2(body.velocity.x/Mathf.Abs(body.velocity.x) * posolSpeed, body.velocity.y);
        //posol.GetComponent<Rigidbody2D>().velocity = pos;
        posol.transform.position = pos;
        player.GetComponent<Animator>().SetBool("Cutscene", true);
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<HeroController>().enabled = false;
        //ShowTutorial();
        //this.gameObject.SetActive(false);
    }


    /* public void Close()
     {
         gameObject.SetActive(false);
     }*/
    public void ShowTutorial()
    {
        image.gameObject.SetActive(true);
    }
}
