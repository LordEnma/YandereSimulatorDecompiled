using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000357 RID: 855
public class LoadingScript : MonoBehaviour
{
	// Token: 0x0600198D RID: 6541 RVA: 0x0010352D File Offset: 0x0010172D
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
