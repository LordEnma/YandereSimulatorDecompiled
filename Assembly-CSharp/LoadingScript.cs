using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000352 RID: 850
public class LoadingScript : MonoBehaviour
{
	// Token: 0x06001958 RID: 6488 RVA: 0x001000DA File Offset: 0x000FE2DA
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
