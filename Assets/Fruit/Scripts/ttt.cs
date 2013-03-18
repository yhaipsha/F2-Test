using UnityEngine;
using System.Collections;
//using System.Resources;

public class ttt : MonoBehaviour {
	
	Material mt = null;
	// Use this for initialization
	void Start () {
		mt = transform.GetComponent<UITexture>().material;	
	}

	// Update is called once per frame
	void Update () {
//		renderer.material = mt;
//		print (mt.shader.name);
//		mt.SetVector("_Progress", new Vector4(0f,0f,1f,1f));
//		renderer.material.SetVector("_Progress", Vector3.one);
//		renderer.material.SetVector("_Progress",当前血量、进度百分比等等..);
	}
}
