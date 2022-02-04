using System;
using UnityEngine;

// Token: 0x0200026F RID: 623
public class DateReverseScript : MonoBehaviour
{
	// Token: 0x06001331 RID: 4913 RVA: 0x000AB10B File Offset: 0x000A930B
	private void Start()
	{
		Time.timeScale = 1f;
		this.UpdateDate();
	}

	// Token: 0x06001332 RID: 4914 RVA: 0x000AB120 File Offset: 0x000A9320
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

	// Token: 0x06001333 RID: 4915 RVA: 0x000AB2C8 File Offset: 0x000A94C8
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

	// Token: 0x04001B77 RID: 7031
	public AudioSource MyAudio;

	// Token: 0x04001B78 RID: 7032
	public string[] MonthName;

	// Token: 0x04001B79 RID: 7033
	public string Prefix;

	// Token: 0x04001B7A RID: 7034
	public UILabel Label;

	// Token: 0x04001B7B RID: 7035
	public AudioClip Finish;

	// Token: 0x04001B7C RID: 7036
	public float TimeLimit;

	// Token: 0x04001B7D RID: 7037
	public float LifeTime;

	// Token: 0x04001B7E RID: 7038
	public float Timer;

	// Token: 0x04001B7F RID: 7039
	public int RollDirection;

	// Token: 0x04001B80 RID: 7040
	public int Month;

	// Token: 0x04001B81 RID: 7041
	public int Year;

	// Token: 0x04001B82 RID: 7042
	public int Day;

	// Token: 0x04001B83 RID: 7043
	public int SlowMonth;

	// Token: 0x04001B84 RID: 7044
	public int SlowYear;

	// Token: 0x04001B85 RID: 7045
	public int SlowDay;

	// Token: 0x04001B86 RID: 7046
	public int EndMonth;

	// Token: 0x04001B87 RID: 7047
	public int EndYear;

	// Token: 0x04001B88 RID: 7048
	public int EndDay;

	// Token: 0x04001B89 RID: 7049
	public bool Rollback;
}
