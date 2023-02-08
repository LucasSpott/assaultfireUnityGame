using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayFabLogin : MonoBehaviour
{
    [SerializeField] private string customId = default;
    
    public static string SessionTicket;
    public static string EntityId;

    [SerializeField] private GameObject signInDisplay = default;
    [SerializeField] private GameObject createAccountDisplay = default;
    [SerializeField] private TMP_InputField usernameInputField = default;
    [SerializeField] private TMP_InputField emailInputField = default;
    [SerializeField] private TMP_InputField passwordInputField = default;

    [SerializeField] private TMP_InputField usernameInputFieldLogin = default;
    [SerializeField] private TMP_InputField passwordInputFieldLogin = default;

    public void CreateAccount(){

        if(string.IsNullOrEmpty(usernameInputField.text) || string.IsNullOrEmpty(emailInputField.text) || string.IsNullOrEmpty(passwordInputField.text)){
            Debug.LogError("Please fill in all fields");
            return;
        }

       if(usernameInputField.text == "ADM" || usernameInputField.text == "Admin" || usernameInputField.text == "admin" || usernameInputField.text == "ADMIN" || usernameInputField.text == "Adm" || usernameInputField.text == "adm" || usernameInputField.text == "GM" || usernameInputField.text == "Gm" || usernameInputField.text == "gm" || usernameInputField.text == "moder" || usernameInputField.text == "MODER" || usernameInputField.text == "Moder" || usernameInputField.text == "Moderador" || usernameInputField.text == "moderador" || usernameInputField.text == "MODERADOR"){
            Debug.LogError("Voce nao pode criar uma conta com esse nome");
            return;
        }

        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest{
            Username = usernameInputField.text,
            DisplayName = usernameInputField.text,
            Email = emailInputField.text,
            Password = passwordInputField.text,
            RequireBothUsernameAndEmail = false
        }, result => {
            Debug.Log("Account Created");
            EntityId = result.EntityToken.Entity.Id;
            signInDisplay.SetActive(true);
        }, error => {
            Debug.LogError(error.GenerateErrorReport());
        });
    }

    public void SignIn(){
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest{
            Username = usernameInputFieldLogin.text,
            Password = passwordInputFieldLogin.text
        }, result => {
            Debug.Log("Signed In");
            EntityId = result.EntityToken.Entity.Id;
            SessionTicket = result.SessionTicket;
            SceneManager.LoadScene("Lobby");
        }, error => {
            Debug.LogError(error.GenerateErrorReport());
        });
    }

    public void SignInCanvas(){
        createAccountDisplay.SetActive(true);
    }
}
