using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000354 RID: 852
public class LoadingScript : MonoBehaviour
{
	// Token: 0x06001968 RID: 6504 RVA: 0x00101006 File Offset: 0x000FF206
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
