using System;
using UnityEngine;

// Token: 0x02000367 RID: 871
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x060019C0 RID: 6592 RVA: 0x00107DA8 File Offset: 0x00105FA8
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

	// Token: 0x0400296E RID: 10606
	[SerializeField]
	private GameObject[] Memes;
}
