using UnityEngine;
using System.Collections;

public class Test2 : MonoBehaviour {

	//这里是需要加载激活的游戏对象
  public GameObject  [] Objects;

  //当前加载的进度
  int load_index =0;

  void Start ()
  {
      //开启一个异步任务，加载模型。
      StartCoroutine(loadObject());
  }



  IEnumerator loadObject()
  {
      //便利所有游戏对象
      foreach(GameObject obj in Objects)
      {
          //激活游戏对象
          obj.active = true;
          //记录当前加载的对象
          load_index ++;


          //这里可以理解为通知主线程刷新UI

          yield return 0;

      }

      //全部便利完毕返回

      yield return 0;

  }



  void OnGUI ()

  {

      //显示加载的进度

      GUILayout.Box("当前加载的对象ID是： " + load_index);

    }

}
