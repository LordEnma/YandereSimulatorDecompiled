using System;
using UnityEngine;

// Token: 0x02000362 RID: 866
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x0600198A RID: 6538 RVA: 0x00104528 File Offset: 0x00102728
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

	// Token: 0x040028D8 RID: 10456
	[SerializeField]
	private GameObject[] Memes;
}
