using System;
using UnityEngine;

// Token: 0x02000241 RID: 577
public class CheeseScript : MonoBehaviour
{
	// Token: 0x06001243 RID: 4675 RVA: 0x0008C1A4 File Offset: 0x0008A3A4
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Subtitle.text = "Knowing the mouse might one day leave its hole and get the cheese...It fills you with determination.";
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.GlowingEye.SetActive(true);
			this.Timer = 5f;
		}
		if (this.Timer > 0f)
		{
			this.Timer -= Time.deltaTime;
			if (this.Timer <= 0f)
			{
				this.Prompt.enabled = true;
				this.Subtitle.text = string.Empty;
			}
		}
	}

	// Token: 0x04001702 RID: 5890
	public GameObject GlowingEye;

	// Token: 0x04001703 RID: 5891
	public PromptScript Prompt;

	// Token: 0x04001704 RID: 5892
	public UILabel Subtitle;

	// Token: 0x04001705 RID: 5893
	public float Timer;
}
