using System;
using UnityEngine;

// Token: 0x0200026E RID: 622
public class DateReverseScript : MonoBehaviour
{
	// Token: 0x06001329 RID: 4905 RVA: 0x000AA8BF File Offset: 0x000A8ABF
	private void Start()
	{
		Time.timeScale = 1f;
		this.UpdateDate();
	}

	// Token: 0x0600132A RID: 4906 RVA: 0x000AA8D4 File Offset: 0x000A8AD4
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.Rollback = true;
		}
		if (this.Rollback)
		{
			this.LifeTime += Time.deltaTime;
			this.Timer += Time.deltaTime;
			if (this.Timer > this.TimeLimit)
			{
				if ((this.Year == this.SlowYear && this.Month == this.SlowMonth && this.Day < this.SlowDay) || (this.Year == this.SlowYear && this.Month < this.SlowMonth))
				{
					this.TimeLimit *= 1.09f;
					if (this.Month == this.EndMonth && this.Day == this.EndDay + 1)
					{
						this.MyAudio.clip = this.Finish;
						this.Label.color = new Color(1f, 0f, 0f, 1f);
						base.enabled = false;
					}
				}
				else if (this.TimeLimit > 0.01f)
				{
					this.TimeLimit *= 0.9f;
				}
				else
				{
					this.Day += this.RollDirection * 19;
				}
				this.Timer = 0f;
				this.Day += this.RollDirection;
				this.UpdateDate();
				this.MyAudio.Play();
				if (!(this.MyAudio.clip != this.Finish))
				{
					this.MyAudio.pitch = 1f;
				}
			}
		}
	}

	// Token: 0x0600132B RID: 4907 RVA: 0x000AAA7C File Offset: 0x000A8C7C
	private void UpdateDate()
	{
		if (this.Day < 1)
		{
			this.Day = 31;
			this.Month--;
			if (this.Month < 1)
			{
				this.Month = 12;
				this.Year--;
			}
		}
		else if (this.Day > 31)
		{
			this.Day = 1;
			this.Month++;
			if (this.Month > 11)
			{
				this.Month = 1;
				this.Year++;
			}
		}
		if (this.Day == 1 || this.Day == 21 || this.Day == 31)
		{
			this.Prefix = "st";
		}
		else if (this.Day == 2 || this.Day == 22)
		{
			this.Prefix = "nd";
		}
		else if (this.Day == 3 || this.Day == 23)
		{
			this.Prefix = "rd";
		}
		else
		{
			this.Prefix = "th";
		}
		this.Label.text = string.Concat(new string[]
		{
			this.MonthName[this.Month],
			" ",
			this.Day.ToString(),
			this.Prefix,
			", ",
			this.Year.ToString()
		});
	}

	// Token: 0x04001B56 RID: 6998
	public AudioSource MyAudio;

	// Token: 0x04001B57 RID: 6999
	public string[] MonthName;

	// Token: 0x04001B58 RID: 7000
	public string Prefix;

	// Token: 0x04001B59 RID: 7001
	public UILabel Label;

	// Token: 0x04001B5A RID: 7002
	public AudioClip Finish;

	// Token: 0x04001B5B RID: 7003
	public float TimeLimit;

	// Token: 0x04001B5C RID: 7004
	public float LifeTime;

	// Token: 0x04001B5D RID: 7005
	public float Timer;

	// Token: 0x04001B5E RID: 7006
	public int RollDirection;

	// Token: 0x04001B5F RID: 7007
	public int Month;

	// Token: 0x04001B60 RID: 7008
	public int Year;

	// Token: 0x04001B61 RID: 7009
	public int Day;

	// Token: 0x04001B62 RID: 7010
	public int SlowMonth;

	// Token: 0x04001B63 RID: 7011
	public int SlowYear;

	// Token: 0x04001B64 RID: 7012
	public int SlowDay;

	// Token: 0x04001B65 RID: 7013
	public int EndMonth;

	// Token: 0x04001B66 RID: 7014
	public int EndYear;

	// Token: 0x04001B67 RID: 7015
	public int EndDay;

	// Token: 0x04001B68 RID: 7016
	public bool Rollback;
}
