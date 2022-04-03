using System;
using UnityEngine;

// Token: 0x02000491 RID: 1169
public class TypewriterScript : MonoBehaviour
{
	// Token: 0x06001F35 RID: 7989 RVA: 0x001BC83C File Offset: 0x001BAA3C
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

	// Token: 0x06001F36 RID: 7990 RVA: 0x001BC974 File Offset: 0x001BAB74
	private void CloseWindow()
	{
		this.Prompt.Yandere.RPGCamera.enabled = true;
		this.Prompt.Yandere.CanMove = true;
		this.Window.SetActive(false);
		Time.timeScale = 1f;
	}

	// Token: 0x06001F37 RID: 7991 RVA: 0x001BC9B3 File Offset: 0x001BABB3
	private void Disable()
	{
		this.Prompt.enabled = false;
		base.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x040041DE RID: 16862
	public PromptScript Prompt;

	// Token: 0x040041DF RID: 16863
	public GameObject Window;
}
