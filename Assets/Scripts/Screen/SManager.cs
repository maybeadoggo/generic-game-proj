using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SManager : MonoBehaviour {
	const float timeDelay = 0.8f;
	static Animator crossfade;
	private void Start() {
		crossfade = transform.Find("Crossfade").gameObject.GetComponent<Animator>();
	}

	public static IEnumerator sceneChange(string scene) {
		crossfade.SetTrigger("Start");
		yield return new WaitForSeconds(timeDelay);
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
		GManager.ResumeGame(); MPlayer.setCanStats(true);
	}
}
