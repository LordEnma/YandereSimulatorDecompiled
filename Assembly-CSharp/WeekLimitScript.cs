using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004C7 RID: 1223
public class WeekLimitScript : MonoBehaviour
{
	// Token: 0x06001FFE RID: 8190 RVA: 0x001C5EFC File Offset: 0x001C40FC
	private void Update()
	{
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("HomeScene");
		}
	}
}
