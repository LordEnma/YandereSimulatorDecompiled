using System;
using UnityEngine;

// Token: 0x0200042D RID: 1069
public class SmokeBombBoxScript : MonoBehaviour
{
	// Token: 0x06001CAD RID: 7341 RVA: 0x00153AF8 File Offset: 0x00151CF8
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

	// Token: 0x04003379 RID: 13177
	public AlphabetScript Alphabet;

	// Token: 0x0400337A RID: 13178
	public UITexture BombTexture;

	// Token: 0x0400337B RID: 13179
	public PromptScript Prompt;

	// Token: 0x0400337C RID: 13180
	public AudioSource MyAudio;

	// Token: 0x0400337D RID: 13181
	public bool Cheated;

	// Token: 0x0400337E RID: 13182
	public bool Amnesia;

	// Token: 0x0400337F RID: 13183
	public bool Stink;
}
