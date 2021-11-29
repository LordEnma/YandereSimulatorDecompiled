using System;
using UnityEngine;

// Token: 0x02000485 RID: 1157
public class TypewriterScript : MonoBehaviour
{
	// Token: 0x06001EE5 RID: 7909 RVA: 0x001B50B8 File Offset: 0x001B32B8
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

	// Token: 0x06001EE6 RID: 7910 RVA: 0x001B51F0 File Offset: 0x001B33F0
	private void CloseWindow()
	{
		this.Prompt.Yandere.RPGCamera.enabled = true;
		this.Prompt.Yandere.CanMove = true;
		this.Window.SetActive(false);
		Time.timeScale = 1f;
	}

	// Token: 0x06001EE7 RID: 7911 RVA: 0x001B522F File Offset: 0x001B342F
	private void Disable()
	{
		this.Prompt.enabled = false;
		base.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x040040D3 RID: 16595
	public PromptScript Prompt;

	// Token: 0x040040D4 RID: 16596
	public GameObject Window;
}
