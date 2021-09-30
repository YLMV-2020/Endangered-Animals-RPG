using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CageController : MonoBehaviour
{
    public static CageController Instance;

    public GameObject[] cages;
    public int[] random;

    public int countEndangered;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        cages = GameObject.FindGameObjectsWithTag("Cage");

        random = new int[cages.Length];
        int c = 0;

        int TC = cages.Length;
        int TA = AnimalsData.Instance.animals.Length;

        for (int i = 0; i <TC; i++)
        {
            do
            {
                c = Random.Range(0, TA);
            }
            while (isRepeat(c, random, TC));

            random[i] = c;

            AnimalsData.Animal animal = AnimalsData.Instance.animals[c];

            if (animal.isEndangered) countEndangered++;

            cages[i].GetComponentInChildren<TMP_Text>().text = animal.name;/* + "\n Precio: " + animal.price;*/
            cages[i].GetComponentInChildren<Text>().text = random[i].ToString();
            cages[i].GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("Animals/" + animal.name);
        }

        ViewInGame.Instance.LoadGUI();
        Debug.Log("Peligro count: " + countEndangered);

    }

    bool isRepeat(int n, int[] num, int TC)
    {
        for (int i = 0; i < TC; i++)
            if (n == num[i])
                return true;
        return false;
    }

}
