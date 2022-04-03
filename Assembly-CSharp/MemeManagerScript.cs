using System;
using UnityEngine;

// Token: 0x02000365 RID: 869
public class MemeManagerScript : MonoBehaviour
{
	// Token: 0x060019AB RID: 6571 RVA: 0x00106B08 File Offset: 0x00104D08
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

	// Token: 0x04002942 RID: 10562
	[SerializeField]
	private GameObject[] Memes;
}
