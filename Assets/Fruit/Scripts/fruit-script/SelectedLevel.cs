using UnityEngine;
using System.Collections.Generic;

public class SelectedLevel : MonoBehaviour
{
	public FruitBrand brand = null;
	
	//初始化游戏页面 
	void Start ()
	{
		_nowMode = PlayerPrefs.GetInt ("NowMode");
	}

	private int _nowPlay = 1;
	private int _nowMode = 1;
	
	void OnClick ()
	{
		PlayerPrefs.SetInt ("NowPlay", _nowPlay);
		Application.LoadLevel ("Game2");	
		
	}
	
	void OnPress (bool isPressed)
	{
		UILabel lblLevelName = transform.FindChild ("LblTitle").GetComponent<UILabel> ();
		_nowPlay = int.Parse (lblLevelName.text.Trim ());
		FruitMain f = new FruitMain ();
		StartCoroutine (f.getLevels (Globe.Compare (_nowMode) + "," + _nowPlay));
		
		UISlicedSprite ssp = transform.FindChild ("SpriteLevel0").GetComponent<UISlicedSprite> ();
		if (isPressed && ssp.spriteName == "level1") {
			ssp.spriteName = "level2";
			ssp.MakePixelPerfect ();
		} 
		
	}
	
	int createAtlases2 (List<string[]> item)
	{
		if (item == null) {
			print ("cccc");
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

	int createAtlases3 (string[] item)
	{
		if (item == null) {
			return 0;
		}
		//头图片个数  选取数组最后一个Globe.askbox
		int maxCard = item.Length;
		int cardCount = 0;
		Globe.box = new ArrayRandom (maxCard).NonRepeatArray (1, 16);
		Globe.cards = new List<string> ();
		Globe.askatlases = new List<string> ();

		for (int j = 0; j < maxCard; j++) {
			int __count = int.Parse (item [j]);
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


}
