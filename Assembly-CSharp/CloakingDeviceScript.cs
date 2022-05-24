using System;
using UnityEngine;

// Token: 0x0200024D RID: 589
public class CloakingDeviceScript : MonoBehaviour
{
	// Token: 0x0600126C RID: 4716 RVA: 0x0008F9DC File Offset: 0x0008DBDC
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

	// Token: 0x0400178E RID: 6030
	public PromptScript Prompt;
}
