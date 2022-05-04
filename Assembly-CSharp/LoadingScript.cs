using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000357 RID: 855
public class LoadingScript : MonoBehaviour
{
	// Token: 0x0600198D RID: 6541 RVA: 0x001034F9 File Offset: 0x001016F9
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
