using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Bonus
{
    private GameObject[] _worms;
    private void Start()
    {
        
    }
    public void EnablePull()
    {
        Debug.Log("Вкл Магнит");
        _worms = GameObject.FindGameObjectsWithTag("Score");
        foreach (GameObject worm in _worms)
        {
            worm.GetComponent<LeftMoving>().EnableMovingToPlayer();
        }
        gameObject.SetActive(false);
    }
    public void DisablePull()
    {
        Debug.Log("Выкл Магнит");
        foreach (GameObject worm in _worms)
        {
            worm.GetComponent<LeftMoving>().DisableMovingToPlayer();
        }
    }
}