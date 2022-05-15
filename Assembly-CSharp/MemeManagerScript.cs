using System;
using UnityEngine;

// Token: 0x02000367 RID: 871
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x060019BF RID: 6591 RVA: 0x00107BA4 File Offset: 0x00105DA4
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

	// Token: 0x04002967 RID: 10599
	[SerializeField]
	private GameObject[] Memes;
}
