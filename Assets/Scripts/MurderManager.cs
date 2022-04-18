using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MurderManager : MonoBehaviour
{
    public static MurderManager instance;
    public GameObject murderer;
    public GameObject fingerPrint;
    [Header("Victim Details")]
    public string victimName;
    public float victimHeight;
    public float victimAge;
    public GameManager.professions victimProfession;
    public GameManager.causesOfDeath causeOfDeath;
    public GameManager.weapons murderWeapon;
    public GameManager.locations murderLocation;

    public string witnessStatement = "";
    [Range(0,24)]public float timeOfDeath;

    private void Start()
    {
        instance = this;
        GenerateScenario();
        GenerateSuspects();
        GenerateName();
        victimHeight = Mathf.Round(victimHeight = Random.Range(135f, 205f));
        victimAge = Random.Range(18, 80);
    }
    public void GenerateName()
    {
        string firstName = GenericTraits.instance.male[Random.Range(0, GenericTraits.instance.male.Length)];
        string lastName = GenericTraits.instance.surnames[Random.Range(0, GenericTraits.instance.surnames.Length)];

        victimName = firstName + " " + lastName;
    }


    public void GenerateScenario()
    {
        victimProfession = (GameManager.professions)Random.Range(0, 6);// alter this if you add more jobs
        murderWeapon = (GameManager.weapons)Random.Range(0, 7);// alter this if you add more weapons
        murderLocation = (GameManager.locations)Random.Range(0, 4);// alter this if you add more weapons
        CreateCauseOfDeath();
        timeOfDeath = Random.Range(0, 24);
    }

    public void CreateCauseOfDeath()
    {
        int numOfPossibleCauses = 0;
        //Stabbing tools
        if(murderWeapon == GameManager.weapons.Knife)
        {
            numOfPossibleCauses = 1;
            causeOfDeath = GameManager.causesOfDeath.Stabbed;
        }
        else if (murderWeapon == GameManager.weapons.Scalpel)
        {
            numOfPossibleCauses = 1;
            causeOfDeath = GameManager.causesOfDeath.Stabbed;
        }
        //guns
        else if (murderWeapon == GameManager.weapons.Pistol)
        {
            numOfPossibleCauses = 1;
            causeOfDeath = GameManager.causesOfDeath.Shot;
        }
        else if (murderWeapon == GameManager.weapons.Rifle)
        {
            numOfPossibleCauses = 1;
            causeOfDeath = GameManager.causesOfDeath.Shot;
        }
        //Blunt objects
        else if (murderWeapon == GameManager.weapons.Hands)
        {
            numOfPossibleCauses = 2;
            int roll = Random.Range(0, numOfPossibleCauses);
            if(roll == 0)
            {
                causeOfDeath = GameManager.causesOfDeath.Strangled;
            }
            if (roll == 1)
            {
                causeOfDeath = GameManager.causesOfDeath.Beaten;
            }
        }
        else if (murderWeapon == GameManager.weapons.Cane)
        {
            numOfPossibleCauses = 2;
            int roll = Random.Range(0, numOfPossibleCauses);
            if (roll == 0)
            {
                causeOfDeath = GameManager.causesOfDeath.Strangled;
            }
            if (roll == 1)
            {
                causeOfDeath = GameManager.causesOfDeath.Beaten;
            }
        }
        //Poison
        else if (murderWeapon == GameManager.weapons.Poison)
        {
            numOfPossibleCauses = 1;
            causeOfDeath = GameManager.causesOfDeath.Poisoned;
        }
    }

    public void GenerateSuspects()
    {
        int roll = Random.Range(0, GameManager.instance.suspects.Length);
        foreach(GameObject character in GameManager.instance.suspects)
        {
            if(GameManager.instance.suspects[roll] == character)
            {
                //gen Murderer
                character.GetComponent<Character>().GenerateMurdererCharacter();
                murderer = character;
            }
            else
            {
                character.GetComponent<Character>().RandomiseCharacter();
            }
        }
    }
   
    public void PickMurdererProfession(GameObject murderer)
    {
        int numOfPossibleCauses = 0;
        //Stabbing tools
        if (murderWeapon == GameManager.weapons.Knife)
        {
            numOfPossibleCauses = 6;
            int roll = Random.Range(0, numOfPossibleCauses);
            if (roll == 0)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Labourer;
            }
            else if (roll == 1)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Bartender;
            }
            else if (roll == 2)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Soldier;
            }
            else if (roll == 3)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Butcher;
            }
            else if (roll == 4)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Chef;
            }
            else if (roll == 5)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Doctor;
            }
        }
        else if (murderWeapon == GameManager.weapons.Scalpel)
        {
            numOfPossibleCauses = 1;
            murderer.GetComponent<Character>().profession = GameManager.professions.Doctor;

        }
        //guns
        else if (murderWeapon == GameManager.weapons.Pistol)
        {
            numOfPossibleCauses = 6;
            int roll = Random.Range(0, numOfPossibleCauses);
            if (roll == 0)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Labourer;
            }
            else if (roll == 1)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Bartender;
            }
            else if (roll == 2)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Soldier;
            }
            else if (roll == 3)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Butcher;
            }
            else if (roll == 4)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Chef;
            }
            else if (roll == 5)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Doctor;
            }
        }
        else if (murderWeapon == GameManager.weapons.Rifle)
        {
            numOfPossibleCauses = 1;
            murderer.GetComponent<Character>().profession = GameManager.professions.Soldier;
        }
        //Blunt objects
        else if (murderWeapon == GameManager.weapons.Hands)
        {
            numOfPossibleCauses = 6;
            int roll = Random.Range(0, numOfPossibleCauses);
            if (roll == 0)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Labourer;
            }
            else if (roll == 1)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Bartender;
            }
            else if (roll == 2)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Soldier;
            }
            else if (roll == 3)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Butcher;
            }
            else if (roll == 4)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Chef;
            }
            else if (roll == 5)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Doctor;
            }
        }
        else if (murderWeapon == GameManager.weapons.Cane)
        {
            numOfPossibleCauses = 6;
            int roll = Random.Range(0, numOfPossibleCauses);
            if (roll == 0)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Labourer;
            }
            else if (roll == 1)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Bartender;
            }
            else if (roll == 2)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Soldier;
            }
            else if (roll == 3)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Butcher;
            }
            else if (roll == 4)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Chef;
            }
            else if (roll == 5)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Doctor;
            }
        }
        //Poison
        else if (murderWeapon == GameManager.weapons.Poison)
        {
            numOfPossibleCauses = 4;
            int roll = Random.Range(0, numOfPossibleCauses);
            if (roll == 0)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Doctor;
            }
            else if (roll == 1)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Bartender;
            }
            else if (roll == 2)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Chef;
            }
            else if (roll == 3)
            {
                murderer.GetComponent<Character>().profession = GameManager.professions.Butcher;
            }
        }
    }
    public void GenerateMurderAge(GameObject murderer)
    {
        //Stabbing tools
        if (murderWeapon == GameManager.weapons.Knife)
        {
            murderer.GetComponent<Character>().age = Random.Range(18, 65);
        }
        else if (murderWeapon == GameManager.weapons.Scalpel)
        {
            murderer.GetComponent<Character>().age = Random.Range(18, 65);
        }
        //guns
        else if (murderWeapon == GameManager.weapons.Pistol)
        {
            murderer.GetComponent<Character>().age = Random.Range(18, 80);
        }
        else if (murderWeapon == GameManager.weapons.Rifle)
        {
            murderer.GetComponent<Character>().age = Random.Range(18, 80);
        }
        //Blunt objects
        else if (murderWeapon == GameManager.weapons.Hands)
        {
            murderer.GetComponent<Character>().age = Random.Range(18, 55);
        }
        else if (murderWeapon == GameManager.weapons.Cane)
        {
            murderer.GetComponent<Character>().age = Random.Range(18, 80);
        }
        //Poison
        else if (murderWeapon == GameManager.weapons.Poison)
        {
            murderer.GetComponent<Character>().age = Random.Range(18, 80);
        }
    }

    public void GenerateMurdererItems(GameObject murderer)
    {
        if(murderWeapon == GameManager.weapons.Knife)
        {
            murderer.GetComponent<Character>().GiveItem(GameManager.instance.items[1], 1f);
        }
        else if (murderWeapon == GameManager.weapons.Pistol)
        {
            murderer.GetComponent<Character>().GiveItem(GameManager.instance.items[2], 1f);
        }
        else if (murderWeapon == GameManager.weapons.Cane)
        {
            murderer.GetComponent<Character>().GiveItem(GameManager.instance.items[0], 1f);
        }
        else if (murderWeapon == GameManager.weapons.Poison)
        {
            murderer.GetComponent<Character>().GiveItem(GameManager.instance.items[3], 1f);
        }
        else
        {
            //nothing for you bozo
        }
    }

    public void GenerateWitnessStatement(GameObject murderer)
    {
        //descripters for height , age and beardedness
    }


}
