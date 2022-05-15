using System;
using UnityEngine;

// Token: 0x02000436 RID: 1078
public class SmokeBombBoxScript : MonoBehaviour
{
	// Token: 0x06001CF1 RID: 7409 RVA: 0x00158B54 File Offset: 0x00156D54
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

	// Token: 0x04003432 RID: 13362
	public AlphabetScript Alphabet;

	// Token: 0x04003433 RID: 13363
	public UITexture BombTexture;

	// Token: 0x04003434 RID: 13364
	public PromptScript Prompt;

	// Token: 0x04003435 RID: 13365
	public AudioSource MyAudio;

	// Token: 0x04003436 RID: 13366
	public bool Cheated;

	// Token: 0x04003437 RID: 13367
	public bool Amnesia;

	// Token: 0x04003438 RID: 13368
	public bool Stink;
}
