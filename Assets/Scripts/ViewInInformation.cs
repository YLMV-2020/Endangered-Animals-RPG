using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewInInformation : MonoBehaviour
{
    public static ViewInInformation Instance;

    public Text title;
    public Text description;
    public Image image;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadInformation(string name, string description)
    {
        this.title.text = name;
        this.description.text = description;
        this.image.sprite = Resources.Load<Sprite>("Animals/" + name);
    }
   
}
