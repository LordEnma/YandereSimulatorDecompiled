using System;
using UnityEngine;

// Token: 0x02000433 RID: 1075
public class SmokeBombBoxScript : MonoBehaviour
{
	// Token: 0x06001CD9 RID: 7385 RVA: 0x00156F68 File Offset: 0x00155168
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

	// Token: 0x04003400 RID: 13312
	public AlphabetScript Alphabet;

	// Token: 0x04003401 RID: 13313
	public UITexture BombTexture;

	// Token: 0x04003402 RID: 13314
	public PromptScript Prompt;

	// Token: 0x04003403 RID: 13315
	public AudioSource MyAudio;

	// Token: 0x04003404 RID: 13316
	public bool Cheated;

	// Token: 0x04003405 RID: 13317
	public bool Amnesia;

	// Token: 0x04003406 RID: 13318
	public bool Stink;
}
