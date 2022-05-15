using System;
using UnityEngine;

// Token: 0x02000371 RID: 881
public class MopScript : MonoBehaviour
{
	// Token: 0x060019E1 RID: 6625 RVA: 0x00109A48 File Offset: 0x00107C48
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		this.HeadCollider.enabled = false;
		this.UpdateBlood();
	}

	// Token: 0x060019E2 RID: 6626 RVA: 0x00109A74 File Offset: 0x00107C74
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

	// Token: 0x060019E3 RID: 6627 RVA: 0x00109E08 File Offset: 0x00108008
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

	// Token: 0x060019E4 RID: 6628 RVA: 0x00109EA5 File Offset: 0x001080A5
	public void Dip()
	{
		this.Yandere.YandereVision = false;
		this.Yandere.CanMove = false;
		this.Yandere.Dipping = true;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
	}

	// Token: 0x040029A7 RID: 10663
	public ParticleSystem Sparkles;

	// Token: 0x040029A8 RID: 10664
	public YandereScript Yandere;

	// Token: 0x040029A9 RID: 10665
	public PromptScript Prompt;

	// Token: 0x040029AA RID: 10666
	public PickUpScript PickUp;

	// Token: 0x040029AB RID: 10667
	public Collider HeadCollider;

	// Token: 0x040029AC RID: 10668
	public Vector3 Rotation;

	// Token: 0x040029AD RID: 10669
	public Renderer Blood;

	// Token: 0x040029AE RID: 10670
	public Transform Head;

	// Token: 0x040029AF RID: 10671
	public float Bloodiness;

	// Token: 0x040029B0 RID: 10672
	public int StudentBloodID;

	// Token: 0x040029B1 RID: 10673
	public bool Bleached;
}
