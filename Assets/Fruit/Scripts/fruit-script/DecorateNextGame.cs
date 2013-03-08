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
		int currentMode = PlayerPrefs.GetInt ("NowMode");
		int _nowPlay = PlayerPrefs.GetInt ("NowPlay");
		print ("current level is :" + _nowPlay);
		PlayerPrefs.SetInt ("NowPlay", _nowPlay + 1);
		print ("next level is :" + (_nowPlay + 1));
        
		Application.LoadLevel("Game2");
		
		//		if (transGamePanel != null)
		//			transGamePanel.GetComponent<GamePlayLayer> ().initGameWindow (PlayerPrefs.GetInt ("NowPlay"));
		//		transGamePanel.GetComponent<TweenPosition>().Play(true);
		//		Globe.getPanelOfParent(transGamePanel,1,"Panel - GameWin").GetComponent<TweenPosition>().Reset();
	}
}
