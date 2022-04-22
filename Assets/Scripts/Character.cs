using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Character : MonoBehaviour
{
    [Header("Settings")]
    [HideInInspector]public bool murderer;
    public bool witness;


    [Header("Traits")]
    public string fullName;
    [HideInInspector]
    public string firstName, lastName;
    public float height = 175f;
    public int age;
    public Color32 skinColour;
    public GameManager.professions profession;
    public GameManager.locations alibi;
    [HideInInspector] public bool bearded, wearingHat;
    public GameObject head, eyes, nose, mouth, beard, hair, hat, shirt,armL,armR, pants;
    [Range(-3f, 3f)] public float voice;

    public List<GameObject> items;

    [Space]
    public Image veil;

    private void Start()
    {
        if(witness) RandomiseCharacter();
    }

    public void CalculateHeight()
    {
        height = Mathf.Round(height = Random.Range(135f, 205f));
        float differenceFromBase = height - 135;
        pants.transform.localScale += new Vector3(0, differenceFromBase/100, 0);
        pants.transform.position -= new Vector3(0, differenceFromBase/200, 0);
        transform.position -= new Vector3(0, -differenceFromBase / 200, 0);
    }
    public void GenerateName()
    { 
        firstName = GenericTraits.instance.male[Random.Range(0, GenericTraits.instance.male.Length)];
        lastName = GenericTraits.instance.surnames[Random.Range(0, GenericTraits.instance.surnames.Length)];

        fullName = firstName + " " + lastName;
    }


    public void RandomiseCharacter()
    {
        CalculateHeight();
        GenerateName();
        age = Random.Range(18, 80);
        profession = (GameManager.professions)Random.Range(0, 6);// alter this if you add more jobs
        voice = Random.Range(-3f, 3f);
        GenerateRandomItems();
        //GetComponent<AudioSource>().pitch = voice;
        skinColour = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0.1f, 0.6f));
        bearded = (Random.value > 0.5f);
        wearingHat = (Random.value > 0.5f);
        if (bearded)
        {
            beard.SetActive(true);
            beard.GetComponent<SpriteRenderer>().sprite = GenericTraits.instance.beards[Random.Range(0, GenericTraits.instance.beards.Length)];
        }
        if (wearingHat)
        {
            hat.SetActive(true);
            hat.GetComponent<SpriteRenderer>().sprite = GenericTraits.instance.hats[Random.Range(0, GenericTraits.instance.hats.Length)];
        }
        //getting traits from generic
        eyes.GetComponent<SpriteRenderer>().sprite = GenericTraits.instance.eyes[Random.Range(0, GenericTraits.instance.eyes.Length)];
        nose.GetComponent<SpriteRenderer>().sprite = GenericTraits.instance.noses[Random.Range(0, GenericTraits.instance.noses.Length)];
        mouth.GetComponent<SpriteRenderer>().sprite = GenericTraits.instance.mouths[Random.Range(0, GenericTraits.instance.mouths.Length)];
        hair.GetComponent<SpriteRenderer>().sprite = GenericTraits.instance.hairs[Random.Range(0, GenericTraits.instance.hairs.Length)];
        shirt.GetComponent<SpriteRenderer>().sprite = GenericTraits.instance.shirts[Random.Range(0, GenericTraits.instance.shirts.Length)];

        //randomising colours
        eyes.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0.5f, 1f));
        nose.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0.3f, 1f));
        mouth.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0.3f, 1f));
        hair.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0, 1f));
        beard.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0.2f, 1f));
        hat.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0, 1f));
        pants.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0.7f, 1f));
        shirt.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0, 0.7f));
        armL.GetComponent<SpriteRenderer>().color = shirt.GetComponent<SpriteRenderer>().color;
        armR.GetComponent<SpriteRenderer>().color = shirt.GetComponent<SpriteRenderer>().color;

        //skin colours
        head.GetComponent<SpriteRenderer>().color = skinColour;

    }
    public void GenerateMurdererCharacter() //fix this please, it is too random rn
    {
        murderer = true;
        CalculateHeight();
        GenerateName();
        MurderManager.instance.PickMurdererProfession(gameObject);
        MurderManager.instance.GenerateMurderAge(gameObject);
        MurderManager.instance.GenerateMurdererItems(gameObject);
        voice = Random.Range(-3f, 3f);
        //GetComponent<AudioSource>().pitch = voice;
        skinColour = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0.1f, 0.6f));
        bearded = (Random.value > 0.5f);
        wearingHat = (Random.value > 0.5f);
        if (bearded)
        {
            beard.SetActive(true);
            beard.GetComponent<SpriteRenderer>().sprite = GenericTraits.instance.beards[Random.Range(0, GenericTraits.instance.beards.Length)];
        }
        if (wearingHat)
        {
            hat.SetActive(true);
            hat.GetComponent<SpriteRenderer>().sprite = GenericTraits.instance.hats[Random.Range(0, GenericTraits.instance.hats.Length)];
        }
        //getting traits from generic
        eyes.GetComponent<SpriteRenderer>().sprite = GenericTraits.instance.eyes[Random.Range(0, GenericTraits.instance.eyes.Length)];
        nose.GetComponent<SpriteRenderer>().sprite = GenericTraits.instance.noses[Random.Range(0, GenericTraits.instance.noses.Length)];
        mouth.GetComponent<SpriteRenderer>().sprite = GenericTraits.instance.mouths[Random.Range(0, GenericTraits.instance.mouths.Length)];
        hair.GetComponent<SpriteRenderer>().sprite = GenericTraits.instance.hairs[Random.Range(0, GenericTraits.instance.hairs.Length)];
        shirt.GetComponent<SpriteRenderer>().sprite = GenericTraits.instance.shirts[Random.Range(0, GenericTraits.instance.shirts.Length)];

        //randomising colours
        eyes.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0.5f, 1f));
        nose.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0.3f, 1f));
        mouth.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0.3f, 1f));
        hair.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0, 1f));
        beard.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0.2f, 1f));
        hat.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0, 1f));
        pants.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0.7f, 1f));
        shirt.GetComponent<SpriteRenderer>().color = GenericTraits.instance.colourSpectrum.Evaluate(Random.Range(0, 0.7f));
        armL.GetComponent<SpriteRenderer>().color = shirt.GetComponent<SpriteRenderer>().color;
        armR.GetComponent<SpriteRenderer>().color = shirt.GetComponent<SpriteRenderer>().color;

        //skin colours
        head.GetComponent<SpriteRenderer>().color = skinColour;
    }

    public void GenerateRandomItems()
    {
        //cane
        if(age > 60)
        {
            GiveItem(GameManager.instance.items[0], 0.66f);
        }
        else
        {
            GiveItem(GameManager.instance.items[0], 0.1f);
        }
        //knife
        GiveItem(GameManager.instance.items[1], 0.33f);
        //Pistol
        if(profession == GameManager.professions.Soldier)
        {
            GiveItem(GameManager.instance.items[2], 1f);
        }
        else
        {
            GiveItem(GameManager.instance.items[2], 0.25f);
        }
        //poison
        if(profession == GameManager.professions.Bartender)
        {
            GiveItem(GameManager.instance.items[3], 0.33f);
        }
        else if (profession == GameManager.professions.Chef)
        {
            GiveItem(GameManager.instance.items[3], 0.33f);
        }
        else if (profession == GameManager.professions.Doctor)
        {
            GiveItem(GameManager.instance.items[3], 0.33f);
        }
        else
        {
            GiveItem(GameManager.instance.items[3], 0.1f);
        }

    }

    public void GiveItem(GameObject item, float chanceOfHavingItem)
    {
        float roll = Random.Range(0f, 1f);
        if(roll <= chanceOfHavingItem) items.Add(item);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) //left click
        {
            GameManager.instance.selectedSuspect = gameObject;

            //enable veil for all suspects
            GameObject[] suspects = GameObject.FindGameObjectsWithTag("Suspect");
            for (int i = 0; i < suspects.Length; i++)
            {
                suspects[i].GetComponent<Character>().veil.enabled = true;
            }
            //disable the veil for selected
            veil.enabled = false;

            GetComponent<AudioSource>().Play();
        }
        else if(Input.GetMouseButtonDown(1)) //right click
        {
            gameObject.SetActive(false);
        }
    }

}
