using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000287 RID: 647
public class DiscordVerificationScript : MonoBehaviour
{
	// Token: 0x0600139E RID: 5022 RVA: 0x000B82DE File Offset: 0x000B64DE
	private void Update()
	{
		if (Input.GetKeyDown("q"))
		{
			SceneManager.LoadScene("MissionModeScene");
		}
	}
}
