using System;
using UnityEngine;

// Token: 0x02000361 RID: 865
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x06001984 RID: 6532 RVA: 0x00103D44 File Offset: 0x00101F44
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

	// Token: 0x040028CB RID: 10443
	[SerializeField]
	private GameObject[] Memes;
}
