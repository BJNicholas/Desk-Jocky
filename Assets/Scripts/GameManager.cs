using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] suspects;
    public GameObject[] items;

    public GameObject selectedSuspect = null;

    public GameObject caseCompleteMenu;


    public enum causesOfDeath
    {
        Stabbed,
        Shot,
        Strangled,
        Poisoned,
        Beaten,
        debug
    }
    public enum professions
    {
        Labourer,
        Bartender,
        Soldier,
        Butcher,
        Chef,
        Doctor,
        debug
    }
    public enum weapons
    {
        Knife,
        Scalpel,
        Pistol,
        Rifle,
        Hands,
        Cane,
        Poison,
        debug
    }
    public enum locations
    {
        Home,
        Work,
        Restaurant,
        Shops,
        debug
    }


    private void Awake()
    {
        instance = this;
    }
}
