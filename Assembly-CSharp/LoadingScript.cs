using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000356 RID: 854
public class LoadingScript : MonoBehaviour
{
	// Token: 0x0600197F RID: 6527 RVA: 0x00102C99 File Offset: 0x00100E99
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
