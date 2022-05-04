using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000288 RID: 648
public class DiscordVerificationScript : MonoBehaviour
{
	// Token: 0x060013AC RID: 5036 RVA: 0x000B901E File Offset: 0x000B721E
	private void Update()
	{
		if (Input.GetKeyDown("q"))
		{
			SceneManager.LoadScene("MissionModeScene");
		}
	}
}
