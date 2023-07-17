using System.Collections.Generic;
using DapperLabs.Flow.Sdk.Cadence;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Numerics;


namespace FlowControllerlast
{

    public class ShopController : MonoBehaviour
    {

        public Text UpgradeStatus;
        public Text DegradeStatus;
        public void Dec_DamageIncrement(){
            StartCoroutine(FlowControllerlast.Instance.Dec_DamageIncrement(OnDegradeSuccess, OnDegradeFailure));
        }

        public void Dec_HealthIncrementCollect(){
            StartCoroutine(FlowControllerlast.Instance.Dec_HealthIncrementCollect(OnDegradeSuccess, OnDegradeFailure));
        }
        public void Dec_IncreasedHealthSpawn(){
            StartCoroutine(FlowControllerlast.Instance.Dec_IncreasedHealthSpawn(OnDegradeSuccess, OnDegradeFailure));
        }
        public void Dec_IncreasedPlutoFromEnemy(){
            StartCoroutine(FlowControllerlast.Instance.Dec_IncreasedPlutoFromEnemy(OnDegradeSuccess, OnDegradeFailure));
        }
        public void Dec_IncreasedPlutoSpawn(){
            StartCoroutine(FlowControllerlast.Instance.Dec_IncreasedPlutoSpawn(OnDegradeSuccess, OnDegradeFailure));
        }
        public void Dec_IncreasedHeroSpeed(){
            StartCoroutine(FlowControllerlast.Instance.Dec_IncreasedHeroSpeed(OnDegradeSuccess, OnDegradeFailure));
        }
        public void Dec_LessDamageFromEnemy(){
            StartCoroutine(FlowControllerlast.Instance.Dec_LessDamageFromEnemy(OnDegradeSuccess, OnDegradeFailure));
        }
        public void Dec_PowerIncrement(){
            StartCoroutine(FlowControllerlast.Instance.Dec_PowerIncrement(OnDegradeSuccess, OnDegradeFailure));
        }
        public void Dec_SlowEnemySpeed(){
            StartCoroutine(FlowControllerlast.Instance.Dec_SlowEnemySpeed(OnDegradeSuccess, OnDegradeFailure));
        }

        public void OnDegradeSuccess(){
            DegradeStatus.text = "Successfull";
            Debug.Log("Degrade Successfull");
        }
        public void OnDegradeFailure(){
            DegradeStatus.text = "UnSuccessfull Try Again";
            Debug.Log("Degrade UnSuccessfull");
        }


        public void Inc_DamageIncrement(){
            StartCoroutine(FlowControllerlast.Instance.Inc_DamageIncrement(OnUpgradeSuccess, OnUpgradeFailure));
        }

        public void Inc_HealthIncrementCollect(){
            StartCoroutine(FlowControllerlast.Instance.Inc_HealthIncrementCollect(OnUpgradeSuccess, OnUpgradeFailure));
        }
        public void Inc_IncreasedHealthSpawn(){
            StartCoroutine(FlowControllerlast.Instance.Inc_IncreasedHealthSpawn(OnUpgradeSuccess, OnUpgradeFailure));
        }
        public void Inc_IncreasedPlutoFromEnemy(){
            StartCoroutine(FlowControllerlast.Instance.Inc_IncreasedPlutoFromEnemy(OnUpgradeSuccess, OnUpgradeFailure));
        }
        public void Inc_IncreasedPlutoSpawn(){
            StartCoroutine(FlowControllerlast.Instance.Inc_IncreasedPlutoSpawn(OnUpgradeSuccess, OnUpgradeFailure));
        }
        public void Inc_IncreasedHeroSpeed(){
            StartCoroutine(FlowControllerlast.Instance.Inc_IncreasedHeroSpeed(OnUpgradeSuccess, OnUpgradeFailure));
        }
        public void Inc_LessDamageFromEnemy(){
            StartCoroutine(FlowControllerlast.Instance.Inc_LessDamageFromEnemy(OnUpgradeSuccess, OnUpgradeFailure));
        }
        public void Inc_PowerIncrement(){
            StartCoroutine(FlowControllerlast.Instance.Inc_PowerIncrement(OnUpgradeSuccess, OnUpgradeFailure));
        }
        public void Inc_SlowEnemySpeed(){
            StartCoroutine(FlowControllerlast.Instance.Inc_SlowEnemySpeed(OnUpgradeSuccess, OnUpgradeFailure));
        }

        public void OnUpgradeSuccess(){
            UpgradeStatus.text = "Successfull";
            Debug.Log("Upgrade Successfull");
        }
        public void OnUpgradeFailure(){
            UpgradeStatus.text = "UnSuccessfull Try Again";
            Debug.Log("Upgrade UnSuccessfull");
        }

    }
}