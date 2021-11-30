using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000351 RID: 849
public class LoadingScript : MonoBehaviour
{
	// Token: 0x06001951 RID: 6481 RVA: 0x000FF8BA File Offset: 0x000FDABA
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
