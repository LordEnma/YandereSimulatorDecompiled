using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000501 RID: 1281
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x06002147 RID: 8519 RVA: 0x001EDFF9 File Offset: 0x001EC1F9
	private void Start()
	{
	}

	// Token: 0x06002148 RID: 8520 RVA: 0x001EDFFC File Offset: 0x001EC1FC
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
