using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000358 RID: 856
public class LoadingScript : MonoBehaviour
{
	// Token: 0x06001994 RID: 6548 RVA: 0x00103F39 File Offset: 0x00102139
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
