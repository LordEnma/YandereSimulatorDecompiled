﻿using System;
using UnityEngine;

// Token: 0x0200039E RID: 926
public class PhoneJammerScript : MonoBehaviour
{
	// Token: 0x06001A6E RID: 6766 RVA: 0x0011B9A8 File Offset: 0x00119BA8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Alphabet.Cheats++;
			this.Prompt.Yandere.Alphabet.UpdateDifficultyLabel();
			this.Prompt.Yandere.StudentManager.Jammed = true;
			this.JammingLines.SetActive(true);
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			base.enabled = false;
		}
	}

	// Token: 0x04002BB9 RID: 11193
	public GameObject JammingLines;

	// Token: 0x04002BBA RID: 11194
	public PromptScript Prompt;
}
