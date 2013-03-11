using UnityEngine;
using System.Collections.Generic;

[AddComponentMenu("NGUI/Game/UI Item Storage Test")]
public class UIItemStorageTest : MonoBehaviour
{
	public int maxRows = 4;
	public int maxColumns = 4;
	public GameObject template;
	public bool childrenAutoReverse = true;
	public int spacing = 128;
	public int padding = 10;
		


	void Start ()
	{		
		//createTemp();		
	}
	GameObject addGameObject(string spriteName)
	{
		GameObject tempObj = (GameObject)Instantiate (template);
		tempObj.transform.parent = transform;
		tempObj.transform.localScale = new Vector3 (1f, 1f, 1f);
//		print ("in the test ="+spriteName);
//		tempObj.GetComponent<TurnRight2>().autoReverse = childrenAutoReverse; -level1;Sprite-box
		
		UISlicedSprite sprite = tempObj.transform.FindChild("Sprite-box").GetComponent<UISlicedSprite> ();			
//		sprite.transform.rotation = Quaternion.Euler (0f, 180f, 0f);
		sprite.spriteName = spriteName;		
		sprite.MakePixelPerfect ();
		
		return tempObj;
	}
	
	public static Dictionary<string, int> dir = new Dictionary<string, int>();
	
	public void createTemp(string[] arrSprites)
	{
		if (template != null)
		{
			int count = 0;
			Bounds b = new Bounds();
			int i=0;
			for (int y = 0; y < maxRows; ++y)
			{
				for (int x = 0; x < maxColumns; ++x)
				{
//					template.GetComponent<TurnRight2>().enabled=true;
					
					//GameObject go = NGUITools.AddChild(gameObject, template);					
					GameObject go = addGameObject(arrSprites[i]);
					go.name="player"+i;i++;
					Transform t = go.transform;
					t.localPosition = new Vector3(padding + (x + 0.5f) * spacing, -padding - (y + 0.5f) * spacing, 0f);
					b.Encapsulate(new Vector3(padding * 2f + (x + 1) * spacing, -padding * 2f - (y + 1) * spacing, 0f));

					if (++count >= arrSprites.Length)
					{
						return;
					}
				}
			}
		}
	}
	
	public void UpdateArrange()
	{
		Debug.Log("3333");
		
//		NGUITools.SetActive(gameObject,true);
	}
	public void  cleaner()
	{
		for (int i = 0; i < transform.GetChildCount(); i++) {
			Destroy(transform.GetChild(i).gameObject,1.0f);
		}
		//Destroy(this.gameObject,1.0f);
	}
	
	void LateUpdate()
	{
		//UpdateArrange();
		foreach (var item in dir)   
        {   
           print(item.Key+":==:"+item.Value);   
        }  
	}
}