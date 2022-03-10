using System;
using UnityEngine;

// Token: 0x02000364 RID: 868
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x0600199D RID: 6557 RVA: 0x00105AE4 File Offset: 0x00103CE4
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

	// Token: 0x0400290D RID: 10509
	[SerializeField]
	private GameObject[] Memes;
}
