using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004FE RID: 1278
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x06002124 RID: 8484 RVA: 0x001EA495 File Offset: 0x001E8695
	private void Start()
	{
	}

	// Token: 0x06002125 RID: 8485 RVA: 0x001EA498 File Offset: 0x001E8698
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
