using UnityEngine;

public class GManager : MonoBehaviour {

	static bool goSandbox = false;
	static bool onResume = false;
	static bool onSettings = false;
	static bool onReturnMM = false;

	static GameObject aboutPop;

    private void Start() {
        Application.targetFrameRate = 160;
		if(InGameUI.pauseMenu) InGameUI.pauseMenu.SetActive(false);
    }
	private void Update() {
		if(goSandbox) {StartCoroutine(SManager.sceneChange("Sandbox")); goSandbox=false;}
		if(KeyEvents.onPause && !onResume) PauseGame(); else ResumeGame();
		if(onResume) {KeyEvents.onPause=false; onResume=false;}
		if(onSettings) OpenSettings(true);
		if(onReturnMM) {
			KeyEvents.onPause=false; 
			StartCoroutine(SManager.sceneChange("MainMenu")); 
			MPlayer.setCanStats(false);
			onReturnMM=false;}
	}

	public static void PauseGame() {
        Time.timeScale = 0f;
		if(InGameUI.pauseMenu) InGameUI.pauseMenu.SetActive(true);
	}
    public static void ResumeGame() {
        Time.timeScale = 1f;
		if(InGameUI.pauseMenu) InGameUI.pauseMenu.SetActive(false);
	}
	
	//MAIN MENU BUTTONS
	public static void bMMPlay()	{goSandbox=true;}
	public static void bMMQuit()	{Application.Quit();}

	//PAUSE MENU BUTTONS
	public static void bPMResume()		{onResume=true;}
	public static void bPMSettings()	{onSettings=true;}
	public static void bPMMainMenu()	{onReturnMM=true;}
	private void OpenSettings(bool t)	{onSettings=false;}

	//MATHF 
	public static bool cBool(string value) {
		return bool.TryParse(value, out _);
	}
	public static bool cBool(string value, bool needReturn) {
		if(needReturn) {bool.TryParse(value, out bool resultB); return resultB;}
		else return false;
	}
	public static bool cFloat(string value) {
		return float.TryParse(value, out _);
	}
	public static float cFloat(string value, bool needReturn) {
		if(needReturn) {float.TryParse(value, out float resultF); return resultF;}
		else return 0;
	}
	public static bool cInt(string value) {
		return int.TryParse(value, out _);
	}
	public static int cInt(string value, bool needReturn) {
		if(needReturn) {int.TryParse(value, out int resultI); return resultI;}
		else return 0;
	}

}
