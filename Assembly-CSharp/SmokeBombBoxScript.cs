using System;
using UnityEngine;

// Token: 0x0200042F RID: 1071
public class SmokeBombBoxScript : MonoBehaviour
{
	// Token: 0x06001CC2 RID: 7362 RVA: 0x00155500 File Offset: 0x00153700
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

	// Token: 0x040033AF RID: 13231
	public AlphabetScript Alphabet;

	// Token: 0x040033B0 RID: 13232
	public UITexture BombTexture;

	// Token: 0x040033B1 RID: 13233
	public PromptScript Prompt;

	// Token: 0x040033B2 RID: 13234
	public AudioSource MyAudio;

	// Token: 0x040033B3 RID: 13235
	public bool Cheated;

	// Token: 0x040033B4 RID: 13236
	public bool Amnesia;

	// Token: 0x040033B5 RID: 13237
	public bool Stink;
}
