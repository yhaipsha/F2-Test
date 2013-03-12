using UnityEngine;
using System.Collections;

public class GotoScene : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void OnClick ()
	{
		string sceneName = transform.name.Substring (transform.name.IndexOf ('-'));
		print (sceneName);
		switch (sceneName) {
		case "-Shop":
			Application.LoadLevel ("Shop");
			break;
			
		case "-Home":
			if (transform.parent.name == "Panel - Level") {
//				this.SendMessageUpwards ("cleanLevels");				
			}
			Application.LoadLevel ("FruitMain phone");
			break;
			
		case "-Help":
//			this.SendMessageUpwards ("cleanLevels");
			Application.LoadLevel ("FruitMain phone");
			break;
			
		case "-Set":
//			this.SendMessageUpwards ("cleanLevels");
			Application.LoadLevel ("Set");
			break;
		
		case "-Level":
//			this.SendMessageUpwards ("cleanLevels");
			Application.LoadLevel ("Level");
			break;
			
		 case "-Replay":
//			int _nowMode = PlayerPrefs.GetInt("NowMode");
//			int _nowPlay = PlayerPrefs.GetInt("NowPlay");
//			print (_nowMode+"??"+_nowPlay);
//			FruitMain f = new FruitMain ();
//			StartCoroutine (f.getLevels (Globe.Compare (_nowMode) + "," + _nowPlay));
			
//			yield return new WaitForSecond(0.3f);
			Application.LoadLevel ("Game2");
			break;
			
		case "-Next":
//			this.SendMessageUpwards ("cleanLevels");	
			PlayerPrefs.SetInt("NowPlay",PlayerPrefs.GetInt("NowPlay")+1);
			Application.LoadLevel ("Game2");
			break;
		}

	}
}
