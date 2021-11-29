using System;
using UnityEngine;

// Token: 0x0200024B RID: 587
public class CloakingDeviceScript : MonoBehaviour
{
	// Token: 0x06001262 RID: 4706 RVA: 0x0008E95C File Offset: 0x0008CB5C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Alphabet.Cheats++;
			this.Prompt.Yandere.Alphabet.UpdateDifficultyLabel();
			this.Prompt.Yandere.CanCloak = true;
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400176B RID: 5995
	public PromptScript Prompt;
}
