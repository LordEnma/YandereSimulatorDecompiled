using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004EF RID: 1263
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x060020CD RID: 8397 RVA: 0x001E2833 File Offset: 0x001E0A33
	private void Start()
	{
	}

	// Token: 0x060020CE RID: 8398 RVA: 0x001E2838 File Offset: 0x001E0A38
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
