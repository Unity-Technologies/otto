using System;
using UnityEngine;

public class PropHandler : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] GameObject apple;
    [SerializeField] GameObject bottle;
    [SerializeField] GameObject tableApple;
    [SerializeField] GameObject tableBottle;
#pragma warning restore 0649

    // Apple functions ---------------------------

    public void EnableApple()
    {
        apple.SetActive(true);
    }

    public void DisableApple()
    {
        apple.SetActive(false);
    }

    public void EnableTableApple()
    {
        tableApple.SetActive(true);
    }

    public void DisableTableApple()
    {
        tableApple.SetActive(false);
    }

    // Bottle functions ---------------------------

    public void EnableBottle()
    {
        bottle.SetActive(true);
    }

    public void DisableBottle()
    {
        bottle.SetActive(false);
    }

    public void EnableTableBottle()
    {
        tableBottle.SetActive(true);
    }

    public void DisableTableBottle()
    {
        tableBottle.SetActive(false);
    }
}
