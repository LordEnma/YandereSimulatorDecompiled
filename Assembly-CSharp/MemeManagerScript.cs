using System;
using UnityEngine;

// Token: 0x02000364 RID: 868
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x060019A5 RID: 6565 RVA: 0x0010645C File Offset: 0x0010465C
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

	// Token: 0x0400292F RID: 10543
	[SerializeField]
	private GameObject[] Memes;
}
