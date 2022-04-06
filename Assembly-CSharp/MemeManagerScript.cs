using System;
using UnityEngine;

// Token: 0x02000366 RID: 870
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x060019B1 RID: 6577 RVA: 0x00106C08 File Offset: 0x00104E08
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

	// Token: 0x04002945 RID: 10565
	[SerializeField]
	private GameObject[] Memes;
}
