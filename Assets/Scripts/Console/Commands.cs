using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands : MonoBehaviour {
    const string n_camSensitivity   = "Cam Sensitivity";
    const string n_walkSpeed        = "Walk Speed";
    const string n_runSpeed         = "Run Speed";
    const string n_gravity          = "Gravity";
    const string n_jumpHeight       = "Jump Height";
    const string n_canView          = "canView";
    const string n_canWalk          = "canWalk";
    const string n_canJump          = "canJump";
    const string n_canFall          = "canFall";

    //NO-ARGUMENTS
    public static void InvertGravity() {MConsole.msg="Gravity has been inverted!"; MPlayer.gravity = -MPlayer.gravity; MConsole.validCommand=true;}

    //SETTERS
    private static void Set_MSG(string name, float v1, float v2) {
        MConsole.msg = $"'{name}' has been changed from '{v1}' to '{v2}'!";
        MConsole.validCommand=true;
	}
    private static void Set_MSG(string name, bool v1, bool v2) {
        MConsole.msg = $"'{name}' has been changed from '{v1}' to '{v2}'!";
        MConsole.validCommand=true;
	}
    public static void SetCamSensitivity(float value)   {Set_MSG(n_camSensitivity, MPlayer.camSensitivity, value); MPlayer.camSensitivity=value;}
    public static void SetWalkSpeed(float value)        {Set_MSG(n_walkSpeed,   MPlayer.walkSpeed, value);  MPlayer.walkSpeed=value;}
    public static void SetRunSpeed(float value)         {Set_MSG(n_runSpeed,    MPlayer.runSpeed, value);   MPlayer.runSpeed = value;}
    public static void SetGravity(float value)          {Set_MSG(n_gravity,     MPlayer.gravity, value);    MPlayer.gravity = value;}
    public static void SetJumpHeight(float value)       {Set_MSG(n_jumpHeight,  MPlayer.jumpHeight, value); MPlayer.jumpHeight = value;}
    public static void SetCanView(bool value)           {Set_MSG(n_canView,     MPlayer.canView, value);    MPlayer.canView = value;}
    public static void SetCanWalk(bool value)           {Set_MSG(n_canWalk,     MPlayer.canWalk, value);    MPlayer.canWalk = value;}
    public static void SetCanJump(bool value)           {Set_MSG(n_canJump,     MPlayer.canJump, value);    MPlayer.canJump = value;}
    public static void SetCanFall(bool value)           {Set_MSG(n_canFall,     MPlayer.canFall, value);    MPlayer.canFall = value;}

    //GETTERS
    private static void Get_MSG(string name, float v1) {
        MConsole.msg = $"{name}  =  {v1}";
        MConsole.validCommand=true;
	}
    private static void Get_MSG(string name, bool v1) {
        MConsole.msg = $"{name}  =  {v1}";
        MConsole.validCommand=true;
	}
    public static void GetCamSensitivity()  {Get_MSG(n_camSensitivity,  MPlayer.camSensitivity);}
    public static void GetWalkSpeed()       {Get_MSG(n_walkSpeed,       MPlayer.walkSpeed);}
    public static void GetRunSpeed()        {Get_MSG(n_runSpeed,        MPlayer.runSpeed);}
    public static void GetGravity()         {Get_MSG(n_gravity,         MPlayer.gravity);}
    public static void GetJumpHeight()      {Get_MSG(n_jumpHeight,      MPlayer.jumpHeight);}
    public static void GetCanView()         {Get_MSG(n_canView,         MPlayer.canView);}
    public static void GetCanWalk()         {Get_MSG(n_canWalk,         MPlayer.canWalk);}
    public static void GetCanJump()         {Get_MSG(n_canJump,         MPlayer.canJump);}
    public static void GetCanFall()         {Get_MSG(n_canFall,         MPlayer.canFall);}
}
