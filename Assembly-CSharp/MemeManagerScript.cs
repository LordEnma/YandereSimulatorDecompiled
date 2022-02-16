using System;
using UnityEngine;

// Token: 0x02000363 RID: 867
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x06001994 RID: 6548 RVA: 0x00104E4C File Offset: 0x0010304C
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

	// Token: 0x040028E8 RID: 10472
	[SerializeField]
	private GameObject[] Memes;
}
