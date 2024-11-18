using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDestroy : MonoBehaviour
{
    FireballSFXController fireballSFXController;

    private void Awake()
    {
        GameObject parent = transform.parent.gameObject;
        fireballSFXController = GetComponentInParent<FireballSFXController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Fireball & Player Boom!!!");
            fireballSFXController.CallFunctionsAfterParried();
            //change this!!!!!!!!!!!!!! This is just test!!!
        }
    }
}
