using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004F4 RID: 1268
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x060020F6 RID: 8438 RVA: 0x001E62E3 File Offset: 0x001E44E3
	private void Start()
	{
	}

	// Token: 0x060020F7 RID: 8439 RVA: 0x001E62E8 File Offset: 0x001E44E8
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
