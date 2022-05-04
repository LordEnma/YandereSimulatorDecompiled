using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004C8 RID: 1224
public class WeekLimitScript : MonoBehaviour
{
	// Token: 0x0600200E RID: 8206 RVA: 0x001C7D90 File Offset: 0x001C5F90
	private void Update()
	{
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("HomeScene");
		}
	}
}
