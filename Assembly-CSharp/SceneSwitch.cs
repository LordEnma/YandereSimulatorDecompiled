using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004F3 RID: 1267
public class SceneSwitch : MonoBehaviour
{
	// Token: 0x060020ED RID: 8429 RVA: 0x001E5703 File Offset: 0x001E3903
	private void Start()
	{
	}

	// Token: 0x060020EE RID: 8430 RVA: 0x001E5708 File Offset: 0x001E3908
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
