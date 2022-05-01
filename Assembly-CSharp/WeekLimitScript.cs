using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004C8 RID: 1224
public class WeekLimitScript : MonoBehaviour
{
	// Token: 0x0600200D RID: 8205 RVA: 0x001C7C94 File Offset: 0x001C5E94
	private void Update()
	{
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("HomeScene");
		}
	}
}
