using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject fireball, fake_fireball, guided_fireball;
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
    public void ShootGuidedFireBall(GameObject DestinationPos, GameObject targetobj)
    {
        //fake_fireball.GetComponent<Fake_Fireball>().destinationPos = DestinationPos.transform.position;
        var obj = Instantiate(guided_fireball, transform);
        obj.GetComponent<Guided_Fireball>().target = targetobj;
    }
}
