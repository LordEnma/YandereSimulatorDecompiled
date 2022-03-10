using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004F5 RID: 1269
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x060020FC RID: 8444 RVA: 0x001E6CBB File Offset: 0x001E4EBB
	private void Start()
	{
	}

	// Token: 0x060020FD RID: 8445 RVA: 0x001E6CC0 File Offset: 0x001E4EC0
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
