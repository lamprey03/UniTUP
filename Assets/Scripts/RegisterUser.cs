using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System;
using UnityEngine.UI;

public class RegisterUser : MonoBehaviour {
	public GameObject username;
	public GameObject password;
	public GameObject conf_password;
	public GameObject email;
	private string Username;
	private string Password;
	private string Conf_Password;
	private string Email;
	//string RegisterURL = "localhost/TUP-OTG/RegisterUser.php";
	string RegisterURL = "http://tup-otg.comli.com/RegisterUser.php";
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		//Ilalagay yung laman ng mga fields sa variables e.g. Username at Password
		Username = username.GetComponent<InputField> ().text;
		Password = password.GetComponent<InputField> ().text;
		Conf_Password = conf_password.GetComponent<InputField> ().text;
		Email = email.GetComponent<InputField> ().text;
	}

	public void RegisterButton(){
		//Kapag may laman ang Password at Username
		if (Password != "" && Username != "" && Conf_Password != "" && Email != "") {
			//Irurun yung Function na LoginToDB na may parameter ng variables
			if (Username.Length < 7 || Password.Length<7) {
				print ("Username must have 7-20 characters");
			}else{
				StartCoroutine (RegisterToDB (Username, Password, Email));
				}
		
		} else //Kung walang laman yung user or pass or parehas wala
			Debug.Log ("Please enter a username and password");
	}

	IEnumerator RegisterToDB(string username_input, string password_input, string email_input){
		WWWForm form = new WWWForm ();
		form.AddField ("reg_usernamePost", username_input); //Ipapasa sa PHP File na nasa LoginURL ang laman ng variable na Username
		form.AddField ("reg_passwordPost", password_input);
		form.AddField ("reg_emailPost", email_input);
		//Ipapasa sa PHP File na nasa LoginURL ang laman ng variable na Password
		WWW www = new WWW (RegisterURL, form);
		yield return www;
		Debug.Log (www.text);

	}
}
