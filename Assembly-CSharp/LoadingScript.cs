using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000352 RID: 850
public class LoadingScript : MonoBehaviour
{
	// Token: 0x0600195A RID: 6490 RVA: 0x0010039A File Offset: 0x000FE59A
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
