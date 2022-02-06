using System;
using UnityEngine;

// Token: 0x02000362 RID: 866
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x0600198D RID: 6541 RVA: 0x00104B28 File Offset: 0x00102D28
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

	// Token: 0x040028E2 RID: 10466
	[SerializeField]
	private GameObject[] Memes;
}
