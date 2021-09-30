using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LeftMoving))]
public class Shield : Bonus
{
    public void OnPlayer(PlayerCollisionSystem player)
    {
        player.EnableInvulnerability();
        transform.SetParent(player.transform);
        transform.position = player.transform.position;
        GetComponent<LeftMoving>().enabled = false;
        transform.localScale = new Vector3(2.4f, 2.4f, 1);
    }
    public void FromPlayer(PlayerCollisionSystem player)
    {
        player.DisableInvulnerability();
        transform.SetParent(null);
        transform.localScale = Vector3.one;
        gameObject.SetActive(false);
        GetComponent<LeftMoving>().enabled = true;
    }
}