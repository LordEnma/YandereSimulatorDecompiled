using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000357 RID: 855
public class LoadingScript : MonoBehaviour
{
	// Token: 0x06001989 RID: 6537 RVA: 0x0010302D File Offset: 0x0010122D
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
