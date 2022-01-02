using System;
using UnityEngine;

// Token: 0x02000361 RID: 865
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x06001986 RID: 6534 RVA: 0x00104020 File Offset: 0x00102220
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

	// Token: 0x040028CF RID: 10447
	[SerializeField]
	private GameObject[] Memes;
}
