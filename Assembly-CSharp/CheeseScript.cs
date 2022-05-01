using System;
using UnityEngine;

// Token: 0x02000242 RID: 578
public class CheeseScript : MonoBehaviour
{
	// Token: 0x06001249 RID: 4681 RVA: 0x0008CE1C File Offset: 0x0008B01C
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

	// Token: 0x0400171D RID: 5917
	public GameObject GlowingEye;

	// Token: 0x0400171E RID: 5918
	public PromptScript Prompt;

	// Token: 0x0400171F RID: 5919
	public UILabel Subtitle;

	// Token: 0x04001720 RID: 5920
	public float Timer;
}
