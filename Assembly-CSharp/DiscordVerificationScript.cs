using UnityEngine;
using UnityEngine.SceneManagement;

public class DiscordVerificationScript : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown("q"))
		{
			SceneManager.LoadScene("MissionModeScene");
		}
	}
}
