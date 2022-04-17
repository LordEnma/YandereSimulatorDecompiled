using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004C7 RID: 1223
public class WeekLimitScript : MonoBehaviour
{
	// Token: 0x06002004 RID: 8196 RVA: 0x001C68D8 File Offset: 0x001C4AD8
	private void Update()
	{
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("HomeScene");
		}
	}
}
