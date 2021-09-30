using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CageController : MonoBehaviour
{

    public GameObject[] cages;

    void Start()
    {
        cages = GameObject.FindGameObjectsWithTag("Cage");
    }


    void Update()
    {
        for (int i = 0; i < cages.Length; i++)
        {
            if (i < AnimalsData.Instance.animals.Length)
            {
                AnimalsData.Animal animal = AnimalsData.Instance.animals[i];
                cages[i].GetComponentInChildren<TMP_Text>().text = animal.name;/* + "\n Precio: " + animal.price;*/
                cages[i].GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("Animals/" + animal.name);
            }
            
        }
    }
}
