using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004F2 RID: 1266
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x060020DD RID: 8413 RVA: 0x001E4493 File Offset: 0x001E2693
	private void Start()
	{
	}

	// Token: 0x060020DE RID: 8414 RVA: 0x001E4498 File Offset: 0x001E2698
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
