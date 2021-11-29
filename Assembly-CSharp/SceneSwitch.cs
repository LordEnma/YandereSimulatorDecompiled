using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004ED RID: 1261
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x060020BC RID: 8380 RVA: 0x001E10FF File Offset: 0x001DF2FF
	private void Start()
	{
	}

	// Token: 0x060020BD RID: 8381 RVA: 0x001E1104 File Offset: 0x001DF304
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
