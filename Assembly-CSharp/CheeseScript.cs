using System;
using UnityEngine;

// Token: 0x02000243 RID: 579
public class CheeseScript : MonoBehaviour
{
	// Token: 0x0600124B RID: 4683 RVA: 0x0008D148 File Offset: 0x0008B348
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

	// Token: 0x04001723 RID: 5923
	public GameObject GlowingEye;

	// Token: 0x04001724 RID: 5924
	public PromptScript Prompt;

	// Token: 0x04001725 RID: 5925
	public UILabel Subtitle;

	// Token: 0x04001726 RID: 5926
	public float Timer;
}
