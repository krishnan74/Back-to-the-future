using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

namespace FlowControllerlast
{
    public class StateManager : MonoBehaviour
    {
        public static BigInteger plutoCount = 0;
        public static UnityEngine.Vector3 LastPosition = new UnityEngine.Vector3(-5.18f, -3.2f, 0f);
        public static Dictionary<string, string> emulatorAccountDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> testAccountDictionary = new Dictionary<string, string>();

        public static BigInteger increasedHealthIncrementAuto=0;
        public static BigInteger increasedHealthIncrementCollect=0;
        public static BigInteger increasedPowerIncrement=0;
        public static BigInteger increasedDamageIncrement=0;
        public static BigInteger increasedPlutoFromEnemy=0;
        public static BigInteger increasedPlutoSpawn=0;
        public static BigInteger increasedHealthSpawn=0;
        public static BigInteger slowEnemySpeed=0;
        public static BigInteger increaseHeroSpeed=0;
        public static BigInteger lessDamageFromEnemy=0;

        
        private void Start()
        {
            
        }


    }
}
