using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject fireball, fake_fireball;
    public void ShootFireball(GameObject DestinationPos)
    {
        fireball.GetComponent<Fireball>().destinationPos = DestinationPos.transform.position;
        Instantiate(fireball, transform);
    }

    void ShootFakeFireBall(GameObject DestinationPos)
    {
        //fake_fireball.GetComponent<Fake_Fireball>().destinationPos = DestinationPos.transform.position;
        Instantiate(fake_fireball, transform);
    }
}
