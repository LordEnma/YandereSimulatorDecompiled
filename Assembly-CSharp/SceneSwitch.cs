using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004FF RID: 1279
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x0600212C RID: 8492 RVA: 0x001EA9C5 File Offset: 0x001E8BC5
	private void Start()
	{
	}

	// Token: 0x0600212D RID: 8493 RVA: 0x001EA9C8 File Offset: 0x001E8BC8
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
