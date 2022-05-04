using System;
using UnityEngine;

// Token: 0x02000435 RID: 1077
public class SmokeBombBoxScript : MonoBehaviour
{
	// Token: 0x06001CEB RID: 7403 RVA: 0x00157EA0 File Offset: 0x001560A0
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

	// Token: 0x0400341D RID: 13341
	public AlphabetScript Alphabet;

	// Token: 0x0400341E RID: 13342
	public UITexture BombTexture;

	// Token: 0x0400341F RID: 13343
	public PromptScript Prompt;

	// Token: 0x04003420 RID: 13344
	public AudioSource MyAudio;

	// Token: 0x04003421 RID: 13345
	public bool Cheated;

	// Token: 0x04003422 RID: 13346
	public bool Amnesia;

	// Token: 0x04003423 RID: 13347
	public bool Stink;
}
