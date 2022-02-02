using System;
using UnityEngine;

// Token: 0x0200044E RID: 1102
public class StruggleBarScript : MonoBehaviour
{
	// Token: 0x06001D2F RID: 7471 RVA: 0x0015DC21 File Offset: 0x0015BE21
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.ChooseButton();
	}

	// Token: 0x06001D30 RID: 7472 RVA: 0x0015DC3C File Offset: 0x0015BE3C
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

	// Token: 0x06001D31 RID: 7473 RVA: 0x0015E0AC File Offset: 0x0015C2AC
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

	// Token: 0x06001D32 RID: 7474 RVA: 0x0015E130 File Offset: 0x0015C330
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

	// Token: 0x04003573 RID: 13683
	public ShoulderCameraScript ShoulderCamera;

	// Token: 0x04003574 RID: 13684
	public PromptSwapScript ButtonPrompt;

	// Token: 0x04003575 RID: 13685
	public UISprite[] ButtonPrompts;

	// Token: 0x04003576 RID: 13686
	public YandereScript Yandere;

	// Token: 0x04003577 RID: 13687
	public StudentScript Student;

	// Token: 0x04003578 RID: 13688
	public Transform Spikes;

	// Token: 0x04003579 RID: 13689
	public string CurrentButton = string.Empty;

	// Token: 0x0400357A RID: 13690
	public bool Struggling;

	// Token: 0x0400357B RID: 13691
	public bool Invincible;

	// Token: 0x0400357C RID: 13692
	public float AttackTimer;

	// Token: 0x0400357D RID: 13693
	public float ButtonTimer;

	// Token: 0x0400357E RID: 13694
	public float Intensity;

	// Token: 0x0400357F RID: 13695
	public float Strength = 1f;

	// Token: 0x04003580 RID: 13696
	public float Struggle;

	// Token: 0x04003581 RID: 13697
	public float Victory;

	// Token: 0x04003582 RID: 13698
	public int ButtonID;
}
