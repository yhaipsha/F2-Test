using UnityEngine;
using System.Collections;

public class voiceControll : MonoBehaviour {
	
	public AudioSource musicSource;   
	float _music = 0f;
	float _sound = 0f;
	// Use this for initialization
	void Start () {
		if(musicSource != null)
		{
	        //设置默认音量  		
			 _music = PlayerPrefs.GetFloat("music");
			 _sound = PlayerPrefs.GetFloat("sound");
			
//			if (_sound == -1f) {//music and sound is turn down
//				musicSource.playOnAwake=false;
//				musicSource.mute=true;
//				vSlider.sliderValue=0f;
//				
//			}else 
//			{
//				musicSource.playOnAwake = true;				
//				if (musicSource.name.Substring(musicSource.name.IndexOf('-')+1) == "sound") {
//					vSlider.sliderValue=_sound;
//				}else{
//					vSlider.sliderValue = _music;
//					musicSource.bypassEffects=true;
//				}
//				
//				
//			}
		}
	}
	
}
