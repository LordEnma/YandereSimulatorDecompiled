using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004F2 RID: 1266
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x060020E1 RID: 8417 RVA: 0x001E4D33 File Offset: 0x001E2F33
	private void Start()
	{
	}

	// Token: 0x060020E2 RID: 8418 RVA: 0x001E4D38 File Offset: 0x001E2F38
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
