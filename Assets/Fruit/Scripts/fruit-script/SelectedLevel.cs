using UnityEngine;
using System.Collections.Generic;

public class SelectedLevel : MonoBehaviour
{
	public FruitBrand brand =null;
	
	//初始化游戏页面 
	void Start ()
	{
		_nowMode = PlayerPrefs.GetInt ("NowMode");
	}

	private int _nowPlay = 1;
	private int _nowMode = 1;
	
	int createAtlases2 (List<string[]> item)
	{
		if (item == null) {
			print("cccc");
		}
		//头图片个数  选取数组最后一个Globe.askbox
		int maxCard = item [_nowPlay - 1].Length;
		int cardCount = 0;
		Globe.box = new ArrayRandom (maxCard).NonRepeatArray (1, 16);
		Globe.cards = new List<string> ();
		Globe.askatlases = new List<string> ();

		for (int j = 0; j < maxCard; j++) {
			int __count = int.Parse (item [_nowPlay - 1] [j]);
			if (j == maxCard - 1) {
				Globe.findCount = __count;
			}
			string[] temp = new string[__count];
			for (int k = 0; k < temp.Length; k++) {
				temp [k] = "box" + Globe.box [j];
				//				print (temp [k]);
				Globe.cards.Add (temp [k]);
			}
			if (_nowMode == 1) 
				Globe.askatlases.Add ("boxfind" + Globe.box [j]);
			cardCount += __count;
		}
		return cardCount;
	}

	void OnClick ()
	{
		UILabel lblLevelName = transform.FindChild ("LblTitle").GetComponent<UILabel> ();
		_nowPlay = int.Parse (lblLevelName.text.Trim ());
		PlayerPrefs.SetInt ("NowPlay", _nowPlay);
//		brand = new FruitBrand ();
		
		switch (_nowMode) {
		case 1:
			Globe.errorCount = 3;
//			time = Globe.errorCount.ToString ();			
//			cards = createAtlases (PlayerPrefs.GetString ("first" + (_nowPlay - 1)).Split (','));
			Globe.cardSize = createAtlases2 (Globe.askbox);						
			print ("current level is " + _nowPlay + " from 1 ,and findCount = " + Globe.findCount);			
			break;
		case 2:
			Globe.errorCount = 1;
//			time = Globe.errorCount.ToString ();	//每一个关卡 允许错误次数
//			cards = createAtlases (PlayerPrefs.GetString ("second" + (_nowPlay - 1)).Split (','));
			Globe.cardSize = createAtlases2 (Globe.askbox2);
			break;
		case 3:
//			time = "0:30";//30
//			cards = createAtlases (PlayerPrefs.GetString ("third" + (_nowPlay - 1)).Split (','));
			Globe.cardSize = createAtlases2 (Globe.askbox3);
			break;
			
		}
		
//		Application.LoadLevel("Game2");
	}
}
