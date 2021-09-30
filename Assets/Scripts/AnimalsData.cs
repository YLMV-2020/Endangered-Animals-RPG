using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AnimalsData : MonoBehaviour
{
	public static AnimalsData Instance;

	[Serializable]
    public class Animal
    {
        public string name;
        public float price;
        public string description;
        public bool isEndangered;
    }

    [Header("JSON")]
    public string fileName = "animals";
    public Animal[] animals;
    private string fileFormat = ".json";

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		StartCoroutine(LoadJsonData());
	}

	#region JSON ------------------------------------

	IEnumerator LoadJsonData()
	{

		string filePath = Path.Combine(Application.streamingAssetsPath, fileName + fileFormat);
		LoadData(filePath);

		yield return null;
	}

	private void LoadData(string _filePath)
	{
		if (File.Exists(_filePath))
		{
			string fileJson = File.ReadAllText(_filePath);
			animals = JsonController.FromJsonArray<Animal>(fileJson);
		}
		else
		{
			Debug.LogError("<color=red><b>" + "ERROR: " + "</b></color>" + "No se encontro el archivo JSON. ");
		}
	}

	#endregion ----------------------------------
}
