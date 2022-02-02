using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000353 RID: 851
public class LoadingScript : MonoBehaviour
{
	// Token: 0x0600195F RID: 6495 RVA: 0x00100C9A File Offset: 0x000FEE9A
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
