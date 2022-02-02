using System;
using UnityEngine;

// Token: 0x02000489 RID: 1161
public class TypewriterScript : MonoBehaviour
{
	// Token: 0x06001F01 RID: 7937 RVA: 0x001B7EC4 File Offset: 0x001B60C4
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

	// Token: 0x06001F02 RID: 7938 RVA: 0x001B7FFC File Offset: 0x001B61FC
	private void CloseWindow()
	{
		this.Prompt.Yandere.RPGCamera.enabled = true;
		this.Prompt.Yandere.CanMove = true;
		this.Window.SetActive(false);
		Time.timeScale = 1f;
	}

	// Token: 0x06001F03 RID: 7939 RVA: 0x001B803B File Offset: 0x001B623B
	private void Disable()
	{
		this.Prompt.enabled = false;
		base.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x0400412D RID: 16685
	public PromptScript Prompt;

	// Token: 0x0400412E RID: 16686
	public GameObject Window;
}
