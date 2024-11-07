using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disabler : MonoBehaviour
{
    [SerializeField] GameObject myObject;
    //private PosolZone zone;
    public GameObject player;

    private void Start()
    {
        //tutorialPart = 0;
       player = GameObject.FindWithTag("Player");

    }
    public void Off()
    {
        player.GetComponent<HeroController>().enabled = true;
        player.GetComponent<Animator>().SetBool("Cutscene", false);

        myObject.SetActive(false);

    }
}
