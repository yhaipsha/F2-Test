using UnityEngine;
using System.Collections;

public class TurnAnimate : MonoBehaviour
{	
	public event ProcessDelegate ProcessEvent;
	public event animatePlayOver EventPlayOver;

	public UISprite sprite;
	public UISprite spriteBg;

//	private GameObject target;
	public bool autoReverse = false;
	UISlicedSprite spHead;
	// Use this for initialization
	
	void ProcessAction (object sender, string e)
	{
		if (ProcessEvent == null)
			ProcessEvent += new ProcessDelegate (t_ProcessEvent);
		ProcessEvent (sender, e);
	}

	//如果没有自己指定关联方法，将会调用该方法抛出错误
	void t_ProcessEvent (object sender, string e)
	{
		print ("The method or operation is not implemented.??" + e);
	}
	string playOver (string animateName)
	{
		if (animateName == "turn_go_over" && PlayerPrefs.GetInt("NowMode") !=1) {
				SendMessageUpwards("doPunish",transform.name);			
		}
		else if(animateName =="turn_back_over")
		{
			SendMessageUpwards("delayPunish",transform.name);	
		}else if (animateName == "turn_go_over" && PlayerPrefs.GetInt("NowMode") ==1)
		{
			PlayerPrefs.SetInt ("turn_go_over",1);
		}
		return animateName;
	}
	
	void Start ()
	{		
		EventPlayOver += new animatePlayOver(playOver);
	}

	void OnClick ()
	{		
//		if (sprite != null && spriteBg != null) 
		{	
			switch (PlayerPrefs.GetInt ("NowMode")) {
			case 1:
				SendMessageUpwards ("mode1", transform.name);
				break;
			case 2:
				SendMessageUpwards ("mode2", transform.name);
				break;
			case 3:
				SendMessageUpwards("mode2",transform.name);
				break;
			}		
		}
	}

	void Update ()
	{

		if (PlayerPrefs.GetInt ("cardReady") == 1) {
			SendMessageUpwards ("show");
			PlayerPrefs.SetInt ("cardReady", 2);
		}
	}
	

	IEnumerator playReplace ()
	{
		//		ExampleAtlas ra = target.transform.GetComponent<ExampleAtlas>();
		//		ra.init();
		//		autoReverse = false;
		yield return new WaitForSeconds(0.9f);
		//		ra.NextSprite(sp.spriteName);
	}
}
