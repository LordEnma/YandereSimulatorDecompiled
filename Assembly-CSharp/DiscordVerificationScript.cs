using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000285 RID: 645
public class DiscordVerificationScript : MonoBehaviour
{
	// Token: 0x06001391 RID: 5009 RVA: 0x000B7993 File Offset: 0x000B5B93
	private void Update()
	{
		if (Input.GetKeyDown("q"))
		{
			SceneManager.LoadScene("MissionModeScene");
		}
	}
}
