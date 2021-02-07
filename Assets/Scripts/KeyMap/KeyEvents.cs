using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyEvents : MonoBehaviour {
    
	private KeyMap controls;

	public static Vector2 viewDir, moveDir;
	public static bool isRunning=false, isJumping=false, onPause=false, onToggleConsole=false, onSubmit=false;
	
	private void Awake() {
	controls = new KeyMap();
	
	controls.Player.View.performed		+= ctx => OnView(ctx.ReadValue<Vector2>());
	controls.Player.View.canceled		+= ctx => OnView(ctx.ReadValue<Vector2>());
	controls.Player.Move.performed		+= ctx => OnMove(ctx.ReadValue<Vector2>());
	controls.Player.Move.canceled		+= ctx => OnMove(ctx.ReadValue<Vector2>());
	controls.Player.Sprint.performed	+= ctx => OnSprint(ctx.performed);
	controls.Player.Sprint.canceled		+= ctx => OnSprint(ctx.performed);
	controls.Player.Jump.performed		+= ctx => OnJump(ctx.performed);
	controls.Player.Jump.canceled		+= ctx => OnJump(ctx.performed);
	
	controls.UI.Pause.performed			+= ctx => OnPause();
	controls.UI.ToggleConsole.performed	+= ctx => OnToggleConsole();
	controls.UI.Submit.performed		+= ctx => OnSubmit();

	controls.Enable();
	}
	private void OnDisable() {controls.Disable();}

	void OnView(Vector2 i)	{if(!onToggleConsole) viewDir = i; else viewDir=Vector2.zero;}
	void OnMove(Vector2 i)	{if(!onToggleConsole) moveDir = i; else moveDir=Vector2.zero;}
	void OnSprint(bool t)	{if(!onToggleConsole) isRunning = t;}
	void OnJump(bool t)		{if(!onToggleConsole) isJumping = t;}

	void OnPause()			{if(!onToggleConsole) onPause = !onPause;}
	void OnToggleConsole()	{onToggleConsole = !onToggleConsole;}
	void OnSubmit()			{onSubmit=true;}
}
