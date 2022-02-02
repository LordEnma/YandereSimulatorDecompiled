using System;
using UnityEngine;

// Token: 0x02000362 RID: 866
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x0600198B RID: 6539 RVA: 0x00104960 File Offset: 0x00102B60
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

	// Token: 0x040028DE RID: 10462
	[SerializeField]
	private GameObject[] Memes;
}
