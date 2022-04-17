using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004FF RID: 1279
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x06002133 RID: 8499 RVA: 0x001EB421 File Offset: 0x001E9621
	private void Start()
	{
	}

	// Token: 0x06002134 RID: 8500 RVA: 0x001EB424 File Offset: 0x001E9624
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
