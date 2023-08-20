using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    private Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PickUpFish();
        }
    }

    private void PickUpFish()
    {


        anim?.SetTrigger("Pickup");
        GameStats.Instance.CollectFish();

        //increment the fish count

        //increment the score

        //play sfx


        //trigger a animation

    }

    public void OnShowChunk()
    {
        anim?.SetTrigger("Idle");
    }


}
