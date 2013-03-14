using UnityEngine;
using LitJson;
using System.Collections;

public class Loading : MonoBehaviour
{
	private float fps = 10.0f;
	private float time;

	//一组动画的贴图，在编辑器中赋值。
	public Texture2D[] animations;
	private int nowFram;

	//异步对象
	AsyncOperation async;

	//读取场景的进度，它的取值范围在0 - 1 之间。
	int progress = 0;
	private int _nowPlay = 1;
	private int _nowMode = 1;
	private string _nowModeSign = string.Empty;

	void Start ()
	{
		//在这里开启一个异步任务，
		//进入loadScene方法。
		_nowPlay = PlayerPrefs.GetInt ("NowPlay");
		_nowModeSign = Globe.Compare (PlayerPrefs.GetInt ("NowMode"));
		
		
//		StartCoroutine (f.getLevels (Globe.Compare (_nowMode) + "," + _nowPlay));
		string xx = Globe.levelURL.Replace ("file://", "");
		print ("重启 loading is over!" + xx);
		
//		FruitMain fm = transform.GetComponent<FruitMain>();
//		StartCoroutine(fm.getLevels(_nowModeSign + "," + _nowPlay));
//		
//		string strs = FileUtil.LoadFile(xx,"FruitLevel.json");
//		string str = LitJsonUtil.getLevel(strs,_nowModeSign + "," + _nowPlay);
//		PlayerPrefs.SetString (_nowModeSign+_nowPlay, str);
		
		
		
//		FileUtil.CreateFile(Application.persistentDataPath,"android.txt",FruitMain.file_text);
		StartCoroutine (loadScene ());

	}


	//注意这里返回值一定是 IEnumerator
	IEnumerator loadScene ()
	{
		WWW www = new WWW (Globe.levelURL);
		yield return www;
		
		//异步读取场景。
		//Globe.loadName 就是A场景中需要读取的C场景名称。
				
//		print (modeAndLevel);		
		JsonData root = JsonMapper.ToObject (www.text);
//		string[] str = modeAndLevel.Split (',');
		JsonData lf = root ["level"];
		int _num = _nowPlay;// int.Parse (str [1]);
		string _data = lf [_nowModeSign] [_num - 1].ToJson ().Substring (1);
		
		print ((_nowModeSign + _num) + "??" + _data.Substring (0, _data.Length - 1));		
		PlayerPrefs.SetString (_nowModeSign + _num, _data.Substring (0, _data.Length - 1));

		async = Application.LoadLevelAsync ("Game2");//Globe.loadName		
		//读取完毕后返回， 系统会自动进入C场景
		yield return async;

	}

	void OnGUI ()
	{
		//因为在异步读取场景，
		//所以这里我们可以刷新UI
		DrawAnimation (animations);
	}
	
	void FixedUpdate ()
	{
		//在这里计算读取的进度，
		//progress 的取值范围在0.1 - 1之间， 但是它不会等于1
		//也就是说progress可能是0.9的时候就直接进入新场景了
		//所以在写进度条的时候需要注意一下。
		//为了计算百分比 所以直接乘以100即可
		if (async != null) {
			progress = (int)(async.progress * 100);			
			//有了读取进度的数值，大家可以自行制作进度条啦。
			Debug.Log ("xuanyusong" + progress);
			print(async.isDone);
		}else
		{
			;
		}



	}

	//这是一个简单绘制2D动画的方法，没什么好说的。
	void   DrawAnimation (Texture2D[] tex)
	{
		time += Time.deltaTime;
		if (time >= 1.0 / fps) {
			nowFram++;
			time = 0;
			if (nowFram >= tex.Length) {
				nowFram = 0;
			}

		}

		GUI.DrawTexture (new Rect (100, 100, 40, 60), tex [nowFram]);

		//在这里显示读取的进度。
		GUI.Label (new Rect (100, 480, 800, 60), "lOADING!!!!!" + progress);

	}

}
