using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000284 RID: 644
public class DiscordVerificationScript : MonoBehaviour
{
	// Token: 0x06001389 RID: 5001 RVA: 0x000B6FEF File Offset: 0x000B51EF
	private void Update()
	{
		if (Input.GetKeyDown("q"))
		{
			SceneManager.LoadScene("MissionModeScene");
		}
	}
}
