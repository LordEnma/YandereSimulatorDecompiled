using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004F9 RID: 1273
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x06002114 RID: 8468 RVA: 0x001E8C23 File Offset: 0x001E6E23
	private void Start()
	{
	}

	// Token: 0x06002115 RID: 8469 RVA: 0x001E8C28 File Offset: 0x001E6E28
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
