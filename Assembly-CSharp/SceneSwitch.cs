using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000500 RID: 1280
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x0600213C RID: 8508 RVA: 0x001EC8AD File Offset: 0x001EAAAD
	private void Start()
	{
	}

	// Token: 0x0600213D RID: 8509 RVA: 0x001EC8B0 File Offset: 0x001EAAB0
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
