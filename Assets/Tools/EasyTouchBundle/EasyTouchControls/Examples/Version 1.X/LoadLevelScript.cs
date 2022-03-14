using UnityEngine;
using System.Collections;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif

public class LoadLevelScript : MonoBehaviour {
	
	public void LoadMainMenu(){
		#if UNITY_5_3
		SceneManager.LoadScene( "MainMenu");
		#else
#pragma warning disable 618
		Application.LoadLevel( "MainMenu");
#pragma warning restore 618
#endif
	}
	
	public void LoadJoystickEvent(){
		#if UNITY_5_3
		SceneManager.LoadScene( "Joystick-Event-Input");
		#else
#pragma warning disable 618
		Application.LoadLevel( "Joystick-Event-Input");
#pragma warning restore 618
#endif
	}
	
	public void LoadJoysticParameter(){
		#if UNITY_5_3
		SceneManager.LoadScene("Joystick-Parameter");
		#else
#pragma warning disable 618
		Application.LoadLevel("Joystick-Parameter");
#pragma warning restore 618
#endif
	}
	
	public void LoadDPadEvent(){
		#if UNITY_5_3
		SceneManager.LoadScene("DPad-Event-Input");
		#else
#pragma warning disable 618
		Application.LoadLevel("DPad-Event-Input");
#pragma warning restore 618
#endif
	}
	
	public void LoadDPadClassicalTime(){
		#if UNITY_5_3
		SceneManager.LoadScene("DPad-Classical-Time");
		#else
#pragma warning disable 618
		Application.LoadLevel("DPad-Classical-Time");
#pragma warning restore 618
#endif
	}
	
	public void LoadTouchPad(){
		#if UNITY_5_3
		SceneManager.LoadScene("TouchPad-Event-Input");
		#else
#pragma warning disable 618
		Application.LoadLevel ("TouchPad-Event-Input");
#pragma warning restore 618
#endif
	}
	
	public void LoadButton(){
		#if UNITY_5_3
		SceneManager.LoadScene("Button-Event-Input");
		#else
#pragma warning disable 618
		Application.LoadLevel("Button-Event-Input");
#pragma warning restore 618
#endif
	}
	
	public void LoadFPS(){
		#if UNITY_5_3
		SceneManager.LoadScene("FPS_Example");
		#else
#pragma warning disable 618
		Application.LoadLevel("FPS_Example");
#pragma warning restore 618
#endif
	}
	
	public void LoadThird(){
		#if UNITY_5_3
		SceneManager.LoadScene("ThirdPerson+Jump");
		#else
#pragma warning disable 618
		Application.LoadLevel("ThirdPerson+Jump");
#pragma warning restore 618
#endif
	}
	
	public void LoadThirddungeon(){
		#if UNITY_5_3
		SceneManager.LoadScene("ThirdPersonDungeon+Jump");
		#else
#pragma warning disable 618
		Application.LoadLevel("ThirdPersonDungeon+Jump");
#pragma warning restore 618
#endif
	}
}
