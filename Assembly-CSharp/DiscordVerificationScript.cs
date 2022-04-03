using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000287 RID: 647
public class DiscordVerificationScript : MonoBehaviour
{
	// Token: 0x060013A2 RID: 5026 RVA: 0x000B892E File Offset: 0x000B6B2E
	private void Update()
	{
		if (Input.GetKeyDown("q"))
		{
			SceneManager.LoadScene("MissionModeScene");
		}
	}
}
