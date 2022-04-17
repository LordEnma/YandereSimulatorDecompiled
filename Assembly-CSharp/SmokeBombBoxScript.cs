using System;
using UnityEngine;

// Token: 0x02000434 RID: 1076
public class SmokeBombBoxScript : MonoBehaviour
{
	// Token: 0x06001CE4 RID: 7396 RVA: 0x00157698 File Offset: 0x00155898
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

	// Token: 0x0400340E RID: 13326
	public AlphabetScript Alphabet;

	// Token: 0x0400340F RID: 13327
	public UITexture BombTexture;

	// Token: 0x04003410 RID: 13328
	public PromptScript Prompt;

	// Token: 0x04003411 RID: 13329
	public AudioSource MyAudio;

	// Token: 0x04003412 RID: 13330
	public bool Cheated;

	// Token: 0x04003413 RID: 13331
	public bool Amnesia;

	// Token: 0x04003414 RID: 13332
	public bool Stink;
}
