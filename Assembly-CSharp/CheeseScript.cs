using System;
using UnityEngine;

// Token: 0x02000242 RID: 578
public class CheeseScript : MonoBehaviour
{
	// Token: 0x06001247 RID: 4679 RVA: 0x0008C748 File Offset: 0x0008A948
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

	// Token: 0x04001713 RID: 5907
	public GameObject GlowingEye;

	// Token: 0x04001714 RID: 5908
	public PromptScript Prompt;

	// Token: 0x04001715 RID: 5909
	public UILabel Subtitle;

	// Token: 0x04001716 RID: 5910
	public float Timer;
}
