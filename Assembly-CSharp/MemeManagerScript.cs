using System;
using UnityEngine;

// Token: 0x02000364 RID: 868
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x0600199D RID: 6557 RVA: 0x0010577C File Offset: 0x0010397C
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

	// Token: 0x040028F7 RID: 10487
	[SerializeField]
	private GameObject[] Memes;
}
