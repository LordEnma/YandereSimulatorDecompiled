using System;
using UnityEngine;

// Token: 0x02000430 RID: 1072
public class SmokeBombBoxScript : MonoBehaviour
{
	// Token: 0x06001CCF RID: 7375 RVA: 0x0015640C File Offset: 0x0015460C
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

	// Token: 0x040033E4 RID: 13284
	public AlphabetScript Alphabet;

	// Token: 0x040033E5 RID: 13285
	public UITexture BombTexture;

	// Token: 0x040033E6 RID: 13286
	public PromptScript Prompt;

	// Token: 0x040033E7 RID: 13287
	public AudioSource MyAudio;

	// Token: 0x040033E8 RID: 13288
	public bool Cheated;

	// Token: 0x040033E9 RID: 13289
	public bool Amnesia;

	// Token: 0x040033EA RID: 13290
	public bool Stink;
}
