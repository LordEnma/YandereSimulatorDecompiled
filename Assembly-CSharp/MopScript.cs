using System;
using UnityEngine;

// Token: 0x02000370 RID: 880
public class MopScript : MonoBehaviour
{
	// Token: 0x060019D7 RID: 6615 RVA: 0x00108CFE File Offset: 0x00106EFE
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		this.HeadCollider.enabled = false;
		this.UpdateBlood();
	}

	// Token: 0x060019D8 RID: 6616 RVA: 0x00108D28 File Offset: 0x00106F28
	private void Update()
	{
		if (this.PickUp.Clock != null)
		{
			if (this.PickUp.Clock.Period == 5)
			{
				this.PickUp.Suspicious = false;
			}
			else
			{
				this.PickUp.Suspicious = true;
			}
		}
		if (!this.Prompt.PauseScreen.Show)
		{
			if (this.Yandere.PickUp == this.PickUp)
			{
				if (this.Prompt.HideButton[0])
				{
					this.Prompt.HideButton[0] = false;
					this.Prompt.HideButton[3] = true;
					this.Yandere.Mop = this;
				}
				if (this.Yandere.Bucket == null)
				{
					if (this.Bleached)
					{
						this.Prompt.HideButton[0] = false;
						if (this.Prompt.Button[0].color.a > 0f)
						{
							this.Prompt.Label[0].text = "     Sweep";
							if (Input.GetButtonDown("A"))
							{
								this.Yandere.Mopping = true;
								this.HeadCollider.enabled = true;
							}
						}
					}
					else
					{
						this.Prompt.Label[0].text = "     Dip In Bucket First!";
						this.Prompt.HideButton[0] = false;
					}
				}
				else if (this.Prompt.Button[0].color.a > 0f && !this.Yandere.Chased && this.Yandere.Chasers == 0)
				{
					if (this.Yandere.Bucket.Full)
					{
						if (!this.Yandere.Bucket.Gasoline)
						{
							if (this.Yandere.Bucket.Bleached)
							{
								if (this.Yandere.Bucket.Bloodiness < 100f)
								{
									this.Prompt.Label[0].text = "     Dip";
									if (Input.GetButtonDown("A"))
									{
										this.Dip();
									}
								}
								else
								{
									this.Prompt.Label[0].text = "     Water Too Bloody!";
								}
							}
							else
							{
								this.Prompt.Label[0].text = "     Add Bleach First!";
							}
						}
						else
						{
							this.Prompt.Label[0].text = "     Can't Use Gasoline!";
						}
					}
					else
					{
						this.Prompt.Label[0].text = "     Fill Bucket First!";
					}
				}
				if (this.Yandere.Mopping)
				{
					this.Head.LookAt(this.Head.position + Vector3.down);
					this.Head.localEulerAngles = new Vector3(this.Head.localEulerAngles.x + 90f, this.Head.localEulerAngles.y, 180f);
				}
				else
				{
					this.Rotation = Vector3.Lerp(this.Head.localEulerAngles, Vector3.zero, Time.deltaTime * 10f);
					this.Head.localEulerAngles = this.Rotation;
				}
			}
			else
			{
				this.Prompt.HideButton[0] = true;
				this.Prompt.HideButton[3] = false;
				if (this.Yandere.Mop == this)
				{
					this.Yandere.Mop = null;
				}
			}
			if (!this.Yandere.Mopping && this.HeadCollider.enabled)
			{
				this.HeadCollider.enabled = false;
			}
		}
	}

	// Token: 0x060019D9 RID: 6617 RVA: 0x001090BC File Offset: 0x001072BC
	public void UpdateBlood()
	{
		if (this.Bloodiness > 100f)
		{
			this.Bloodiness = 100f;
			this.Sparkles.Stop();
			this.Bleached = false;
		}
		this.Blood.material.color = new Color(this.Blood.material.color.r, this.Blood.material.color.g, this.Blood.material.color.b, this.Bloodiness / 100f * 0.9f);
	}

	// Token: 0x060019DA RID: 6618 RVA: 0x00109159 File Offset: 0x00107359
	public void Dip()
	{
		this.Yandere.YandereVision = false;
		this.Yandere.CanMove = false;
		this.Yandere.Dipping = true;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
	}

	// Token: 0x0400298D RID: 10637
	public ParticleSystem Sparkles;

	// Token: 0x0400298E RID: 10638
	public YandereScript Yandere;

	// Token: 0x0400298F RID: 10639
	public PromptScript Prompt;

	// Token: 0x04002990 RID: 10640
	public PickUpScript PickUp;

	// Token: 0x04002991 RID: 10641
	public Collider HeadCollider;

	// Token: 0x04002992 RID: 10642
	public Vector3 Rotation;

	// Token: 0x04002993 RID: 10643
	public Renderer Blood;

	// Token: 0x04002994 RID: 10644
	public Transform Head;

	// Token: 0x04002995 RID: 10645
	public float Bloodiness;

	// Token: 0x04002996 RID: 10646
	public bool Bleached;
}
