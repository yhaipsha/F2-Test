using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;

public class test : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
		//数据库文件储存地址
 
		string appDBPath = Application.persistentDataPath + "/xuanyusong.db";
// 		if(FileUtil.isExists(appDBPath))
//			FileUtil.DeleteFile(appDBPath,"");
				
		//创建数据库名称为xuanyusong.db
        DbAccess db = new DbAccess(@"Data Source=" + appDBPath);
 //		DbAccess db = new DbAccess ("data source=xuanyusong.db");

 
		//创建数据库表，与字段

//		db.CreateTable ("momo", new string[]{"name","qq","email","blog"}, new string[]{"text","text","text","text"});
		//请注意 插入字符串是 已经要加上'宣雨松' 不然会报错 
//		db.InsertInto ("momo", new string[]{ "'宣雨松'","'289187120'","'xuanyusong@gmail.com'","'www.xuanyusong.com'"   });
//		db.UpdateInto ("momo", new string[]{"name","qq"}, new string[]{"'xuanyusong'","'11111111'"}, "email", "'xuanyusong@gmail.com'");
//		//然后在删掉两条数据
//		db.Delete ("momo", new string[]{"email","email"}, new string[]{"'xuanyusong@gmail.com'","'000@gmail.com'"});
//		
		//注解1
 
		SqliteDataReader sqReader = db.SelectWhere ("momo", new string[]{"name","email"}, new string[]{"qq"}, new string[]{"="}, new string[]{"289187120"});
 
		while (sqReader.Read()) {
 
			Debug.Log (sqReader.GetString (sqReader.GetOrdinal ("name")) + sqReader.GetString (sqReader.GetOrdinal ("email")));
 
		}
		
		//关闭对象

		db.CloseSqlConnection ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Home)) {

			Application.Quit ();
 
		}
	}
}
