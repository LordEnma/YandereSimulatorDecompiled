using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004C6 RID: 1222
public class WeekLimitScript : MonoBehaviour
{
	// Token: 0x06001FF6 RID: 8182 RVA: 0x001C59DC File Offset: 0x001C3BDC
	private void Update()
	{
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("HomeScene");
		}
	}
}
