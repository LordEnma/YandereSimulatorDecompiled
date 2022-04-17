using System;
using UnityEngine;

// Token: 0x02000456 RID: 1110
public class StruggleBarScript : MonoBehaviour
{
	// Token: 0x06001D68 RID: 7528 RVA: 0x00161D6D File Offset: 0x0015FF6D
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.ChooseButton();
	}

	// Token: 0x06001D69 RID: 7529 RVA: 0x00161D88 File Offset: 0x0015FF88
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

	// Token: 0x06001D6A RID: 7530 RVA: 0x001621EC File Offset: 0x001603EC
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

	// Token: 0x06001D6B RID: 7531 RVA: 0x00162270 File Offset: 0x00160470
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

	// Token: 0x04003617 RID: 13847
	public ShoulderCameraScript ShoulderCamera;

	// Token: 0x04003618 RID: 13848
	public PromptSwapScript ButtonPrompt;

	// Token: 0x04003619 RID: 13849
	public UISprite[] ButtonPrompts;

	// Token: 0x0400361A RID: 13850
	public YandereScript Yandere;

	// Token: 0x0400361B RID: 13851
	public StudentScript Student;

	// Token: 0x0400361C RID: 13852
	public Transform Spikes;

	// Token: 0x0400361D RID: 13853
	public string CurrentButton = string.Empty;

	// Token: 0x0400361E RID: 13854
	public bool Struggling;

	// Token: 0x0400361F RID: 13855
	public bool Invincible;

	// Token: 0x04003620 RID: 13856
	public float AttackTimer;

	// Token: 0x04003621 RID: 13857
	public float ButtonTimer;

	// Token: 0x04003622 RID: 13858
	public float Intensity;

	// Token: 0x04003623 RID: 13859
	public float Strength = 1f;

	// Token: 0x04003624 RID: 13860
	public float Struggle;

	// Token: 0x04003625 RID: 13861
	public float Victory;

	// Token: 0x04003626 RID: 13862
	public int ButtonID;
}
