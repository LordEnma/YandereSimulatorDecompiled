using System;
using UnityEngine;

// Token: 0x020000CD RID: 205
public class AppearanceWindowScript : MonoBehaviour
{
	// Token: 0x060009C9 RID: 2505 RVA: 0x00051520 File Offset: 0x0004F720
	private void Start()
	{
		this.Window.localScale = Vector3.zero;
		for (int i = 1; i < 10; i++)
		{
			this.Checks[i].enabled = DatingGlobals.GetSuitorCheck(i);
		}
	}

	// Token: 0x060009CA RID: 2506 RVA: 0x00051560 File Offset: 0x0004F760
	private void Update()
	{
		if (!this.Show)
		{
			if (this.Window.gameObject.activeInHierarchy)
			{
				if (this.Window.localScale.x > 0.1f)
				{
					this.Window.localScale = Vector3.Lerp(this.Window.localScale, Vector3.zero, Time.deltaTime * 10f);
					return;
				}
				this.Window.localScale = Vector3.zero;
				this.Window.gameObject.SetActive(false);
				return;
			}
		}
		else
		{
			this.Window.localScale = Vector3.Lerp(this.Window.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (this.Ready)
			{
				if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected == 10)
					{
						this.Selected = 9;
					}
					this.UpdateHighlight();
				}
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected == 10)
					{
						this.Selected = 11;
					}
					this.UpdateHighlight();
				}
				if (Input.GetButtonDown("A"))
				{
					if (this.Selected == 1)
					{
						if (!this.Checks[1].enabled)
						{
							this.StudentManager.LoveManager.CustomSuitorHair = 55;
							this.Checks[1].enabled = true;
							this.Checks[2].enabled = false;
						}
						else
						{
							this.StudentManager.LoveManager.CustomSuitorHair = 0;
							this.Checks[1].enabled = false;
						}
					}
					else if (this.Selected == 2)
					{
						if (!this.Checks[2].enabled)
						{
							this.StudentManager.LoveManager.CustomSuitorHair = 56;
							this.Checks[1].enabled = false;
							this.Checks[2].enabled = true;
						}
						else
						{
							this.StudentManager.LoveManager.CustomSuitorHair = 0;
							this.Checks[2].enabled = false;
						}
					}
					else if (this.Selected == 3)
					{
						if (!this.Checks[3].enabled)
						{
							this.StudentManager.LoveManager.CustomSuitorAccessory = 17;
							this.Checks[3].enabled = true;
							this.Checks[4].enabled = false;
						}
						else
						{
							this.StudentManager.LoveManager.CustomSuitorAccessory = 0;
							this.Checks[3].enabled = false;
						}
					}
					else if (this.Selected == 4)
					{
						if (!this.Checks[4].enabled)
						{
							this.StudentManager.LoveManager.CustomSuitorAccessory = 1;
							this.Checks[3].enabled = false;
							this.Checks[4].enabled = true;
						}
						else
						{
							this.StudentManager.LoveManager.CustomSuitorAccessory = 0;
							this.Checks[4].enabled = false;
						}
					}
					else if (this.Selected == 5)
					{
						if (!this.Checks[5].enabled)
						{
							this.StudentManager.LoveManager.CustomSuitorEyewear = 6;
							this.Checks[5].enabled = true;
							this.Checks[6].enabled = false;
						}
						else
						{
							this.StudentManager.LoveManager.CustomSuitorEyewear = 0;
							this.Checks[5].enabled = false;
						}
					}
					else if (this.Selected == 6)
					{
						if (!this.Checks[6].enabled)
						{
							this.StudentManager.LoveManager.CustomSuitorEyewear = 3;
							this.Checks[5].enabled = false;
							this.Checks[6].enabled = true;
						}
						else
						{
							this.StudentManager.LoveManager.CustomSuitorEyewear = 0;
							this.Checks[6].enabled = false;
						}
					}
					else if (this.Selected == 7)
					{
						if (!this.Checks[7].enabled)
						{
							this.StudentManager.LoveManager.CustomSuitorTan = true;
							this.Checks[7].enabled = true;
						}
						else
						{
							this.StudentManager.LoveManager.CustomSuitorTan = false;
							this.Checks[7].enabled = false;
						}
					}
					else if (this.Selected == 8)
					{
						if (!this.Checks[8].enabled)
						{
							this.StudentManager.LoveManager.CustomSuitorBlack = true;
							this.Checks[8].enabled = true;
						}
						else
						{
							this.StudentManager.LoveManager.CustomSuitorBlack = false;
							this.Checks[8].enabled = false;
						}
					}
					else if (this.Selected == 9)
					{
						if (!this.Checks[9].enabled)
						{
							this.StudentManager.LoveManager.CustomSuitorJewelry = 1;
							this.Checks[9].enabled = true;
						}
						else
						{
							this.StudentManager.LoveManager.CustomSuitorJewelry = 0;
							this.Checks[9].enabled = false;
						}
					}
					else if (this.Selected == 11)
					{
						this.StudentManager.LoveManager.CustomSuitor = true;
						this.PromptBar.ClearButtons();
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = false;
						this.Yandere.Interaction = YandereInteractionType.ChangingAppearance;
						this.Yandere.TalkTimer = 3f;
						this.Ready = false;
						this.Show = false;
					}
				}
			}
			if (Input.GetButtonUp("A"))
			{
				this.Ready = true;
			}
		}
	}

	// Token: 0x060009CB RID: 2507 RVA: 0x00051ADC File Offset: 0x0004FCDC
	private void UpdateHighlight()
	{
		if (this.Selected < 1)
		{
			this.Selected = 11;
		}
		else if (this.Selected > 11)
		{
			this.Selected = 1;
		}
		this.Highlight.transform.localPosition = new Vector3(this.Highlight.transform.localPosition.x, 300f - 50f * (float)this.Selected, this.Highlight.transform.localPosition.z);
	}

	// Token: 0x060009CC RID: 2508 RVA: 0x00051B5F File Offset: 0x0004FD5F
	private void Exit()
	{
		this.Selected = 1;
		this.UpdateHighlight();
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		this.Show = false;
	}

	// Token: 0x04000A31 RID: 2609
	public StudentManagerScript StudentManager;

	// Token: 0x04000A32 RID: 2610
	public InputManagerScript InputManager;

	// Token: 0x04000A33 RID: 2611
	public PromptBarScript PromptBar;

	// Token: 0x04000A34 RID: 2612
	public YandereScript Yandere;

	// Token: 0x04000A35 RID: 2613
	public Transform Highlight;

	// Token: 0x04000A36 RID: 2614
	public Transform Window;

	// Token: 0x04000A37 RID: 2615
	public UISprite[] Checks;

	// Token: 0x04000A38 RID: 2616
	public int Selected;

	// Token: 0x04000A39 RID: 2617
	public bool Ready;

	// Token: 0x04000A3A RID: 2618
	public bool Show;
}
