using System;
using UnityEngine;

// Token: 0x02000429 RID: 1065
public class SmokeBombBoxScript : MonoBehaviour
{
	// Token: 0x06001C9A RID: 7322 RVA: 0x001513B0 File Offset: 0x0014F5B0
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

	// Token: 0x0400333C RID: 13116
	public AlphabetScript Alphabet;

	// Token: 0x0400333D RID: 13117
	public UITexture BombTexture;

	// Token: 0x0400333E RID: 13118
	public PromptScript Prompt;

	// Token: 0x0400333F RID: 13119
	public AudioSource MyAudio;

	// Token: 0x04003340 RID: 13120
	public bool Cheated;

	// Token: 0x04003341 RID: 13121
	public bool Amnesia;

	// Token: 0x04003342 RID: 13122
	public bool Stink;
}
