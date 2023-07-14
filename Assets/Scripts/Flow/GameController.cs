using System.Collections.Generic;
using DapperLabs.Flow.Sdk.Cadence;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlowController{

    public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Login(string username)
        {
            FlowController.Instance.Login(username, OnLoginSuccess, OnLoginFailure);
        }

        /// <summary>
        /// Function called when login is successful
        /// </summary>
        /// <param name="username">The username chosen by the user</param>
        /// <param name="address">The user's Flow address</param>
        private void OnLoginSuccess(string username, string address)
        {
            Debug.Log("Login Successfull"+username+address);

        }

        /// <summary>
        /// Function called when login fails
        /// </summary>
        private void OnLoginFailure()
        {
            Debug.Log("Login not Successfull");

        }


        public void ListContracts(){
            StartCoroutine(FlowController.Instance.ListContracts());
        }

        public void NewGame(string username)
        {
            StartCoroutine(FlowController.Instance.CreateState(username, OnNewGameSuccess, OnNewGameFailure));
        }

        public void OnNewGameSuccess(){
            Debug.Log("State Creation Successfull");
            SceneManager.LoadSceneAsync("intro-cutscene");

        }

        public void OnNewGameFailure(){
            Debug.Log("State Creation Failed");

        }

}

}
