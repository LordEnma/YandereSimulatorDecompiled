using System;
using UnityEngine;

// Token: 0x02000366 RID: 870
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x060019B5 RID: 6581 RVA: 0x00106E9C File Offset: 0x0010509C
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

	// Token: 0x0400294D RID: 10573
	[SerializeField]
	private GameObject[] Memes;
}
