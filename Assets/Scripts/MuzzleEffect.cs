using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleEffect : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject muzzle;
    public GameObject currentMuzzle;

    private void Start()
    {
        
    }

    public void MuzzleFlash()
    {
        currentMuzzle = Instantiate(muzzle, spawnPoint.position, spawnPoint.rotation);
        currentMuzzle.transform.parent = spawnPoint;
        Destroy(currentMuzzle, 0.2f);
    }
}
