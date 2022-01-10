using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004F1 RID: 1265
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x060020DB RID: 8411 RVA: 0x001E37C3 File Offset: 0x001E19C3
	private void Start()
	{
	}

	// Token: 0x060020DC RID: 8412 RVA: 0x001E37C8 File Offset: 0x001E19C8
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
