using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : MonoBehaviour
{
    public static ViewInGame Instance;
    public Text text_rescued;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadGUI()
    {
        text_rescued.text = "0/" + CageController.Instance.countEndangered.ToString();
    }
}
