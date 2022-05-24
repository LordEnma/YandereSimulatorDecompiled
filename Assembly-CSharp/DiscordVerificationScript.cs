using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000289 RID: 649
public class DiscordVerificationScript : MonoBehaviour
{
	// Token: 0x060013AE RID: 5038 RVA: 0x000B932A File Offset: 0x000B752A
	private void Update()
	{
		if (Input.GetKeyDown("q"))
		{
			SceneManager.LoadScene("MissionModeScene");
		}
	}
}
