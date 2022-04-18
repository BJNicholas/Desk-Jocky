using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTraits : MonoBehaviour
{
    public static GenericTraits instance;

    public Gradient colourSpectrum;
    [Header("Body Parts")]

    public Sprite[] eyes;
    public Sprite[] noses, mouths, beards, hairs;
    [Header("Clothing")]
    public Sprite[] hats;
    public Sprite[] shirts;
    [Header("Names")]
    public string[] surnames;
    public string[] male, female;

    private void Awake()
    {
        instance = this;
    }

}
