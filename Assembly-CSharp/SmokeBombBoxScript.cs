using System;
using UnityEngine;

// Token: 0x0200042C RID: 1068
public class SmokeBombBoxScript : MonoBehaviour
{
	// Token: 0x06001CAB RID: 7339 RVA: 0x001523E4 File Offset: 0x001505E4
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

	// Token: 0x04003374 RID: 13172
	public AlphabetScript Alphabet;

	// Token: 0x04003375 RID: 13173
	public UITexture BombTexture;

	// Token: 0x04003376 RID: 13174
	public PromptScript Prompt;

	// Token: 0x04003377 RID: 13175
	public AudioSource MyAudio;

	// Token: 0x04003378 RID: 13176
	public bool Cheated;

	// Token: 0x04003379 RID: 13177
	public bool Amnesia;

	// Token: 0x0400337A RID: 13178
	public bool Stink;
}
