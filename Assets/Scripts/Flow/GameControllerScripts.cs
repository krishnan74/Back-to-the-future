using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

namespace FlowControllerlast
{

    public class GameControllerScripts : MonoBehaviour
    {
        // Start is called before the first frame update
        public void Start()
        {
            
            GetDamageIncrementLevel();
            GetHealthIncrementAutoLevel();
            GetHealthIncrementCollectLevel();
            GetPlutoniumFromEnemyLevel();
            GetPlutoniumSpawnLevel();
            GetHeroSpeedLevel();
            GetLessDamageFromEnemyLevel();
            GetSlowEnemySpeedLevel();
        }

        public void ShopCloseUpdate()
        {
            
            GetDamageIncrementLevel();
            GetHealthIncrementAutoLevel();
            GetHealthIncrementCollectLevel();
            GetPlutoniumFromEnemyLevel();
            GetPlutoniumSpawnLevel();
            GetHeroSpeedLevel();
            GetLessDamageFromEnemyLevel();
            GetSlowEnemySpeedLevel();
        }

        public void GetPlutonium()
        {
            StartCoroutine(FlowControllerlast.Instance.GetPlutonium(OnGetPlutoSuccess, OnGetPlutoFailure));
        }

        public void OnGetPlutoSuccess(BigInteger plutoCount)
        {
            StateManager.plutoCount += plutoCount;
            Debug.Log("Pluto Count" + plutoCount);
        }

        private void OnGetPlutoFailure()
        {

            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetDamageIncrementLevel()
        {
            StartCoroutine(FlowControllerlast.Instance.GetDamageIncrementLevel(OnGetDamageIncrementLevelSuccess, OnGetDamageIncrementLevelFailure));
        }

        public void OnGetDamageIncrementLevelSuccess(BigInteger DamageIncrementLevel)
        {
            StateManager.increasedDamageIncrement = DamageIncrementLevel;
            Debug.Log("increasedDamageIncrement" + DamageIncrementLevel);


        }

        private void OnGetDamageIncrementLevelFailure()
        {

            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetHealthIncrementAutoLevel()
        {
            StartCoroutine(FlowControllerlast.Instance.GetHealthIncrementAutoLevel(OnGetHealthIncrementAutoLevelSuccess, OnGetHealthIncrementAutoLevelFailure));
        }

        public void OnGetHealthIncrementAutoLevelSuccess(BigInteger HealthIncrementAutoLevel)
        {
            StateManager.increasedHealthIncrementAuto = HealthIncrementAutoLevel;
            Debug.Log("increasedHealthIncrementAuto" + HealthIncrementAutoLevel);


        }

        private void OnGetHealthIncrementAutoLevelFailure()
        {

            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetHealthIncrementCollectLevel()
        {
            StartCoroutine(FlowControllerlast.Instance.GetHealthIncrementCollectLevel(OnGetHealthIncrementCollectLevelSuccess, OnGetHealthIncrementCollectLevelFailure));
        }

        public void OnGetHealthIncrementCollectLevelSuccess(BigInteger HealthIncrementCollectLevel)
        {
            StateManager.increasedHealthIncrementCollect = HealthIncrementCollectLevel;
            Debug.Log("Pluto Count" + HealthIncrementCollectLevel);


        }

        private void OnGetHealthIncrementCollectLevelFailure()
        {

            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetPlutoniumFromEnemyLevel()
        {
            StartCoroutine(FlowControllerlast.Instance.GetPlutoniumFromEnemyLevel(OnGetPlutoniumFromEnemyLevelSuccess, OnGetPlutoniumFromEnemyLevelFailure));
        }

        public void OnGetPlutoniumFromEnemyLevelSuccess(BigInteger PlutoFromEnemyLevel)
        {
            StateManager.increasedPlutoFromEnemy = PlutoFromEnemyLevel;
            Debug.Log("increasedPlutoFromEnemy" + PlutoFromEnemyLevel);


        }

        private void OnGetPlutoniumFromEnemyLevelFailure()
        {

            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetPlutoniumSpawnLevel()
        {
            StartCoroutine(FlowControllerlast.Instance.GetPlutoniumSpawnLevel(OnGetPlutoniumSpawnLevelSuccess, OnGetPlutoniumSpawnLevelFailure));
        }

        public void OnGetPlutoniumSpawnLevelSuccess(BigInteger PlutoSpawnLevel)
        {
            StateManager.increasedPlutoSpawn = PlutoSpawnLevel;
            Debug.Log("increasedPlutoSpawn" + PlutoSpawnLevel);


        }

        private void OnGetPlutoniumSpawnLevelFailure()
        {

            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetHeroSpeedLevel()
        {
            StartCoroutine(FlowControllerlast.Instance.GetHeroSpeedLevel(OnGetHeroSpeedLevelSuccess, OnGetHeroSpeedLevelFailure));
        }

        public void OnGetHeroSpeedLevelSuccess(BigInteger HeroSpeedLevel)
        {
            StateManager.increaseHeroSpeed = HeroSpeedLevel;
            Debug.Log("increaseHeroSpeed" + HeroSpeedLevel);


        }

        private void OnGetHeroSpeedLevelFailure()
        {

            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetLessDamageFromEnemyLevel()
        {
            StartCoroutine(FlowControllerlast.Instance.GetPowerIncrementLevel(OnGetLessDamageFromEnemyLevelSuccess, OnGetLessDamageFromEnemyLevelFailure));
        }

        public void OnGetLessDamageFromEnemyLevelSuccess(BigInteger LessDamageLevel)
        {
            StateManager.lessDamageFromEnemy = LessDamageLevel;
            Debug.Log("lessDamageFromEnemy" + LessDamageLevel);


        }

        private void OnGetLessDamageFromEnemyLevelFailure()
        {

            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetSlowEnemySpeedLevel()
        {
            StartCoroutine(FlowControllerlast.Instance.GetPlutonium(OnGetSlowEnemySpeedLevelSuccess, OnGetSlowEnemySpeedLevelFailure));
        }

        public void OnGetSlowEnemySpeedLevelSuccess(BigInteger SlowEnemyLevel)
        {
            StateManager.slowEnemySpeed = SlowEnemyLevel;
            Debug.Log("Pluto Count" + SlowEnemyLevel);


        }

        private void OnGetSlowEnemySpeedLevelFailure()
        {

            Debug.Log("UnsuccessfulPlutoget");

        }

        public void PlutoUpdateManual()
        {
            GetPlutonium();
        }

        // public void ListContracts(){
        //     StartCoroutine(FlowControllerlast.Instance.ListContracts());
        // }



        

    }
}