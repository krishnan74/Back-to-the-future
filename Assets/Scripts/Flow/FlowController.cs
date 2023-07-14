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




namespace FlowController
{
    public class FlowController : MonoBehaviour
    {
        /// <summary>
        /// Class to hold the payload of a cadence CurrentState event
        /// </summary>
        
        
        // The TextAssets containing Cadence scripts and transactions that will be used for the game.
        [Header("Scripts and Transactions")]
        [SerializeField] CadenceTransactionAsset createStatetxn;
        [SerializeField] CadenceTransactionAsset updateHealthtxn;
        [SerializeField] CadenceTransactionAsset updateMissiontxn;
        [SerializeField] CadenceTransactionAsset updatePlutoniumtxn;

        // FlowControl Account object, used to help with text replacements in scripts and transactions
        private FlowControl.Account FLOW_ACCOUNT = null;

        private static FlowController m_instance = null;
        public static FlowController Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = FindObjectOfType<FlowController>();
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
            FlowConfig flowConfig = new FlowConfig()
            {
                NetworkUrl = "http://127.0.0.1:8888/v1",  // emulator
                Protocol = FlowConfig.NetworkProtocol.HTTP
            };
            FlowSDK.Init(flowConfig);

            // Register DevWallet wallet provider with SDK
            FlowSDK.RegisterWalletProvider(new DevWalletProvider());


            // Register DevWallet

        }

        /// <summary>
        /// Attempts to log in by executing a transaction using the provided credentials
        /// </summary>
        /// <param name="username">An arbitrary username the player would like to be known by on the leaderboards</param>
        /// <param name="onSuccessCallback">Function that should be called when login is successful</param>
        /// <param name="onFailureCallback">Function that should be called when login fails</param>
        public void Login(string username, System.Action<string, string> onSuccessCallback, System.Action onFailureCallback)
        {
            // Authenticate an account with DevWallet
            // Authenticate an account with DevWallet
             if (FlowSDK.GetWalletProvider().IsAuthenticated() == false){
                FlowSDK.GetWalletProvider().Authenticate(
                    "", // blank string will show list of accounts from Accounts tab of Flow Control Window
                    (string address) => onSuccessCallback(address, username),
                    onFailureCallback);
            }

            FLOW_ACCOUNT = new FlowControl.Account
            {
                GatewayName = "Emulator",   // the network to match
                AccountConfig = new Dictionary<string, string> { { "Address", FlowSDK.GetWalletProvider().GetAuthenticatedAccount().Address } } // the account address to match
            };


        }

        public IEnumerator ListContracts(){
            //Get the address of the emulator_service_account, then get an account object for that account.
            Task<FlowAccount> accountTask = Accounts.GetByAddress(FlowControl.Data.Accounts.Find(acct => acct.Name == "emulator_service_account").AccountConfig["Address"]);
            //Wait until the account fetch is complete
            yield return new WaitUntil(() => accountTask.IsCompleted);

            foreach (var contract in accountTask.Result.Contracts)
                {
                    Debug.Log(contract.Name);
                }

            //We now have an Account object, which contains the contracts deployed to that account. Check if the NonFungileToken and SDKExampleNFT contracts are deployed
            if (!accountTask.Result.Contracts.Exists(x => x.Name == "SDKExampleNFT") || !accountTask.Result.Contracts.Exists(x => x.Name == "NonFungibleToken"))
            {
                //Code to handle if the contracts are not deployed
            }
        }
        
        
        public IEnumerator CreateState(string name, System.Action onSuccessCallback, System.Action onFailureCallback){
            FLOW_ACCOUNT = new FlowControl.Account
{
    GatewayName = "Emulator",   // the network to match
    AccountConfig = new Dictionary<string, string> { { "Address", FlowSDK.GetWalletProvider().GetAuthenticatedAccount().Address } } // the account address to match
};

            string transaction = @" 
                    import BackToTheFuture from 0xf8d6e0586b0a20c7
                    transaction {
                        prepare(acct: AuthAccount) {
                            acct.save<@BackToTheFuture.State>(<-BackToTheFuture.createState(name: ""user2""), to: /storage/state)            //?? panic(""Could not load counter resource"")
                        }
                    }";

            Task<FlowTransactionResult> transactionTask = FLOW_ACCOUNT.SubmitAndWaitUntilSealed(transaction.Replace("name", $@"""{name}"""));
            yield return new WaitUntil(() => transactionTask.IsCompleted);

            Debug.Log(transactionTask.Result);

            if (transactionTask.Result.Error != null || !string.IsNullOrEmpty(transactionTask.Result.ErrorMessage)) 
            { 
            Debug.LogError($"Error executing transaction: {transactionTask.Result.Error?.Message??transactionTask.Result.ErrorMessage}"); 
            yield break; 
            }
            
        }

        public IEnumerator UpdateHealth( System.Action onSuccessCallback, System.Action onFailureCallback){
            FLOW_ACCOUNT = new FlowControl.Account
            {
                GatewayName = "Emulator",   // the network to match
                AccountConfig = new Dictionary<string, string> { { "Address", FlowSDK.GetWalletProvider().GetAuthenticatedAccount().Address } } // the account address to match
            };

            Task<FlowTransactionResult> getState = Transactions.SubmitAndWaitUntilExecuted(FLOW_ACCOUNT.DoTextReplacements(updateHealthtxn.text));

            if (getState.Result.Error != null || getState.Result.ErrorMessage != string.Empty || getState.Result.Status == FlowTransactionStatus.EXPIRED)
            {
                onFailureCallback();
                yield break;
            }

            else{
                onSuccessCallback();
            }
            
        }

        public IEnumerator UpdateMission(System.Action onSuccessCallback, System.Action onFailureCallback){
            FLOW_ACCOUNT = new FlowControl.Account
            {
                GatewayName = "Emulator",   // the network to match
                AccountConfig = new Dictionary<string, string> { { "Address", FlowSDK.GetWalletProvider().GetAuthenticatedAccount().Address } } // the account address to match
            };

            Task<FlowTransactionResult> getState = Transactions.SubmitAndWaitUntilExecuted(FLOW_ACCOUNT.DoTextReplacements(updateMissiontxn.text));

            if (getState.Result.Error != null || getState.Result.ErrorMessage != string.Empty || getState.Result.Status == FlowTransactionStatus.EXPIRED)
            {
                onFailureCallback();
                yield break;
            }

            else{
                onSuccessCallback();
            }
            
        }


        public IEnumerator UpdatePlutonium(System.Action onSuccessCallback, System.Action onFailureCallback){
            FLOW_ACCOUNT = new FlowControl.Account
            {
                GatewayName = "Emulator",   // the network to match
                AccountConfig = new Dictionary<string, string> { { "Address", FlowSDK.GetWalletProvider().GetAuthenticatedAccount().Address } } // the account address to match
            };

            Task<FlowTransactionResult> getState = Transactions.SubmitAndWaitUntilExecuted(FLOW_ACCOUNT.DoTextReplacements(updatePlutoniumtxn.text));

            if (getState.Result.Error != null || getState.Result.ErrorMessage != string.Empty || getState.Result.Status == FlowTransactionStatus.EXPIRED)
            {
                onFailureCallback();
                yield break;
            }

            else{
                onSuccessCallback();
            }
            
        }
        /// <summary>
        /// Clear the FLOW account object
        /// </summary>
        public void Logout()
        {

            FLOW_ACCOUNT = null;
            FlowSDK.GetWalletProvider().Unauthenticate();

        }


    }
}














































    // private IEnumerator Start(){
    //     //Wait up to 2.5 seconds for the emulator to start.
    //     int waited = 0;

    //     while (!FlowControl.IsEmulatorRunning && waited < 5)
    //     {
    //         waited++;
    //         yield return new WaitForSeconds(.5f);
    //     }

    //     if (!FlowControl.IsEmulatorRunning)
    //     {
    //         //Stop execution if the emulator is not running by now.
    //         yield break;
    //     }

    //     FlowControl.Account scriptOnlyAccount = new FlowControl.Account
    //     {
    //         GatewayName = "Emulator"
    //     };

    //     const string code = @"pub fun main(message: String): Int{
    //         log(message)
    //         return 42
    //     }";

    //     Task<FlowScriptResponse> task = scriptOnlyAccount.ExecuteScript(code, Convert.ToCadence("Test", "String"));
    //     yield return new WaitUntil(() => task.IsCompleted);
        
    //     if (task.Result.Error != null){
    //             Debug.LogError($"Error:  {task.Result.Error.Message}");
    //             yield break;
    //         }

    //     Debug.Log($"Script result: {Convert.FromCadence<BigInteger>(task.Result.Value)}");



    // }

    // private void Start()

    // // Account addresss   0x24fd02c6d1290032
    // {

    //     const string contractCode = @"
    //     pub contract BackToTheFuture{


    //         pub resource State{

    //             pub var Name: String
    //             pub var Plutonium: Int
    //             pub var Health: Int
    //             pub var Missions: [String]


    //             init(_name: String){

    //                 self.Name = _name
    //                 self.Plutonium = 0
    //                 self.Health = 0
    //                 self.Missions =[]

    //             }
                
                
    //             pub fun GetName() : String
    //             {
    //                 return self.Name
    //             }

    //             pub fun newGame(name: String){
    //                 self.Plutonium = 0
    //                 self.Health = 100
    //             } 

    //             pub fun addPlutonium(_P: Int){
    //                 self.Plutonium = self.Plutonium + _P
    //             } 

    //             pub fun updateHealth(_value: Int){
    //                 self.Health = self.Health - _value
    //             }

    //             pub fun updateMission(mission: String){
    //                 self.Missions.append(mission)
    //             }
    //         }

    //         pub fun createState(name: String): @State{
    //             return <- create State(_name: name)
    //         }
    //     }";
    
    // FlowSDK.GetWalletProvider().Authenticate(userAccount.Name, null, null);
    // Task<FlowTransactionResponse> deployContractTask = CommonTransactions.DeployContract("HelloWorld", contractCode);

    // yield return new WaitUntil(() => deployContractTask.IsCompleted);

    // if (deployContractTask.Result.Error != null)
    // {
    //     Debug.LogError($"Error deploying contract: {deployContractTask.Result.Error.Message}");
    //     yield break;
    // }
    
    // }





