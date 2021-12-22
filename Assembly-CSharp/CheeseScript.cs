using System;
using UnityEngine;

// Token: 0x02000242 RID: 578
public class CheeseScript : MonoBehaviour
{
	// Token: 0x06001246 RID: 4678 RVA: 0x0008C2C8 File Offset: 0x0008A4C8
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

	// Token: 0x04001704 RID: 5892
	public GameObject GlowingEye;

	// Token: 0x04001705 RID: 5893
	public PromptScript Prompt;

	// Token: 0x04001706 RID: 5894
	public UILabel Subtitle;

	// Token: 0x04001707 RID: 5895
	public float Timer;
}
