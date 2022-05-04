using System;
using UnityEngine;

// Token: 0x02000366 RID: 870
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x060019B9 RID: 6585 RVA: 0x00107368 File Offset: 0x00105568
	private void Start()
	{
		if (GameGlobals.LoveSick)
		{
			GameObject[] memes = this.Memes;
			for (int i = 0; i < memes.Length; i++)
			{
				memes[i].SetActive(false);
			}
		}
	}

	// Token: 0x04002956 RID: 10582
	[SerializeField]
	private GameObject[] Memes;
}
