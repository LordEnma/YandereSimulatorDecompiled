using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000287 RID: 647
public class DiscordVerificationScript : MonoBehaviour
{
	// Token: 0x060013A1 RID: 5025 RVA: 0x000B8822 File Offset: 0x000B6A22
	private void Update()
	{
		if (Input.GetKeyDown("q"))
		{
			SceneManager.LoadScene("MissionModeScene");
		}
	}
}
