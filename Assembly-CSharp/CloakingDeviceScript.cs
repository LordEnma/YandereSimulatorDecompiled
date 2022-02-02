using System;
using UnityEngine;

// Token: 0x0200024C RID: 588
public class CloakingDeviceScript : MonoBehaviour
{
	// Token: 0x06001267 RID: 4711 RVA: 0x0008EC14 File Offset: 0x0008CE14
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

	// Token: 0x04001771 RID: 6001
	public PromptScript Prompt;
}
