using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RoomSwitch : MonoBehaviour
{
    public static RoomSwitch instance;

    public GameObject player;
    public GameObject playerBack;
    public GameObject playerFront;

    public GameObject r1spawn;
    public GameObject r2Aspawn;
    public GameObject r2Bspawn;

    private void Start()
    {
        instance = this;
    }

    private IEnumerator SwitchCooldown(Vector3 tp)
    {
        PlayerMovement.instance.active = false;
        player.GetComponent<CharacterController>().enabled = false;

        yield return new WaitForSeconds(0.5f);

        Vector3 dist = tp - transform.position;

        if(dist.z < 0)
        {
            player.transform.position = playerFront.transform.position;
        }
        else
        {
            player.transform.position = playerBack.transform.position;
        }
        transform.Translate(dist);
        player.GetComponent<CharacterController>().enabled = true;
        PlayerMovement.instance.active = true;
    }

    public void ToRoom1()
    {
        StartCoroutine(SwitchCooldown(r1spawn.transform.position));
    }

    public void ToRoom2A()
    {
        StartCoroutine(SwitchCooldown(r2Aspawn.transform.position));
    }

    public void ToRoom2B()
    {
        StartCoroutine(SwitchCooldown(r2Bspawn.transform.position));
    }
}