using UnityEngine;
using System.Collections;

public class audio : MonoBehaviour
{

	//音乐文件  
	public AudioSource musicSource;     
	//音量  
	public float musicVolume = 0.5f;
	
	UILabel mWidget;
	UISlider vSlider;
//	private float _music = 0.0f;
//	private float _sound = 0.0f;
	string sourceName = string.Empty;
	
	void Start ()
	{  
		if (musicSource != null) {
			sourceName = musicSource.name;
			//设置默认音量  		
//			_music = PlayerPrefs.GetFloat ("music");
//			_sound = PlayerPrefs.GetFloat ("sound");
			musicVolume = PlayerPrefs.GetFloat(sourceName);
			print(musicVolume+"??");
			vSlider = musicSource.transform.GetComponent<UISlider> ();
			
			if (musicVolume == -1f) {//music and sound is turn down
				musicSource.playOnAwake = false;
				musicSource.mute = true;
				vSlider.sliderValue = 0f;				
				
//				print (_music + "<1>" + _sound);
				
			} else {
				musicSource.playOnAwake = true;				
				if (sourceName == "Slider-music") {
					musicSource.bypassEffects = true;
				}
				vSlider.sliderValue = musicVolume;
//				if (musicSource.name.Substring (musicSource.name.IndexOf ('-') + 1) == "sound") {
//					vSlider.sliderValue = _sound;
//				} else {
//					vSlider.sliderValue = _music;
//					musicSource.bypassEffects = true;
//				}
				
//				print (_music + "<2>" + _sound);
				
			}
		
			
//			if(vSlider.name == "Slider-music")
//				music.bypassEffects=true;
			
//			Debug.Log("?"+vSlider.name);
		}
		
	}

	void OnClick ()
	{
		if (!musicSource.isPlaying) {
			musicSource.Play ();
		} else if (musicSource.isPlaying) {
//			music.Stop();
			musicSource.Pause ();			
		}		
	}

	void OnPress ()
	{
		/*if(vSlider == null){
			vSlider = GameObject.Find("Slider").GetComponent<UISlider>();
			vSlider.sliderValue = musicVolume;
//			vSlider.onValueChange +=Slider
		}*/
		if (musicSource != null) {
			vSlider = musicSource.transform.GetComponent<UISlider> ();
//			musicSource.mute=false;
			musicSource.Play ();
			vSlider.sliderValue = musicVolume;	
		}
		
		Debug.Log ("press" + vSlider.name);		
	}

	void OnSliderChange (float val)
	{
		musicSource.mute = false;
		if (musicSource.isPlaying) {  
			//音乐播放中设置音乐音量 取值范围 0.0F到 1.0   
			
//			if (musicSource.name.Substring (musicSource.name.IndexOf ('-') + 1) == "sound") {
//				_sound = val;
//			} else {
//				_music = val;
//			}
			musicSource.volume =musicVolume= val;  
		}  
			
		//Debug.Log("in the slider :"+music.volume);
	}

	void OnBecameInvisible ()
	{
		Debug.Log ("vvvd");
	}

	void OnDisable ()
	{
//		print (_music + "<?>" + _sound);
		if (vSlider.sliderValue == 0) {
			PlayerPrefs.SetFloat (sourceName, -1);
		} else {
			PlayerPrefs.SetFloat (sourceName,musicVolume);
//			PlayerPrefs.SetFloat ("sound", _sound);			
		}

	}
//    void OnGUI()
	void ShowIt ()
	{  
          
		//播放音乐按钮  
		if (GUI.Button (new Rect (10, 10, 100, 50), "Play music")) {  
              
			//没有播放中  
			if (!musicSource.isPlaying) {  
				//播放音乐  
				musicSource.Play ();  
			}  
              
		}  
          
		//关闭音乐按钮  
		if (GUI.Button (new Rect (10, 60, 100, 50), "Stop music")) {  
              
			if (musicSource.isPlaying) {  
				//关闭音乐  
				musicSource.Stop ();  
			}  
		}  
		//暂停音乐  
		if (GUI.Button (new Rect (10, 110, 100, 50), "Pause music")) {  
			if (musicSource.isPlaying) {  
				//暂停音乐  
				//这里说一下音乐暂停以后  
				//点击播放音乐为继续播放  
				//而停止以后在点击播放音乐  
				//则为从新播放  
				//这就是暂停与停止的区别  
				musicSource.Pause ();  
			}  
		}  
  
		//创建一个横向滑动条用于动态修改音乐音量  
		//第一个参数 滑动条范围  
		//第二个参数 初始滑块位置  
		//第三个参数 起点  
		//第四个参数 终点  
		musicVolume = GUI.HorizontalSlider (new Rect (160, 10, 100, 50), musicVolume, 0.0F, 1.0F);  
      
		//将音量的百分比打印出来  
		GUI.Label (new Rect (160, 50, 300, 20), "Music Volueme is " + (int)(musicVolume * 100) + "%");  
          
		if (musicSource.isPlaying) {  
			//音乐播放中设置音乐音量 取值范围 0.0F到 1.0   
			musicSource.volume = musicVolume;  
		}  
	}  
	
	
}
