using System;
using UnityEngine;

// Token: 0x02000270 RID: 624
public class DateReverseScript : MonoBehaviour
{
	// Token: 0x06001335 RID: 4917 RVA: 0x000AB463 File Offset: 0x000A9663
	private void Start()
	{
		Time.timeScale = 1f;
		this.UpdateDate();
	}

	// Token: 0x06001336 RID: 4918 RVA: 0x000AB478 File Offset: 0x000A9678
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

	// Token: 0x06001337 RID: 4919 RVA: 0x000AB620 File Offset: 0x000A9820
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

	// Token: 0x04001B86 RID: 7046
	public AudioSource MyAudio;

	// Token: 0x04001B87 RID: 7047
	public string[] MonthName;

	// Token: 0x04001B88 RID: 7048
	public string Prefix;

	// Token: 0x04001B89 RID: 7049
	public UILabel Label;

	// Token: 0x04001B8A RID: 7050
	public AudioClip Finish;

	// Token: 0x04001B8B RID: 7051
	public float TimeLimit;

	// Token: 0x04001B8C RID: 7052
	public float LifeTime;

	// Token: 0x04001B8D RID: 7053
	public float Timer;

	// Token: 0x04001B8E RID: 7054
	public int RollDirection;

	// Token: 0x04001B8F RID: 7055
	public int Month;

	// Token: 0x04001B90 RID: 7056
	public int Year;

	// Token: 0x04001B91 RID: 7057
	public int Day;

	// Token: 0x04001B92 RID: 7058
	public int SlowMonth;

	// Token: 0x04001B93 RID: 7059
	public int SlowYear;

	// Token: 0x04001B94 RID: 7060
	public int SlowDay;

	// Token: 0x04001B95 RID: 7061
	public int EndMonth;

	// Token: 0x04001B96 RID: 7062
	public int EndYear;

	// Token: 0x04001B97 RID: 7063
	public int EndDay;

	// Token: 0x04001B98 RID: 7064
	public bool Rollback;
}
