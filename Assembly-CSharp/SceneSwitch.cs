using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004F2 RID: 1266
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x060020E6 RID: 8422 RVA: 0x001E524F File Offset: 0x001E344F
	private void Start()
	{
	}

	// Token: 0x060020E7 RID: 8423 RVA: 0x001E5254 File Offset: 0x001E3454
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
