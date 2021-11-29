using System;
using UnityEngine;

// Token: 0x02000360 RID: 864
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x0600197D RID: 6525 RVA: 0x001034E8 File Offset: 0x001016E8
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

	// Token: 0x040028A6 RID: 10406
	[SerializeField]
	private GameObject[] Memes;
}
