using System;
using UnityEngine;

// Token: 0x0200024C RID: 588
public class CloakingDeviceScript : MonoBehaviour
{
	// Token: 0x06001268 RID: 4712 RVA: 0x0008ED78 File Offset: 0x0008CF78
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

	// Token: 0x04001775 RID: 6005
	public PromptScript Prompt;
}
