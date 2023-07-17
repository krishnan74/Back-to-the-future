using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;


    public class StateManager : MonoBehaviour
    {
        public static BigInteger plutoCount;
         public static UnityEngine.Vector3 LastPosition = new UnityEngine.Vector3(-5.18f, -3.2f, 0f);
        public static Dictionary<string, string> emulatorAccountDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> testAccountDictionary = new Dictionary<string, string>();

        public static int increasedHealthIncrementAuto = 1;
        public static int increasedHealthIncrementCollect = 0;
        public static int increasedPowerIncrement;
        public static int increasedDamage;
        public static int increasedPlutoFromEnemy;
        public static int increasedPlutoSpawn;
        public static int increasedHealthSpawn;
        public static int slowEnemySpeed;
        public static int increaseHeroSpeed;
        public static int lessDamageFromEnemy = 0;

    }
