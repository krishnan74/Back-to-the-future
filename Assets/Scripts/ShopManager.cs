using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace FlowControllerlast
{
    public class ShopManager : MonoBehaviour
    {
        public Text PlutoUI;
        public ShopItemSO[] shopItemsSO;
        public ShopTemplate[] shopPanels;
        public Button[] myPurchaseBtns;

        // Start is called before the first frame update
        void Start()
        {
            PlutoUI.text = "Pluto's : " + StateManager.plutoCount.ToString();
            LoadPanels();
            CheckPurchaseable();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void CheckPurchaseable()
        {
            for (int i = 0; i < shopItemsSO.Length; i++)
            {
                if (StateManager.plutoCount >= shopItemsSO[i].baseCost)
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

            if (StateManager.plutoCount >= shopItemsSO[btnNo].baseCost)
            {
                switch (btnNo)
                {
                    case 0:
                        Inc_IncreasedHealthSpawn();
                        break;

                    case 1:
                        Inc_HealthIncrementCollect();
                        break;
                    case 2:
                        Inc_LessDamageFromEnemy();
                        break;

                    case 3:
                        Inc_IncreasedPlutoFromEnemy();
                        break;

                    case 4:
                        Inc_IncreasedPlutoSpawn();
                        break;

                    case 5:
                        Inc_SlowEnemySpeed();
                        break;

                    case 6:
                        Inc_IncreasedHeroSpeed();
                        break;

                    case 7:
                        Inc_DamageIncrement();
                        break;

                    case 8:
                        Inc_PowerIncrement();
                        break;
                }
            
                StateManager.plutoCount = StateManager.plutoCount - shopItemsSO[btnNo].baseCost;
                PlutoUI.text = "Pluto's : " + StateManager.plutoCount.ToString();
                CheckPurchaseable();
            }
        }
        public void DeUpgrade(int btnNo)
        {
            if (StateManager.plutoCount >= shopItemsSO[btnNo].baseCost)
            {
                switch (btnNo)
                {
                    case 0:
                        Dec_IncreasedHealthSpawn();
                        break;

                    case 1:
                        Dec_HealthIncrementCollect();
                        break;

                    case 2:
                        Dec_LessDamageFromEnemy();
                        break;

                    case 3:
                        Dec_IncreasedPlutoFromEnemy();
                        break;

                    case 4:
                        Dec_IncreasedPlutoSpawn();
                        break;

                    case 5:
                        Dec_SlowEnemySpeed();
                        break;

                    case 6:
                        Dec_IncreasedHeroSpeed();
                        break;

                    case 7:
                        Dec_DamageIncrement();
                        break;

                    case 8:
                        Dec_PowerIncrement();
                        break;
                }
            
                StateManager.plutoCount = StateManager.plutoCount + shopItemsSO[btnNo].baseCost;
                PlutoUI.text = "Pluto's : " + StateManager.plutoCount.ToString();
                CheckPurchaseable();
            }
        }

        public void LoadPanels()
        {
            for (int i = 0; i < shopItemsSO.Length; i++)
            {
                shopPanels[i].titleTxt.text = shopItemsSO[i].title;
                shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
                shopPanels[i].costTxt.text = "Plutos : " + shopItemsSO[i].baseCost.ToString();
            }
        }

        public Text UpgradeStatus;
        public Text DegradeStatus;
        public void Dec_DamageIncrement()
        {
            StartCoroutine(FlowControllerlast.Instance.Dec_DamageIncrement(OnDegradeSuccess, OnDegradeFailure));
        }

        public void Dec_HealthIncrementCollect()
        {
            StartCoroutine(FlowControllerlast.Instance.Dec_HealthIncrementCollect(OnDegradeSuccess, OnDegradeFailure));
        }
        public void Dec_IncreasedHealthSpawn()
        {
            StartCoroutine(FlowControllerlast.Instance.Dec_IncreasedHealthSpawn(OnDegradeSuccess, OnDegradeFailure));
        }
        public void Dec_IncreasedPlutoFromEnemy()
        {
            StartCoroutine(FlowControllerlast.Instance.Dec_IncreasedPlutoFromEnemy(OnDegradeSuccess, OnDegradeFailure));
        }
        public void Dec_IncreasedPlutoSpawn()
        {
            StartCoroutine(FlowControllerlast.Instance.Dec_IncreasedPlutoSpawn(OnDegradeSuccess, OnDegradeFailure));
        }
        public void Dec_IncreasedHeroSpeed()
        {
            StartCoroutine(FlowControllerlast.Instance.Dec_IncreasedHeroSpeed(OnDegradeSuccess, OnDegradeFailure));
        }
        public void Dec_LessDamageFromEnemy()
        {
            StartCoroutine(FlowControllerlast.Instance.Dec_LessDamageFromEnemy(OnDegradeSuccess, OnDegradeFailure));
        }
        public void Dec_PowerIncrement()
        {
            StartCoroutine(FlowControllerlast.Instance.Dec_PowerIncrement(OnDegradeSuccess, OnDegradeFailure));
        }
        public void Dec_SlowEnemySpeed()
        {
            StartCoroutine(FlowControllerlast.Instance.Dec_SlowEnemySpeed(OnDegradeSuccess, OnDegradeFailure));
        }

        public void OnDegradeSuccess()
        {
            DegradeStatus.text = "Successfull";
            Debug.Log("Degrade Successfull");
        }
        public void OnDegradeFailure()
        {
            DegradeStatus.text = "UnSuccessfull Try Again";
            Debug.Log("Degrade UnSuccessfull");
        }


        public void Inc_DamageIncrement()
        {
            StartCoroutine(FlowControllerlast.Instance.Inc_DamageIncrement(OnUpgradeSuccess, OnUpgradeFailure));
        }

        public void Inc_HealthIncrementCollect()
        {
            StartCoroutine(FlowControllerlast.Instance.Inc_HealthIncrementCollect(OnUpgradeSuccess, OnUpgradeFailure));
        }
        public void Inc_IncreasedHealthSpawn()
        {
            StartCoroutine(FlowControllerlast.Instance.Inc_IncreasedHealthSpawn(OnUpgradeSuccess, OnUpgradeFailure));
        }
        public void Inc_IncreasedPlutoFromEnemy()
        {
            StartCoroutine(FlowControllerlast.Instance.Inc_IncreasedPlutoFromEnemy(OnUpgradeSuccess, OnUpgradeFailure));
        }
        public void Inc_IncreasedPlutoSpawn()
        {
            StartCoroutine(FlowControllerlast.Instance.Inc_IncreasedPlutoSpawn(OnUpgradeSuccess, OnUpgradeFailure));
        }
        public void Inc_IncreasedHeroSpeed()
        {
            StartCoroutine(FlowControllerlast.Instance.Inc_IncreasedHeroSpeed(OnUpgradeSuccess, OnUpgradeFailure));
        }
        public void Inc_LessDamageFromEnemy()
        {
            StartCoroutine(FlowControllerlast.Instance.Inc_LessDamageFromEnemy(OnUpgradeSuccess, OnUpgradeFailure));
        }
        public void Inc_PowerIncrement()
        {
            StartCoroutine(FlowControllerlast.Instance.Inc_PowerIncrement(OnUpgradeSuccess, OnUpgradeFailure));
        }
        public void Inc_SlowEnemySpeed()
        {
            StartCoroutine(FlowControllerlast.Instance.Inc_SlowEnemySpeed(OnUpgradeSuccess, OnUpgradeFailure));
        }

        public void OnUpgradeSuccess()
        {
            UpgradeStatus.text = "Successfull";
            Debug.Log("Upgrade Successfull");
        }
        public void OnUpgradeFailure()
        {
            UpgradeStatus.text = "UnSuccessfull Try Again";
            Debug.Log("Upgrade UnSuccessfull");
        }

    }
}