using System;
using UnityEngine;

// Token: 0x0200048B RID: 1163
public class TypewriterScript : MonoBehaviour
{
	// Token: 0x06001F19 RID: 7961 RVA: 0x001B9B30 File Offset: 0x001B7D30
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

	// Token: 0x06001F1A RID: 7962 RVA: 0x001B9C68 File Offset: 0x001B7E68
	private void CloseWindow()
	{
		this.Prompt.Yandere.RPGCamera.enabled = true;
		this.Prompt.Yandere.CanMove = true;
		this.Window.SetActive(false);
		Time.timeScale = 1f;
	}

	// Token: 0x06001F1B RID: 7963 RVA: 0x001B9CA7 File Offset: 0x001B7EA7
	private void Disable()
	{
		this.Prompt.enabled = false;
		base.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x04004166 RID: 16742
	public PromptScript Prompt;

	// Token: 0x04004167 RID: 16743
	public GameObject Window;
}
