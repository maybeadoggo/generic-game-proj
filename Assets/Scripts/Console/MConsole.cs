using UnityEngine;

public class MConsole : MonoBehaviour {
	private string input="";
	private const float msgDelay = 4f;
	private static float timer=0;
	public static string msg="";

	public static bool validCommand = false;

	const string eEmptyInput	= "You have to input something!";
	const string eWrongCommand	= "Unknown or invalid command.";
	const string eWrongArg		= "Unknown or invalid argument.";
	const string eNotEnoughArg	= "Missing command argument.";

	private void Update() {
		if(Timer()) msg="";
	}
	private void OnGUI() {
		GUIStyle middleTxt = new GUIStyle(){fontSize=20,alignment=TextAnchor.MiddleCenter,wordWrap=true};
		middleTxt.normal.textColor=Color.white;
		GUI.Label(new Rect(Screen.width/2-300,35,600,30),msg,middleTxt);

		if(!KeyEvents.onToggleConsole) return;
		CreateConsole();
		if(KeyEvents.onSubmit) OnSubmit();
	}
	private void CreateConsole() {
		validCommand=false;
		float y=0;
		GUI.Box(new Rect(0, y, Screen.width, 30), "");
		GUI.backgroundColor = new Color(0,0,0,0);
		input = GUI.TextField(new Rect(0, y+5, Screen.width, 30), input);
	}
	private void OnSubmit() {
		CheckCommand(input);
		input=""; timer=msgDelay;
		KeyEvents.onSubmit=false;
	}
	private void CheckCommand(string cmd) {
		string[] cmds = cmd.Trim().Split();
		if(cmds.Length !=0 && !string.IsNullOrWhiteSpace(cmd)) {
			msg="";
			switch(cmds[0]) {
				default: msg=eWrongCommand; break;

				case "invertGravity":	Commands.InvertGravity();		break;
				
				case "canView":			if(cmds.Length >= 2) {if(GManager.cBool(cmds[1])) Commands.SetCanView(GManager.cBool(cmds[1],true));			else msg=eWrongArg;} else Commands.GetCanView();		break;
				case "canWalk":			if(cmds.Length >= 2) {if(GManager.cBool(cmds[1])) Commands.SetCanWalk(GManager.cBool(cmds[1],true));			else msg=eWrongArg;} else Commands.GetCanWalk();		break;
				case "canJump":			if(cmds.Length >= 2) {if(GManager.cBool(cmds[1])) Commands.SetCanJump(GManager.cBool(cmds[1],true));			else msg=eWrongArg;} else Commands.GetCanJump();		break;
				case "canFall":			if(cmds.Length >= 2) {if(GManager.cBool(cmds[1])) Commands.SetCanFall(GManager.cBool(cmds[1],true));			else msg=eWrongArg;} else Commands.GetCanFall();		break;
				case "gravity":			if(cmds.Length >= 2) {if(GManager.cFloat(cmds[1])) Commands.SetGravity(GManager.cFloat(cmds[1],true));			else msg=eWrongArg;} else Commands.GetGravity();		break;
				case "jumpHeight":		if(cmds.Length >= 2) {if(GManager.cFloat(cmds[1])) Commands.SetJumpHeight(GManager.cFloat(cmds[1],true));		else msg=eWrongArg;} else Commands.GetJumpHeight();		break;
				case "camSensitivity":	if(cmds.Length >= 2) {if(GManager.cFloat(cmds[1])) Commands.SetCamSensitivity(GManager.cFloat(cmds[1],true));	else msg=eWrongArg;} else Commands.GetCamSensitivity(); break;
				case "walkSpeed":		if(cmds.Length >= 2) {if(GManager.cFloat(cmds[1])) Commands.SetWalkSpeed(GManager.cFloat(cmds[1],true));		else msg=eWrongArg;} else Commands.GetWalkSpeed();		break;
				case "runSpeed":		if(cmds.Length >= 2) {if(GManager.cFloat(cmds[1])) Commands.SetRunSpeed(GManager.cFloat(cmds[1],true));			else msg=eWrongArg;} else Commands.GetRunSpeed();		break;
			}

		} else msg=eEmptyInput;
		if(validCommand) {KeyEvents.onToggleConsole=false;}
	}
	private bool Timer() {
		if(timer>=0)timer-=Time.deltaTime;
		else return true;
		return false;
	}
}