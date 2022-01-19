using System;
using UnityEngine;

// Token: 0x0200024C RID: 588
public class CloakingDeviceScript : MonoBehaviour
{
	// Token: 0x06001267 RID: 4711 RVA: 0x0008EBE0 File Offset: 0x0008CDE0
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

	// Token: 0x04001770 RID: 6000
	public PromptScript Prompt;
}
