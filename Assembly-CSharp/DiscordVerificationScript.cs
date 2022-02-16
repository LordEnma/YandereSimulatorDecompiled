using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000286 RID: 646
public class DiscordVerificationScript : MonoBehaviour
{
	// Token: 0x06001395 RID: 5013 RVA: 0x000B799F File Offset: 0x000B5B9F
	private void Update()
	{
		if (Input.GetKeyDown("q"))
		{
			SceneManager.LoadScene("MissionModeScene");
		}
	}
}
