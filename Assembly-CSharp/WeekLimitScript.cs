using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004C9 RID: 1225
public class WeekLimitScript : MonoBehaviour
{
	// Token: 0x06002017 RID: 8215 RVA: 0x001C8F64 File Offset: 0x001C7164
	private void Update()
	{
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("HomeScene");
		}
	}
}
