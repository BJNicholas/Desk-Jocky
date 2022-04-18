using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FingerprintGenerator : MonoBehaviour
{
    public bool randomise = true;

    public GameObject arch;
    public GameObject point;
    [Range(50,100)]
    public int numOfArches = 50;
    public Vector2 archSizeLimits;

    private void Start()
    {
        if(randomise) GenerateImage();
    }


    public void GenerateImage()
    {
        point = Instantiate(point, transform);
        float pictureWidth = gameObject.GetComponent<RectTransform>().sizeDelta.x / 2;
        pictureWidth -= pictureWidth / 4;
        float pictureHeight = gameObject.GetComponent<RectTransform>().sizeDelta.y / 2;
        pictureHeight -= pictureHeight / 4;
        point.GetComponent<RectTransform>().localPosition = new Vector3(Random.Range(-pictureWidth, pictureWidth) - 3, Random.Range(-pictureHeight,pictureHeight) - 5, 0);

        while(numOfArches != 0)
        {
            GameObject newArch = Instantiate(arch, transform);
            newArch.GetComponent<RectTransform>().localPosition = new Vector3(Random.Range(-pictureWidth, pictureWidth), Random.Range(-pictureHeight, pictureHeight), 0);

            //Vector3 direction = newArch.transform.position - point.transform.position;
            //newArch.GetComponent<RectTransform>().LookAt(-direction);

            Vector3 relative = newArch.transform.InverseTransformPoint(point.transform.position);
            float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            newArch.transform.rotation = Quaternion.Euler(0, 0, -angle);

            newArch.transform.localScale = new Vector3(1, -1, 1);
            float distance = Vector2.Distance(newArch.transform.position, point.transform.position);
            newArch.GetComponent<RectTransform>().sizeDelta = new Vector2(Random.Range(archSizeLimits.x, archSizeLimits.y) + distance / 3, Random.Range(archSizeLimits.x, archSizeLimits.y));

            numOfArches -= 1;
        }
    }
}
