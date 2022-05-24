using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004C9 RID: 1225
public class WeekLimitScript : MonoBehaviour
{
	// Token: 0x06002018 RID: 8216 RVA: 0x001C9478 File Offset: 0x001C7678
	private void Update()
	{
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("HomeScene");
		}
	}
}
