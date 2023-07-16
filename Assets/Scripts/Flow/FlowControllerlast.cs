using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using UnityEngine;
using DapperLabs.Flow.Sdk;
using DapperLabs.Flow.Sdk.Unity;
using DapperLabs.Flow.Sdk.Cadence;
using DapperLabs.Flow.Sdk.DataObjects;
using DapperLabs.Flow.Sdk.DevWallet;
using Convert = DapperLabs.Flow.Sdk.Cadence.Convert;
using DapperLabs.Flow.Sdk.WalletConnect;
using DapperLabs.Flow.Sdk.Crypto;



namespace FlowControllerlast
{
    public class FlowControllerlast : MonoBehaviour
    {

        public GameObject walletSelectCustomPrefab;
        public GameObject qrCodeCustomPrefab;
        
        // The TextAssets containing Cadence scripts and transactions that will be used for the game.
        [Header("Scripts and Transactions")]
        [SerializeField] CadenceTransactionAsset createStatetxn;

        [SerializeField] CadenceTransactionAsset updatePlutoniumtxn;
        [SerializeField] CadenceScriptAsset checkWordScript;
        [SerializeField] CadenceTransactionAsset submitGuessTxn;

        // Cadence scripts to get the data needed to display the High Scores panel
        [Header("Highscore Scripts")]
        [SerializeField] CadenceScriptAsset GetPlutoniumScript;
        [SerializeField] CadenceScriptAsset GetPlayerCumulativeScore;
        [SerializeField] CadenceScriptAsset GetPlayerWinningStreak;
        [SerializeField] CadenceScriptAsset GetPlayerMaxWinningStreak;
        [SerializeField] CadenceScriptAsset GetGuessDistribution;

        // FlowControl Account object, used to help with text replacements in scripts and transactions
        private FlowControl.Account FLOW_ACCOUNT = null;

        private static FlowControllerlast m_instance = null;
        public static FlowControllerlast Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = FindObjectOfType<FlowControllerlast>();
                }

                return m_instance;
            }
        }

        private void Start()
        {
            if (Instance != this)
            {
                Destroy(this);
            }

            // Set up SDK to access Emulator
            
            // Register DevWallet

        }


        public void Login(string username, System.Action<string, string> onSuccessCallback, System.Action onFailureCallback)
        {

            FlowConfig flowConfig = new FlowConfig()
            {
                NetworkUrl = "https://rest-testnet.onflow.org/v1",  // emulator
                Protocol = FlowConfig.NetworkProtocol.HTTP
            };
            FlowSDK.Init(flowConfig);

            // Register DevWallet wallet provider with SDK
  
            IWallet walletProvider = new WalletConnectProvider();
            walletProvider.Init(new WalletConnectConfig
            {
                ProjectId = "1c3bb53aa29176bc37197ff98498ef39", // insert Project ID from Wallet Connect dashboard
                ProjectDescription = "A web3 pixel art game made on Flow Chain",
                ProjectIconUrl = "https://game-website-two.vercel.app/Logo.png",
                ProjectName = "BackToTheFuture",
                ProjectUrl = "https://game-website-two.vercel.app/",
                QrCodeDialogPrefab = qrCodeCustomPrefab, // custom prefab for QR Code dialog (desktop builds)
                WalletSelectDialogPrefab = walletSelectCustomPrefab // custom prefab for Wallet Select dialog (mobile builds)

            });

            // Register WalletConnect wallet provider with SDK
            FlowSDK.RegisterWalletProvider(walletProvider);
            // Authenticate an account with DevWallet
            // Authenticate an account with DevWallet
             if (FlowSDK.GetWalletProvider().IsAuthenticated() == false){
                FlowSDK.GetWalletProvider().Authenticate(
                    "", // blank string will show list of accounts from Accounts tab of Flow Control Window
                    (string address) => onSuccessCallback(address, username),
                    onFailureCallback);
            }


        }

        public void LoginEmulator(string username, System.Action<string, string> onSuccessCallback, System.Action onFailureCallback)
        {

            // Set up SDK to access Emulator
            FlowConfig flowConfig = new FlowConfig()
            {
                NetworkUrl = "http://127.0.0.1:8888/v1",  // emulator
                Protocol = FlowConfig.NetworkProtocol.HTTP
            };
            FlowSDK.Init(flowConfig);

            // Register DevWallet wallet provider with SDK
            FlowSDK.RegisterWalletProvider(new DevWalletProvider());
            // Authenticate an account with DevWallet
            // Authenticate an account with DevWallet
        
                FlowSDK.GetWalletProvider().Authenticate(
                    "", // blank string will show list of accounts from Accounts tab of Flow Control Window
                    (string address) => onSuccessCallback(address, username),
                    onFailureCallback);
        


        }


        public void Logout()
        {

            FLOW_ACCOUNT = null;
            FlowSDK.GetWalletProvider().Unauthenticate();

        }
        public IEnumerator CreateState(string username, System.Action onSuccessCallback, System.Action onFailureCallback)
        {
            
            FLOW_ACCOUNT = new FlowControl.Account
            {
                GatewayName = "Emulator",   // the network to match
                AccountConfig = new Dictionary<string, string> { { "Address", FlowSDK.GetWalletProvider().GetAuthenticatedAccount().Address } } // the account address to match
            };


            Task<FlowTransactionResult> getStateTask = Transactions.SubmitAndWaitUntilExecuted(createStatetxn.text);

            while (!getStateTask.IsCompleted)
            {

                yield return null;
            }

            // check for error. if so, break.
            if (getStateTask.Result.Error != null || getStateTask.Result.ErrorMessage != string.Empty || getStateTask.Result.Status == FlowTransactionStatus.EXPIRED)
            {
                onFailureCallback();
                yield break;
            }

            onSuccessCallback();



            yield return null;
        }

        public IEnumerator UpdatePlutonium(System.Action onSuccessCallback, System.Action onFailureCallback)
        {
            
            FLOW_ACCOUNT = new FlowControl.Account
            {
                GatewayName = "Emulator",   // the network to match
                AccountConfig = new Dictionary<string, string> { { "Address", FlowSDK.GetWalletProvider().GetAuthenticatedAccount().Address } } // the account address to match
            };


            Task<FlowTransactionResult> getStateTask = Transactions.SubmitAndWaitUntilExecuted(updatePlutoniumtxn.text);

            while (!getStateTask.IsCompleted)
            {

                yield return null;
            }

            // check for error. if so, break.
            if (getStateTask.Result.Error != null || getStateTask.Result.ErrorMessage != string.Empty || getStateTask.Result.Status == FlowTransactionStatus.EXPIRED)
            {
                onFailureCallback();
                yield break;
            }

            onSuccessCallback();



            yield return null;
        }

        public IEnumerator GetPlutonium(System.Action<BigInteger> onSuccessCallback, System.Action onFailureCallback){
               

            Task<FlowScriptResponse> task = FLOW_ACCOUNT.ExecuteScript(GetPlutoniumScript.text);
            
            yield return new WaitUntil(() => task.IsCompleted);

            if (task.Result.Error != null)
            {
                onFailureCallback();
                yield break;
            }


            Debug.Log($"Script result: {Convert.FromCadence<BigInteger>(task.Result.Value)}");

            onSuccessCallback(Convert.FromCadence<BigInteger>(task.Result.Value));
            
            
        }

        
    }
}
