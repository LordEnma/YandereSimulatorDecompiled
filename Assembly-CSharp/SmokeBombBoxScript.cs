using System;
using UnityEngine;

// Token: 0x02000436 RID: 1078
public class SmokeBombBoxScript : MonoBehaviour
{
	// Token: 0x06001CF2 RID: 7410 RVA: 0x00158E10 File Offset: 0x00157010
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

	// Token: 0x0400343A RID: 13370
	public AlphabetScript Alphabet;

	// Token: 0x0400343B RID: 13371
	public UITexture BombTexture;

	// Token: 0x0400343C RID: 13372
	public PromptScript Prompt;

	// Token: 0x0400343D RID: 13373
	public AudioSource MyAudio;

	// Token: 0x0400343E RID: 13374
	public bool Cheated;

	// Token: 0x0400343F RID: 13375
	public bool Amnesia;

	// Token: 0x04003440 RID: 13376
	public bool Stink;
}
