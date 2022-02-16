using System;
using UnityEngine;

// Token: 0x0200042E RID: 1070
public class SmokeBombBoxScript : MonoBehaviour
{
	// Token: 0x06001CB7 RID: 7351 RVA: 0x001544D0 File Offset: 0x001526D0
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

	// Token: 0x04003389 RID: 13193
	public AlphabetScript Alphabet;

	// Token: 0x0400338A RID: 13194
	public UITexture BombTexture;

	// Token: 0x0400338B RID: 13195
	public PromptScript Prompt;

	// Token: 0x0400338C RID: 13196
	public AudioSource MyAudio;

	// Token: 0x0400338D RID: 13197
	public bool Cheated;

	// Token: 0x0400338E RID: 13198
	public bool Amnesia;

	// Token: 0x0400338F RID: 13199
	public bool Stink;
}
