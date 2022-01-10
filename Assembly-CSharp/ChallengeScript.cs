using System;
using UnityEngine;

// Token: 0x02000107 RID: 263
public class ChallengeScript : MonoBehaviour
{
	// Token: 0x06000AAD RID: 2733 RVA: 0x00063514 File Offset: 0x00061714
	private void Update()
	{
		if (!this.Viewing)
		{
			if (!this.Switch)
			{
				if (this.InputManager.TappedUp || this.InputManager.TappedDown)
				{
					if (this.List == 0)
					{
						this.Arrows.localPosition = new Vector3(this.Arrows.localPosition.x, -300f, this.Arrows.localPosition.z);
						this.ViewButton.SetActive(true);
						this.Panels[0].alpha = 0.5f;
						this.Panels[1].alpha = 1f;
						this.List = 1;
					}
					else
					{
						this.Arrows.localPosition = new Vector3(this.Arrows.localPosition.x, 200f, this.Arrows.localPosition.z);
						this.ViewButton.SetActive(false);
						this.Panels[0].alpha = 1f;
						this.Panels[1].alpha = 0.5f;
						this.List = 0;
					}
				}
				Transform transform = this.ChallengeList[this.List];
				if (this.InputManager.DPadRight || Input.GetKey(KeyCode.RightArrow))
				{
					transform.localPosition = new Vector3(transform.localPosition.x - Time.deltaTime * 1000f, transform.localPosition.y, transform.localPosition.z);
				}
				if (this.InputManager.DPadLeft || Input.GetKey(KeyCode.LeftArrow))
				{
					transform.localPosition = new Vector3(transform.localPosition.x + Time.deltaTime * 1000f, transform.localPosition.y, transform.localPosition.z);
				}
				transform.localPosition = new Vector3(transform.localPosition.x + Input.GetAxis("Horizontal") * -10f, transform.localPosition.y, transform.localPosition.z);
				if (transform.localPosition.x > 500f)
				{
					transform.localPosition = new Vector3(500f, transform.localPosition.y, transform.localPosition.z);
				}
				else if (transform.localPosition.x < -250f * ((float)this.Challenges[this.List] - 3f))
				{
					transform.localPosition = new Vector3(-250f * ((float)this.Challenges[this.List] - 3f), transform.localPosition.y, transform.localPosition.z);
				}
				if (this.LargeIcon.color.a > 0f)
				{
					this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, this.LargeIcon.color.a - Time.deltaTime * 10f);
					if (this.LargeIcon.color.a < 0f)
					{
						this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, 0f);
					}
				}
			}
		}
		else if (this.LargeIcon.color.a < 1f)
		{
			this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, this.LargeIcon.color.a + Time.deltaTime * 10f);
			if (this.LargeIcon.color.a > 1f)
			{
				this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, 1f);
			}
		}
		this.Shadow.color = new Color(this.Shadow.color.r, this.Shadow.color.g, this.Shadow.color.b, this.LargeIcon.color.a * 0.75f);
		if (!this.Switch && Input.GetButtonDown("A") && this.List == 1)
		{
			this.Viewing = true;
		}
		if (Input.GetButtonDown("B"))
		{
			if (this.Viewing)
			{
				this.Viewing = false;
			}
			else
			{
				this.Switch = true;
			}
		}
		if (this.Switch)
		{
			if (this.Phase == 1)
			{
				this.ChallengePanel.alpha -= Time.deltaTime;
				if (this.ChallengePanel.alpha <= 0f)
				{
					this.Phase++;
					return;
				}
			}
			else
			{
				this.CalendarPanel.alpha += Time.deltaTime;
				if (this.CalendarPanel.alpha >= 1f)
				{
					this.Calendar.enabled = true;
					base.enabled = false;
					this.Switch = false;
					this.Phase = 1;
				}
			}
		}
	}

	// Token: 0x04000CE8 RID: 3304
	public InputManagerScript InputManager;

	// Token: 0x04000CE9 RID: 3305
	public CalendarScript Calendar;

	// Token: 0x04000CEA RID: 3306
	public GameObject ViewButton;

	// Token: 0x04000CEB RID: 3307
	public Transform Arrows;

	// Token: 0x04000CEC RID: 3308
	public Transform[] ChallengeList;

	// Token: 0x04000CED RID: 3309
	public int[] Challenges;

	// Token: 0x04000CEE RID: 3310
	public UIPanel[] Panels;

	// Token: 0x04000CEF RID: 3311
	public UIPanel ChallengePanel;

	// Token: 0x04000CF0 RID: 3312
	public UIPanel CalendarPanel;

	// Token: 0x04000CF1 RID: 3313
	public UITexture LargeIcon;

	// Token: 0x04000CF2 RID: 3314
	public UISprite Shadow;

	// Token: 0x04000CF3 RID: 3315
	public bool Viewing;

	// Token: 0x04000CF4 RID: 3316
	public bool Switch;

	// Token: 0x04000CF5 RID: 3317
	public int Phase = 1;

	// Token: 0x04000CF6 RID: 3318
	public int List;
}
