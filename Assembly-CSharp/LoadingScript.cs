using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000355 RID: 853
public class LoadingScript : MonoBehaviour
{
	// Token: 0x06001979 RID: 6521 RVA: 0x001025ED File Offset: 0x001007ED
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
