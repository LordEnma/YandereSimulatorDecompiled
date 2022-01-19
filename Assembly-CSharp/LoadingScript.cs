using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000353 RID: 851
public class LoadingScript : MonoBehaviour
{
	// Token: 0x0600195E RID: 6494 RVA: 0x00100862 File Offset: 0x000FEA62
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
