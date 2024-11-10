using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disabler : MonoBehaviour
{
    [SerializeField] GameObject myObject;
    public HeroController player;

    private void Start()
    {
       player = GameObject.FindWithTag("Player").GetComponent<HeroController>();
    }
    public void Off()
    {
        player.enabled = true;
        player.GetComponent<Animator>().SetBool("Cutscene", false);

        myObject.SetActive(false);
        player.EnableMovement();
    }
}
