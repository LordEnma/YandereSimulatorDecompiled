using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004F2 RID: 1266
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x060020E3 RID: 8419 RVA: 0x001E504B File Offset: 0x001E324B
	private void Start()
	{
	}

	// Token: 0x060020E4 RID: 8420 RVA: 0x001E5050 File Offset: 0x001E3250
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
