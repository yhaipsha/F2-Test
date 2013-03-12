using UnityEngine;
using System.Collections;
using LitJson;

public class FruitMain : MonoBehaviour
{
	
	/*void Start()
	{
	//AssetDatabase
			AssetDatabase.ImportAsset("Assets/Textures/texture.jpg", ImportAssetOptions.Default);
	
	
		if (Globe.askbox == null || Globe.askbox2 == null) {		
			print(Globe.assetURL);
			AssetBundle ab = AssetBundle.CreateFromFile(@"Fruit\Scenes\Game.unity3d");//Scenes\Models\Tipi.unity3d
			;print (ab);
			if(ab!=null)
		    {
			     if(ab.mainAsset  !=null)
			     {
					
			      //load resouce into the assetbundle of wwwObject
//			      ab.LoadAsync("Terrain1", typeof(GameObject));
//			      
//			      //创建地形实例
//			      if(Instantiate(wwwObj.assetBundle.mainAsset ) != null) 
//			       Flag = 1;
			     }
		    }
			
			
			SystemData sd = ab.mainAsset as SystemData;
			Globe.askbox = new System.Collections.Generic.List<string[]> ();
			Globe.askbox2 = new System.Collections.Generic.List<string[]> ();
			Globe.askbox3 = new System.Collections.Generic.List<string[]> ();
			
			#region 数据存放本地
			for (int i = 0; i < sd.arrInt.Count; i++) {
				PlayerPrefs.SetString ("first" + i, sd.arrInt [i]);
			}
			for (int i = 0; i < sd.secondInt.Count; i++) {
				PlayerPrefs.SetString ("second" + i, sd.secondInt [i]);
			}
			for (int i = 0; i < sd.thirdInt.Count; i++) {
				PlayerPrefs.SetString ("third" + i, sd.thirdInt [i]);
			}
			#endregion
			#region 数据存放内存
			
//			foreach (string item in sd.arrInt){
//				Globe.askbox.Add (item.Split (','));		
//			}
//			foreach (string item in sd.secondInt) 			{	
//				Globe.askbox2.Add (item.Split (','));			
//			}
//			foreach (string item in sd.thirdInt) {	
//				Globe.askbox3.Add (item.Split (','));			
////				print (item);
//			}
			#endregion
//			PlayerPrefs.SetInt ("loading", 1);
			
			print ("loading... is over !level1=" + Globe.askbox.Count+";level2="+ Globe.askbox2.Count+";level3="+Globe.askbox3.Count);
		}
//		PlayerPrefs.DeleteAll();
//		StartCoroutine ("GetTwitterUpdate");     
//		PlayerPrefs.DeleteKey("GameWindow");
		
	}*/
	
	IEnumerator Start ()
	{
		if (Globe.askbox == null || Globe.askbox2 == null) {		

			WWW www = new WWW (Globe.assetURL);
			yield return www;
			SystemData sd = www.assetBundle.mainAsset as SystemData;
			Globe.askbox = new System.Collections.Generic.List<string[]> ();
			Globe.askbox2 = new System.Collections.Generic.List<string[]> ();
			Globe.askbox3 = new System.Collections.Generic.List<string[]> ();
			
			#region 数据存放本地
//			for (int i = 0; i < sd.arrInt.Count; i++) {
//				PlayerPrefs.SetString ("first" + i, sd.arrInt [i]);
//			}
//			for (int i = 0; i < sd.secondInt.Count; i++) {
//				PlayerPrefs.SetString ("second" + i, sd.secondInt [i]);
//			}
//			for (int i = 0; i < sd.thirdInt.Count; i++) {
//				PlayerPrefs.SetString ("third" + i, sd.thirdInt [i]);
//			}
			#endregion
			#region 数据存放内存
			
			foreach (string item in sd.arrInt) {
				Globe.askbox.Add (item.Split (','));		
			}
			foreach (string item in sd.secondInt) {	
				Globe.askbox2.Add (item.Split (','));			
			}
			foreach (string item in sd.thirdInt) {	
				Globe.askbox3.Add (item.Split (','));
			}
			#endregion
//			PlayerPrefs.DeleteAll ();
//			StartCoroutine ("GetTwitterUpdate");     
			print ("loading... is over !level1=" + Globe.askbox.Count + ";level2=" + Globe.askbox2.Count + ";level3=" + Globe.askbox3.Count);
		}
	}
	/**/
	IEnumerator GetTwitterUpdate ()//IEnumerator
	{
		WWW www = new WWW (Globe.jsonURL);
		yield return www;

		/*
        float elapsedTime = 0.0f;
        while (!www.isDone) {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 10.0f)
                break;			
            yield return null;  
        } 
        if (!www.isDone || !string.IsNullOrEmpty (www.error)) {
            Debug.LogError (string.Format ("Fail Whale!\n{0}", www.error));
            yield break;
        }*/

		JsonData root = JsonMapper.ToObject (www.data);

		JsonData lf = root ["level"];
		ICollection keyss = (lf as IDictionary).Keys;
		string[] array = new string[keyss.Count];
		keyss.CopyTo (array, 0);

		for (int i = 0; i < array.Length; i++) {
			if (lf [i].IsArray) {
				JsonData[] jarr = JsonMapper.ToObject<JsonData[]> (lf [i].ToJson ());
				for (int j = 1; j <= jarr.Length; j++) {
					PlayerPrefs.SetInt ("star-" + array [i] + j, (int)jarr [j - 1]);
//					print (("star-" + array [i] + j) + "==" + (int)jarr [j-1]);
				}
			}
		}
	}
	
	public IEnumerator getLevels (string modeAndLevel)
	{
		WWW www = new WWW (Globe.levelURL);
		yield return www;
		
		print (modeAndLevel);
		JsonData root = JsonMapper.ToObject (www.data);
		string[] str = modeAndLevel.Split (',');
		JsonData lf = root ["level"];
		int _num = int.Parse (str [1]);
		string _data = lf [str [0]] [_num - 1].ToJson ().Substring (1);
		
		print ((str [0] + _num) + "??" + _data.Substring (0, _data.Length - 1));		
		PlayerPrefs.SetString (str [0] + _num, _data.Substring (0, _data.Length - 1));
		
	}

	public static void WriteJson (string path)
	{
		WWW www = new WWW (Globe.jsonURL);

		JsonData root = JsonMapper.ToObject (www.data);

		JsonData lf = root ["level"];//root["level"]["first"];
		JsonData dt = lf [0] ["star"];
		dt.Add (3);
		print (lf [0] ["star"].ToJson () + " ** " + dt.Count);

		System.Text.StringBuilder sb = new System.Text.StringBuilder ();
		JsonWriter writer = new JsonWriter (sb);
		writer.WriteArrayStart ();
		writer.Write (1);
		writer.Write (2);
		writer.Write (3);
		writer.WriteObjectStart ();
		writer.WritePropertyName ("color");
		writer.Write ("blue");
		writer.WriteObjectEnd ();
		writer.WriteArrayEnd ();


		print (sb.ToString ());

		//输出：[1,2,3,{"color":"blue"}]
	}

}

