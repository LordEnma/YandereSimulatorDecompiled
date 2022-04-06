using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000357 RID: 855
public class LoadingScript : MonoBehaviour
{
	// Token: 0x06001985 RID: 6533 RVA: 0x00102D99 File Offset: 0x00100F99
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
