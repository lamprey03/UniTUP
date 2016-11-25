using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System;
using UnityEngine.UI;

public class LoginUser : MonoBehaviour {
	public GameObject username;
	public GameObject password;
	private string Username;
	private string Password;
	//string LoginURL = "localhost/TUP-OTG/LoginUser.php";
	string LoginURL = "http://tup-otg.comli.com/LoginUser.php";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Ilalagay yung laman ng mga fields sa variables e.g. Username at Password
		Username = username.GetComponent<InputField> ().text;
		Password = password.GetComponent<InputField> ().text;
	}

	public void LoginButton(){
		//Kapag may laman ang Password at Username
		if (Password != "" && Username != "") {
			//Irurun yung Function na LoginToDB na may parameter ng variables
			StartCoroutine (LoginToDB (Username, Password));
		} else //Kung walang laman yung user or pass or parehas wala
			Debug.Log ("Please enter a username and password");
	}

	IEnumerator LoginToDB(string username_input, string password_input){
		WWWForm form = new WWWForm ();
		form.AddField ("usernamePost", username_input); //Ipapasa sa PHP File na nasa LoginURL ang laman ng variable na Username
		form.AddField ("passwordPost", password_input); //Ipapasa sa PHP File na nasa LoginURL ang laman ng variable na Password
		WWW www = new WWW (LoginURL, form);
		yield return www;
		Debug.Log (www.text);

	}
}
