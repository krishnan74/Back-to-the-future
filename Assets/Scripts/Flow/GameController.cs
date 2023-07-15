using System.Collections.Generic;
using DapperLabs.Flow.Sdk.Cadence;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Numerics;


namespace FlowController{

    public class GameController : MonoBehaviour
{
        public GameObject LoginPanel;
        
        public InputField inputField; // Reference to the InputField component
        public Text OutputText;

        public Text AccountName;
        public Text UserAddress;

        

        public void CreateEmulatorAccount(){
            StartCoroutine(FlowController.Instance.CreateEmulatorAccount(inputField.text, OnCreateAccountSuccess, OnCreateAccountFailure));
        }

        public void CreateTestAccount(){
            StartCoroutine(FlowController.Instance.CreateTestAccount(inputField.text, OnCreateAccountSuccess, OnCreateAccountFailure));

        }
        public void OnCreateAccountSuccess(string username, string address){
 
            OutputText.text = "Successfull";


        }

        public void OnCreateAccountFailure(){
            OutputText.text = "UnSuccessfull, try again";
        }

        // Start is called before the first frame update
        public void LoginEmulator()
        {
            FlowController.Instance.LoginEmulator(OnLoginSuccess, OnLoginFailure);
        }

        public void LoginTestNet()
        {
            FlowController.Instance.LoginTestNet(OnLoginSuccess, OnLoginFailure);
        }

        

        private void OnLoginSuccess(string address, string username)
        {
            
            Debug.Log("Login Successfull"+username+address);
            LoginPanel.SetActive(false);
            AccountName.text = username;
            UserAddress.text = address;

        }

        /// <summary>
        /// Function called when login fails
        /// </summary>
        private void OnLoginFailure()
        {
            Debug.Log("Login not Successfull");

        }

        public void NewGame(string username)
        {
            StartCoroutine(FlowController.Instance.CreateState(username, OnNewGameSuccess, OnNewGameFailure));
        }

        public void OnNewGameSuccess(){
            Debug.Log("State Creation Successfull");
            SceneManager.LoadScene("intro-cutscene");

        }

        public void OnNewGameFailure(){
            Debug.Log("State Creation Failed");

        }


        public void UpdatePlutonium(){
            StartCoroutine(FlowController.Instance.UpdatePlutonium(OnPlutoSuccess, OnPlutoFailure));
        }

        /// <summary>
        /// Function called when login is successful
        /// </summary>
        /// <param name="username">The username chosen by the user</param>
        /// <param name="address">The user's Flow address</param>
        public void GetPlutonium(){
            StartCoroutine(FlowController.Instance.GetPlutonium(OnGetPlutoSuccess, OnGetPlutoFailure));
        }

        private void OnGetPlutoSuccess(BigInteger plutoCount)
        {
            Debug.Log("Pluto Count" + plutoCount);

        }

        /// <summary>
        /// Function called when login fails
        /// </summary>
        private void OnGetPlutoFailure()
        {
            Debug.Log("Plutonium not got");

        }

        private void OnPlutoSuccess()
        {
            Debug.Log("Plutonium Update");

        }

        /// <summary>
        /// Function called when login fails
        /// </summary>
        private void OnPlutoFailure()
        {
            Debug.Log("Plutonium not updated");

        }


        public void ListContracts(){
            StartCoroutine(FlowController.Instance.ListContracts());
        }

        public void Logout(){
            FlowController.Instance.Logout();
            LoginPanel.SetActive(true);
        }

}

}
