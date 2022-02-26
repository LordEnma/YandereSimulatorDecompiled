using System;
using UnityEngine;

// Token: 0x0200042F RID: 1071
public class SmokeBombBoxScript : MonoBehaviour
{
	// Token: 0x06001CC0 RID: 7360 RVA: 0x00154F7C File Offset: 0x0015317C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (!this.Cheated)
			{
				this.Alphabet.Cheats++;
				this.Alphabet.UpdateDifficultyLabel();
				this.Cheated = true;
			}
			if (!this.Amnesia)
			{
				this.Alphabet.RemainingBombs = 5;
				this.Alphabet.BombLabel.text = (5.ToString() ?? "");
			}
			else
			{
				this.Alphabet.RemainingBombs = 1;
				this.Alphabet.BombLabel.text = (1.ToString() ?? "");
			}
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Stink)
			{
				this.BombTexture.color = new Color(0f, 0.5f, 0f, 1f);
				this.Prompt.Yandere.Inventory.AmnesiaBomb = false;
				this.Prompt.Yandere.Inventory.SmokeBomb = false;
				this.Prompt.Yandere.Inventory.StinkBomb = true;
			}
			else if (this.Amnesia)
			{
				this.BombTexture.color = new Color(1f, 0.5f, 1f, 1f);
				this.Prompt.Yandere.Inventory.AmnesiaBomb = true;
				this.Prompt.Yandere.Inventory.SmokeBomb = false;
				this.Prompt.Yandere.Inventory.StinkBomb = false;
			}
			else
			{
				this.BombTexture.color = new Color(0.5f, 0.5f, 0.5f, 1f);
				this.Prompt.Yandere.Inventory.AmnesiaBomb = false;
				this.Prompt.Yandere.Inventory.StinkBomb = false;
				this.Prompt.Yandere.Inventory.SmokeBomb = true;
			}
			this.MyAudio.Play();
		}
	}

	// Token: 0x04003399 RID: 13209
	public AlphabetScript Alphabet;

	// Token: 0x0400339A RID: 13210
	public UITexture BombTexture;

	// Token: 0x0400339B RID: 13211
	public PromptScript Prompt;

	// Token: 0x0400339C RID: 13212
	public AudioSource MyAudio;

	// Token: 0x0400339D RID: 13213
	public bool Cheated;

	// Token: 0x0400339E RID: 13214
	public bool Amnesia;

	// Token: 0x0400339F RID: 13215
	public bool Stink;
}
