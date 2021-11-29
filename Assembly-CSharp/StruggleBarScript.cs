using System;
using UnityEngine;

// Token: 0x0200044A RID: 1098
public class StruggleBarScript : MonoBehaviour
{
	// Token: 0x06001D18 RID: 7448 RVA: 0x0015A9A1 File Offset: 0x00158BA1
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.ChooseButton();
	}

	// Token: 0x06001D19 RID: 7449 RVA: 0x0015A9BC File Offset: 0x00158BBC
	private void Update()
	{
		if (this.Struggling)
		{
			this.Intensity = Mathf.MoveTowards(this.Intensity, 1f, Time.deltaTime);
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.Spikes.localEulerAngles = new Vector3(this.Spikes.localEulerAngles.x, this.Spikes.localEulerAngles.y, this.Spikes.localEulerAngles.z - Time.deltaTime * 360f);
			this.Victory -= Time.deltaTime * 10f * this.Strength * this.Intensity;
			if (this.Yandere.Club == ClubType.MartialArts)
			{
				this.Victory = 100f;
			}
			if (Input.GetButtonDown(this.CurrentButton))
			{
				if (this.Invincible)
				{
					this.Victory += 100f;
				}
				this.Victory += Time.deltaTime * (500f + (float)(this.Yandere.Class.PhysicalGrade + this.Yandere.Class.PhysicalBonus) * 150f) * this.Intensity;
			}
			if (this.Victory >= 100f)
			{
				this.Victory = 100f;
			}
			if (this.Victory <= -100f)
			{
				this.Victory = -100f;
			}
			UISprite uisprite = this.ButtonPrompts[this.ButtonID];
			uisprite.transform.localPosition = new Vector3(Mathf.Lerp(uisprite.transform.localPosition.x, this.Victory * 6.5f, Time.deltaTime * 10f), uisprite.transform.localPosition.y, uisprite.transform.localPosition.z);
			this.Spikes.localPosition = new Vector3(uisprite.transform.localPosition.x, this.Spikes.localPosition.y, this.Spikes.localPosition.z);
			if (this.Victory == 100f)
			{
				Debug.Log("Yandere-chan just won a struggle against " + this.Student.Name + ".");
				this.Yandere.Won = true;
				this.Student.Lost = true;
				this.Struggling = false;
				this.Victory = 0f;
				return;
			}
			if (this.Victory == -100f)
			{
				if (!this.Invincible)
				{
					this.HeroWins();
					return;
				}
			}
			else
			{
				this.ButtonTimer += Time.deltaTime;
				if (this.ButtonTimer >= 1f)
				{
					this.ChooseButton();
					this.ButtonTimer = 0f;
					this.Intensity = 0f;
					return;
				}
			}
		}
		else
		{
			if (base.transform.localScale.x > 0.1f)
			{
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
				return;
			}
			base.transform.localScale = Vector3.zero;
			if (!this.Yandere.AttackManager.Censor)
			{
				base.gameObject.SetActive(false);
				return;
			}
			if (this.AttackTimer == 0f)
			{
				this.Yandere.Blur.enabled = true;
				this.Yandere.Blur.Size = 1f;
			}
			this.AttackTimer += Time.deltaTime;
			if (this.AttackTimer < 2.5f)
			{
				this.Yandere.Blur.Size = Mathf.MoveTowards(this.Yandere.Blur.Size, 16f, Time.deltaTime * 10f);
				return;
			}
			this.Yandere.Blur.Size = Mathf.Lerp(this.Yandere.Blur.Size, 1f, Time.deltaTime * 32f);
			if (this.AttackTimer >= 3f)
			{
				base.gameObject.SetActive(false);
				this.Yandere.Blur.enabled = false;
				this.Yandere.Blur.Size = 1f;
				this.AttackTimer = 0f;
			}
		}
	}

	// Token: 0x06001D1A RID: 7450 RVA: 0x0015AE2C File Offset: 0x0015902C
	public void HeroWins()
	{
		if (this.Yandere.enabled && this.Yandere.Armed)
		{
			this.Yandere.EquippedWeapon.Drop();
		}
		this.Yandere.Lost = true;
		this.Student.Won = true;
		this.Struggling = false;
		this.Victory = 0f;
		if (this.Yandere.StudentManager.enabled)
		{
			this.Yandere.StudentManager.StopMoving();
		}
	}

	// Token: 0x06001D1B RID: 7451 RVA: 0x0015AEB0 File Offset: 0x001590B0
	private void ChooseButton()
	{
		int buttonID = this.ButtonID;
		for (int i = 1; i < 5; i++)
		{
			this.ButtonPrompts[i].enabled = false;
			this.ButtonPrompts[i].transform.localPosition = this.ButtonPrompts[buttonID].transform.localPosition;
		}
		while (this.ButtonID == buttonID)
		{
			this.ButtonID = UnityEngine.Random.Range(1, 5);
		}
		if (this.ButtonID == 1)
		{
			this.CurrentButton = "A";
		}
		else if (this.ButtonID == 2)
		{
			this.CurrentButton = "B";
		}
		else if (this.ButtonID == 3)
		{
			this.CurrentButton = "X";
		}
		else if (this.ButtonID == 4)
		{
			this.CurrentButton = "Y";
		}
		this.ButtonPrompts[this.ButtonID].enabled = true;
	}

	// Token: 0x04003521 RID: 13601
	public ShoulderCameraScript ShoulderCamera;

	// Token: 0x04003522 RID: 13602
	public PromptSwapScript ButtonPrompt;

	// Token: 0x04003523 RID: 13603
	public UISprite[] ButtonPrompts;

	// Token: 0x04003524 RID: 13604
	public YandereScript Yandere;

	// Token: 0x04003525 RID: 13605
	public StudentScript Student;

	// Token: 0x04003526 RID: 13606
	public Transform Spikes;

	// Token: 0x04003527 RID: 13607
	public string CurrentButton = string.Empty;

	// Token: 0x04003528 RID: 13608
	public bool Struggling;

	// Token: 0x04003529 RID: 13609
	public bool Invincible;

	// Token: 0x0400352A RID: 13610
	public float AttackTimer;

	// Token: 0x0400352B RID: 13611
	public float ButtonTimer;

	// Token: 0x0400352C RID: 13612
	public float Intensity;

	// Token: 0x0400352D RID: 13613
	public float Strength = 1f;

	// Token: 0x0400352E RID: 13614
	public float Struggle;

	// Token: 0x0400352F RID: 13615
	public float Victory;

	// Token: 0x04003530 RID: 13616
	public int ButtonID;
}
