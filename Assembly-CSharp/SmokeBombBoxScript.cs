using System;
using UnityEngine;

// Token: 0x0200042A RID: 1066
public class SmokeBombBoxScript : MonoBehaviour
{
	// Token: 0x06001CA4 RID: 7332 RVA: 0x001520E0 File Offset: 0x001502E0
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

	// Token: 0x0400336E RID: 13166
	public AlphabetScript Alphabet;

	// Token: 0x0400336F RID: 13167
	public UITexture BombTexture;

	// Token: 0x04003370 RID: 13168
	public PromptScript Prompt;

	// Token: 0x04003371 RID: 13169
	public AudioSource MyAudio;

	// Token: 0x04003372 RID: 13170
	public bool Cheated;

	// Token: 0x04003373 RID: 13171
	public bool Amnesia;

	// Token: 0x04003374 RID: 13172
	public bool Stink;
}
