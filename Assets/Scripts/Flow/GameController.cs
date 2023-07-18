using System.Collections.Generic;
using DapperLabs.Flow.Sdk.Cadence;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Numerics;


namespace FlowControllerlast{

    public class GameController : MonoBehaviour
{

        public Slider slider;
        public GameObject loadingPanel;
        public GameObject LoginPanel;
        
        public InputField inputField; // Reference to the InputField component
        public Text OutputText;
        public Text CreateStateStatus;

        public Text sampleTransaction;

        public Text updatePlstatus;

        public Text AccountName;
        public Text UserAddress;

        
        public static GameController Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = FindObjectOfType<GameController>();
                }

                return m_instance;
            }
        }

                private static GameController m_instance = null;

                private void Start()
        {
            if (Instance != this)
            {
                Destroy(this);
                return;
            }

            //Set the starting state to be the LOGIN state.
         
        }

        // public void CreateEmulatorAccount(){
        //     StartCoroutine(FlowControllerlast.Instance.CreateEmulatorAccount(inputField.text, OnCreateAccountSuccess, OnCreateAccountFailure));
        // }

        // public void CreateTestAccount(){
        //     StartCoroutine(FlowControllerlast.Instance.CreateTestAccount(inputField.text, OnCreateAccountSuccess, OnCreateAccountFailure));

        // }
        // public void OnCreateAccountSuccess(string username, string address){
 
        //     OutputText.text = "Successfull";


        // }

        // public void OnCreateAccountFailure(){
        //     OutputText.text = "UnSuccessfull, try again";
        // }

        // // Start is called before the first frame update

        // private void Update() {
        //     if(Input.GetKeyDown(KeyCode.Space)){
        //         GetPlutonium();
        //     }
        // }

        public void LoginEmulator()
        {
            FlowControllerlast.Instance.LoginEmulator("Krish",OnLoginSuccess, OnLoginFailure);
        }

        public void Login()
        {
            FlowControllerlast.Instance.Login("Krish",OnLoginSuccess, OnLoginFailure);
        }
   
        private void OnLoginSuccess(string address, string username)
        {
            
            Debug.Log("Login Successfull"+username+address);
            LoginPanel.SetActive(false);
            AccountName.text = username;
            UserAddress.text = address;

        }

        private void OnLoginFailure()
        {
            Debug.Log("Login not Successfull");

        }

        public void NewGame()
        {
            StartCoroutine(FlowControllerlast.Instance.CreateState("Krish", OnNewGameSuccess, OnNewGameFailure));
        }

        public void OnNewGameSuccess(){
            Debug.Log("State Creation Successfull");
            StartCoroutine(LoadAsynchronously("intro-cutscene"));
    
        }

        public void OnNewGameFailure(){
            Debug.Log("State Creation Failed");
   

        }


        public void UpdatePlutonium(){
            StartCoroutine(FlowControllerlast.Instance.UpdatePlutonium(OnPlutoSuccess, OnPlutoFailure));
        }

        


        private void OnPlutoSuccess()
        {
            Debug.Log("Plutonium Update");
            slider.value = 0f;
            loadingPanel.SetActive(true);
            StartCoroutine(LoadAsynchronously("dk"));

        }

        private void OnPlutoFailure()
        {
            Debug.Log("Plutonium not updated");

        }

        public void Logout(){
            FlowControllerlast.Instance.Logout();
            LoginPanel.SetActive(true);
        }
        
        System.Collections.IEnumerator LoadAsynchronously(string sceneName)

        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                yield return null;
            }
        }

}

}
