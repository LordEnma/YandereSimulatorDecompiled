using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000358 RID: 856
public class LoadingScript : MonoBehaviour
{
	// Token: 0x06001993 RID: 6547 RVA: 0x00103D35 File Offset: 0x00101F35
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
