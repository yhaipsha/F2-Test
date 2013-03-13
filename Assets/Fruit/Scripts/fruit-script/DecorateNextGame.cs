using UnityEngine;
using System.Collections;

public class DecorateNextGame : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}

	public void Initialization ()
	{

	}

	public Transform transGamePanel;

	void OnClick ()
	{
		//next level
//		int _nowMode = PlayerPrefs.GetInt ("NowMode");
		int _nowPlay = PlayerPrefs.GetInt ("NowPlay") + 1;		
		print ("the next level is :" + (_nowPlay));
		
		PlayerPrefs.SetInt ("NowPlay", _nowPlay);        
//		FruitMain f = new FruitMain ();
//		StartCoroutine (f.getLevels (Globe.Compare (_nowMode) + "," + _nowPlay));
		Application.LoadLevel ("Loading");
		
		//		if (transGamePanel != null)
		//			transGamePanel.GetComponent<GamePlayLayer> ().initGameWindow (PlayerPrefs.GetInt ("NowPlay"));
		//		transGamePanel.GetComponent<TweenPosition>().Play(true);
		//		Globe.getPanelOfParent(transGamePanel,1,"Panel - GameWin").GetComponent<TweenPosition>().Reset();
	}
}
