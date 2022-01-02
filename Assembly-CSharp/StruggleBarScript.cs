using System;
using UnityEngine;

// Token: 0x0200044B RID: 1099
public class StruggleBarScript : MonoBehaviour
{
	// Token: 0x06001D22 RID: 7458 RVA: 0x0015B7BD File Offset: 0x001599BD
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.ChooseButton();
	}

	// Token: 0x06001D23 RID: 7459 RVA: 0x0015B7D8 File Offset: 0x001599D8
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

	// Token: 0x06001D24 RID: 7460 RVA: 0x0015BC48 File Offset: 0x00159E48
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

	// Token: 0x06001D25 RID: 7461 RVA: 0x0015BCCC File Offset: 0x00159ECC
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

	// Token: 0x04003553 RID: 13651
	public ShoulderCameraScript ShoulderCamera;

	// Token: 0x04003554 RID: 13652
	public PromptSwapScript ButtonPrompt;

	// Token: 0x04003555 RID: 13653
	public UISprite[] ButtonPrompts;

	// Token: 0x04003556 RID: 13654
	public YandereScript Yandere;

	// Token: 0x04003557 RID: 13655
	public StudentScript Student;

	// Token: 0x04003558 RID: 13656
	public Transform Spikes;

	// Token: 0x04003559 RID: 13657
	public string CurrentButton = string.Empty;

	// Token: 0x0400355A RID: 13658
	public bool Struggling;

	// Token: 0x0400355B RID: 13659
	public bool Invincible;

	// Token: 0x0400355C RID: 13660
	public float AttackTimer;

	// Token: 0x0400355D RID: 13661
	public float ButtonTimer;

	// Token: 0x0400355E RID: 13662
	public float Intensity;

	// Token: 0x0400355F RID: 13663
	public float Strength = 1f;

	// Token: 0x04003560 RID: 13664
	public float Struggle;

	// Token: 0x04003561 RID: 13665
	public float Victory;

	// Token: 0x04003562 RID: 13666
	public int ButtonID;
}
