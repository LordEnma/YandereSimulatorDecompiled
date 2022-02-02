using System;
using UnityEngine;

// Token: 0x0200042D RID: 1069
public class SmokeBombBoxScript : MonoBehaviour
{
	// Token: 0x06001CAE RID: 7342 RVA: 0x00153F2C File Offset: 0x0015212C
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

	// Token: 0x0400337F RID: 13183
	public AlphabetScript Alphabet;

	// Token: 0x04003380 RID: 13184
	public UITexture BombTexture;

	// Token: 0x04003381 RID: 13185
	public PromptScript Prompt;

	// Token: 0x04003382 RID: 13186
	public AudioSource MyAudio;

	// Token: 0x04003383 RID: 13187
	public bool Cheated;

	// Token: 0x04003384 RID: 13188
	public bool Amnesia;

	// Token: 0x04003385 RID: 13189
	public bool Stink;
}
