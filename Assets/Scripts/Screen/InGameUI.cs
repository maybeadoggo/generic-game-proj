using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour {
    public static GameObject pauseMenu;
    void Start() {
        pauseMenu = transform.Find("PauseM").gameObject;
    }
}
