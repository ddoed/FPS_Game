using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IInteract
{
    public GameObject player;
    public AudioSource healSound;
    public void Interact()
    {
        PlayerHealthUI healthUI = player.GetComponent<PlayerHealthUI>();
        if(healthUI.score >= 30)
        {
            healSound.Play();
            healthUI.RestoreHealth(10);
            healthUI.DecreaseCoin(30);
        }
    }
}
