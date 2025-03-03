using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadIntoCourtroomSceneScript : MonoBehaviour
{
	private void Start()
	{
		GameGlobals.Eighties = false;
		SceneManager.LoadScene("SwordScene");
	}
}
