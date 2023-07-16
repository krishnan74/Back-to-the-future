using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ShopItemSO[] shopItemsSO;
    public ShopTemplate[] shopPanels;

    // Start is called before the first frame update
    void Start()
    {
        LoadPanels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPanels()
    {
        for(int i=0;i<shopItemsSO.Length;i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Plutos : " + shopItemsSO[i].baseCost.ToString();
        }
    }
}
