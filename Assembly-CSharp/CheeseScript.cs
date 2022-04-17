using System;
using UnityEngine;

// Token: 0x02000242 RID: 578
public class CheeseScript : MonoBehaviour
{
	// Token: 0x06001249 RID: 4681 RVA: 0x0008CCC8 File Offset: 0x0008AEC8
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

	// Token: 0x0400171A RID: 5914
	public GameObject GlowingEye;

	// Token: 0x0400171B RID: 5915
	public PromptScript Prompt;

	// Token: 0x0400171C RID: 5916
	public UILabel Subtitle;

	// Token: 0x0400171D RID: 5917
	public float Timer;
}
