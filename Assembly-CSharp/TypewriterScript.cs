using System;
using UnityEngine;

// Token: 0x02000486 RID: 1158
public class TypewriterScript : MonoBehaviour
{
	// Token: 0x06001EEF RID: 7919 RVA: 0x001B5E74 File Offset: 0x001B4074
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Prompt.Yandere.RPGCamera.enabled = false;
			this.Prompt.Yandere.CanMove = false;
			Time.timeScale = 0.0001f;
			this.Window.SetActive(true);
		}
		if (this.Window.activeInHierarchy)
		{
			if (Input.GetButtonDown("A"))
			{
				this.Prompt.Yandere.Police.EndOfDay.ArticleID = 1;
				this.CloseWindow();
				this.Disable();
				return;
			}
			if (Input.GetButtonDown("X"))
			{
				this.Prompt.Yandere.Police.EndOfDay.ArticleID = 2;
				this.CloseWindow();
				this.Disable();
				return;
			}
			if (Input.GetButtonDown("Y"))
			{
				this.Prompt.Yandere.Police.EndOfDay.ArticleID = 3;
				this.CloseWindow();
				this.Disable();
				return;
			}
			if (Input.GetButtonDown("B"))
			{
				this.CloseWindow();
			}
		}
	}

	// Token: 0x06001EF0 RID: 7920 RVA: 0x001B5FAC File Offset: 0x001B41AC
	private void CloseWindow()
	{
		this.Prompt.Yandere.RPGCamera.enabled = true;
		this.Prompt.Yandere.CanMove = true;
		this.Window.SetActive(false);
		Time.timeScale = 1f;
	}

	// Token: 0x06001EF1 RID: 7921 RVA: 0x001B5FEB File Offset: 0x001B41EB
	private void Disable()
	{
		this.Prompt.enabled = false;
		base.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x04004103 RID: 16643
	public PromptScript Prompt;

	// Token: 0x04004104 RID: 16644
	public GameObject Window;
}
