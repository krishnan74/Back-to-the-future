using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

namespace FlowControllerlast
{
    public class StateManager : MonoBehaviour
    {
        public static BigInteger plutoCount;
        public static UnityEngine.Vector3 LastPosition = new UnityEngine.Vector3(-5.18f, -3.2f, 0f);
        public static Dictionary<string, string> emulatorAccountDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> testAccountDictionary = new Dictionary<string, string>();

        public static BigInteger increasedHealthIncrementAuto;
        public static BigInteger increasedHealthIncrementCollect;
        public static BigInteger increasedPowerIncrement;
        public static BigInteger increasedDamageIncrement;
        public static BigInteger increasedPlutoFromEnemy;
        public static BigInteger increasedPlutoSpawn;
        public static BigInteger increasedHealthSpawn;
        public static BigInteger slowEnemySpeed;
        public static BigInteger increaseHeroSpeed;
        public static BigInteger lessDamageFromEnemy;

        public void GetPlutonium(){
            StartCoroutine(FlowControllerlast.Instance.GetPlutonium(OnGetPlutoSuccess, OnGetPlutoFailure));
        }

        public void OnGetPlutoSuccess(BigInteger plutoCount)
        {
            plutoCount += plutoCount;
            Debug.Log("Pluto Count" + plutoCount);


        }

        private void OnGetPlutoFailure()
        {
            
            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetDamageIncrementLevel(){
            StartCoroutine(FlowControllerlast.Instance.GetDamageIncrementLevel(OnGetDamageIncrementLevelSuccess, OnGetDamageIncrementLevelFailure));
        }

        public void OnGetDamageIncrementLevelSuccess(BigInteger plutoCount)
        {
            increasedDamageIncrement = plutoCount;
            Debug.Log("increasedDamageIncrement" + plutoCount);


        }

        private void OnGetDamageIncrementLevelFailure()
        {
            
            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetHealthIncrementAutoLevel(){
            StartCoroutine(FlowControllerlast.Instance.GetHealthIncrementAutoLevel(OnGetHealthIncrementAutoLevelSuccess, OnGetHealthIncrementAutoLevelFailure));
        }

        public void OnGetHealthIncrementAutoLevelSuccess(BigInteger plutoCount)
        {
            increasedHealthIncrementAuto = plutoCount;
            Debug.Log("increasedHealthIncrementAuto" + plutoCount);


        }

        private void OnGetHealthIncrementAutoLevelFailure()
        {
            
            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetHealthIncrementCollectLevel(){
            StartCoroutine(FlowControllerlast.Instance.GetHealthIncrementCollectLevel(OnGetHealthIncrementCollectLevelSuccess, OnGetHealthIncrementCollectLevelFailure));
        }

        public void OnGetHealthIncrementCollectLevelSuccess(BigInteger plutoCount)
        {
            increasedHealthIncrementCollect = plutoCount;
            Debug.Log("Pluto Count" + plutoCount);


        }

        private void OnGetHealthIncrementCollectLevelFailure()
        {
            
            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetPlutoniumFromEnemyLevel(){
            StartCoroutine(FlowControllerlast.Instance.GetPlutoniumFromEnemyLevel(OnGetPlutoniumFromEnemyLevelSuccess, OnGetPlutoniumFromEnemyLevelFailure));
        }

        public void OnGetPlutoniumFromEnemyLevelSuccess(BigInteger plutoCount)
        {
            increasedPlutoFromEnemy = plutoCount;
            Debug.Log("increasedPlutoFromEnemy" + plutoCount);


        }

        private void OnGetPlutoniumFromEnemyLevelFailure()
        {
            
            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetPlutoniumSpawnLevel(){
            StartCoroutine(FlowControllerlast.Instance.GetPlutoniumSpawnLevel(OnGetPlutoniumSpawnLevelSuccess, OnGetPlutoniumSpawnLevelFailure));
        }

        public void OnGetPlutoniumSpawnLevelSuccess(BigInteger plutoCount)
        {
            increasedPlutoSpawn = plutoCount;
            Debug.Log("increasedPlutoSpawn" + plutoCount);


        }

        private void OnGetPlutoniumSpawnLevelFailure()
        {
            
            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetHeroSpeedLevel(){
            StartCoroutine(FlowControllerlast.Instance.GetHeroSpeedLevel(OnGetHeroSpeedLevelSuccess, OnGetHeroSpeedLevelFailure));
        }

        public void OnGetHeroSpeedLevelSuccess(BigInteger plutoCount)
        {
            increaseHeroSpeed = plutoCount;
            Debug.Log("increaseHeroSpeed" + plutoCount);


        }

        private void OnGetHeroSpeedLevelFailure()
        {
            
            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetLessDamageFromEnemyLevel(){
            StartCoroutine(FlowControllerlast.Instance.GetPowerIncrementLevel(OnGetLessDamageFromEnemyLevelSuccess, OnGetLessDamageFromEnemyLevelFailure));
        }

        public void OnGetLessDamageFromEnemyLevelSuccess(BigInteger plutoCount)
        {
            lessDamageFromEnemy = plutoCount;
            Debug.Log("lessDamageFromEnemy" + plutoCount);


        }

        private void OnGetLessDamageFromEnemyLevelFailure()
        {
            
            Debug.Log("UnsuccessfulPlutoget");

        }

        public void GetSlowEnemySpeedLevel(){
            StartCoroutine(FlowControllerlast.Instance.GetPlutonium(OnGetSlowEnemySpeedLevelSuccess, OnGetSlowEnemySpeedLevelFailure));
        }

        public void OnGetSlowEnemySpeedLevelSuccess(BigInteger plutoCount)
        {
            slowEnemySpeed = plutoCount;
            Debug.Log("Pluto Count" + plutoCount);


        }

        private void OnGetSlowEnemySpeedLevelFailure()
        {
            
            Debug.Log("UnsuccessfulPlutoget");

        }

        

    }
}