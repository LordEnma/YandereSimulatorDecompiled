using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004EF RID: 1263
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x060020D0 RID: 8400 RVA: 0x001E2E23 File Offset: 0x001E1023
	private void Start()
	{
	}

	// Token: 0x060020D1 RID: 8401 RVA: 0x001E2E28 File Offset: 0x001E1028
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			SceneManager.LoadScene("Structure_01");
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			SceneManager.LoadScene("Structure_02");
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			SceneManager.LoadScene("Structure_03");
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			SceneManager.LoadScene("Props Furniture Showcase");
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
