using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int pluto;
    public Text PlutoUI;
    public ShopItemSO[] shopItemsSO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;

    // Start is called before the first frame update
    void Start()
    {
        PlutoUI.text = "Pluto's : " + pluto.ToString();
        LoadPanels();
        CheckPurchaseable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPurchaseable()
    {
        for(int i = 0; i < shopItemsSO.Length; i++)
        {
            if (pluto >= shopItemsSO[i].baseCost)
            {
                myPurchaseBtns[i].interactable = true;
            }
            else
            {
                myPurchaseBtns[i].interactable = false;
            }
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if (pluto >= shopItemsSO[btnNo].baseCost)
        {
            pluto = pluto - shopItemsSO[btnNo].baseCost;
            PlutoUI.text = "Pluto's : " + pluto.ToString();
            CheckPurchaseable();
        }
    }

    public void DeUpgrade(int btnNo)
    {
        pluto = pluto + shopItemsSO[btnNo].baseCost;
        PlutoUI.text = "Pluto's : " + pluto.ToString();
        CheckPurchaseable();
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
