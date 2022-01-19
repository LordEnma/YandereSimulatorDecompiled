using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000285 RID: 645
public class DiscordVerificationScript : MonoBehaviour
{
	// Token: 0x06001390 RID: 5008 RVA: 0x000B783B File Offset: 0x000B5A3B
	private void Update()
	{
		if (Input.GetKeyDown("q"))
		{
			SceneManager.LoadScene("MissionModeScene");
		}
	}
}
