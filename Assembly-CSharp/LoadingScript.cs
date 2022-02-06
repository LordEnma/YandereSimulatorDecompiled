using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000353 RID: 851
public class LoadingScript : MonoBehaviour
{
	// Token: 0x06001961 RID: 6497 RVA: 0x00100E62 File Offset: 0x000FF062
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
