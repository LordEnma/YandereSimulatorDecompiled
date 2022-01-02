using System;
using UnityEngine;

// Token: 0x0200036B RID: 875
public class MopScript : MonoBehaviour
{
	// Token: 0x060019A8 RID: 6568 RVA: 0x00105E22 File Offset: 0x00104022
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		this.HeadCollider.enabled = false;
		this.UpdateBlood();
	}

	// Token: 0x060019A9 RID: 6569 RVA: 0x00105E4C File Offset: 0x0010404C
	private void Update()
	{
		if (this.PickUp.Clock.Period == 5)
		{
			this.PickUp.Suspicious = false;
		}
		else
		{
			this.PickUp.Suspicious = true;
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

	// Token: 0x060019AA RID: 6570 RVA: 0x001061CC File Offset: 0x001043CC
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

	// Token: 0x060019AB RID: 6571 RVA: 0x00106269 File Offset: 0x00104469
	public void Dip()
	{
		this.Yandere.YandereVision = false;
		this.Yandere.CanMove = false;
		this.Yandere.Dipping = true;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
	}

	// Token: 0x0400290F RID: 10511
	public ParticleSystem Sparkles;

	// Token: 0x04002910 RID: 10512
	public YandereScript Yandere;

	// Token: 0x04002911 RID: 10513
	public PromptScript Prompt;

	// Token: 0x04002912 RID: 10514
	public PickUpScript PickUp;

	// Token: 0x04002913 RID: 10515
	public Collider HeadCollider;

	// Token: 0x04002914 RID: 10516
	public Vector3 Rotation;

	// Token: 0x04002915 RID: 10517
	public Renderer Blood;

	// Token: 0x04002916 RID: 10518
	public Transform Head;

	// Token: 0x04002917 RID: 10519
	public float Bloodiness;

	// Token: 0x04002918 RID: 10520
	public bool Bleached;
}
