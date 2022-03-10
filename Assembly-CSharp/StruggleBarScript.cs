using System;
using UnityEngine;

// Token: 0x02000450 RID: 1104
public class StruggleBarScript : MonoBehaviour
{
	// Token: 0x06001D43 RID: 7491 RVA: 0x0015F2B1 File Offset: 0x0015D4B1
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.ChooseButton();
	}

	// Token: 0x06001D44 RID: 7492 RVA: 0x0015F2CC File Offset: 0x0015D4CC
	private void Update()
	{
		if (this.Struggling)
		{
			this.Intensity = Mathf.MoveTowards(this.Intensity, 1f, Time.deltaTime);
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.Spikes.localEulerAngles = new Vector3(this.Spikes.localEulerAngles.x, this.Spikes.localEulerAngles.y, this.Spikes.localEulerAngles.z - Time.deltaTime * 360f);
			this.Victory -= Time.deltaTime * 5f * this.Strength;
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
				this.Victory += Time.deltaTime * (500f + (float)(this.Yandere.Class.PhysicalGrade + this.Yandere.Class.PhysicalBonus) * 150f);
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
				if (this.ButtonTimer >= 2f)
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

	// Token: 0x06001D45 RID: 7493 RVA: 0x0015F730 File Offset: 0x0015D930
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

	// Token: 0x06001D46 RID: 7494 RVA: 0x0015F7B4 File Offset: 0x0015D9B4
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

	// Token: 0x040035A4 RID: 13732
	public ShoulderCameraScript ShoulderCamera;

	// Token: 0x040035A5 RID: 13733
	public PromptSwapScript ButtonPrompt;

	// Token: 0x040035A6 RID: 13734
	public UISprite[] ButtonPrompts;

	// Token: 0x040035A7 RID: 13735
	public YandereScript Yandere;

	// Token: 0x040035A8 RID: 13736
	public StudentScript Student;

	// Token: 0x040035A9 RID: 13737
	public Transform Spikes;

	// Token: 0x040035AA RID: 13738
	public string CurrentButton = string.Empty;

	// Token: 0x040035AB RID: 13739
	public bool Struggling;

	// Token: 0x040035AC RID: 13740
	public bool Invincible;

	// Token: 0x040035AD RID: 13741
	public float AttackTimer;

	// Token: 0x040035AE RID: 13742
	public float ButtonTimer;

	// Token: 0x040035AF RID: 13743
	public float Intensity;

	// Token: 0x040035B0 RID: 13744
	public float Strength = 1f;

	// Token: 0x040035B1 RID: 13745
	public float Struggle;

	// Token: 0x040035B2 RID: 13746
	public float Victory;

	// Token: 0x040035B3 RID: 13747
	public int ButtonID;
}
