using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] weapons;
    public float delay = 1;

    float count = 1;
    private void FixedUpdate()
    {
        count -= 1 * Time.deltaTime;

        if (count <= 0) spawnWeapon();
    }

    void spawnWeapon()
    {
        count = delay;
        GameObject newWeapon = Instantiate(weapons[Random.Range(0, weapons.Length)], transform);
    }
}
