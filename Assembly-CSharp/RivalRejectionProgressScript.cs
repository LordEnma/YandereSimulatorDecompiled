using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003ED RID: 1005
public class RivalRejectionProgressScript : MonoBehaviour
{
	// Token: 0x06001BEB RID: 7147 RVA: 0x00146CE4 File Offset: 0x00144EE4
	private void Start()
	{
		this.Label.text = string.Concat(new string[]
		{
			"You have sabotaged ",
			DatingGlobals.RivalSabotaged.ToString(),
			" of your rival's interactions with Senpai. You must sabotage ",
			(5 - DatingGlobals.RivalSabotaged).ToString(),
			" more of their interactions in order to foil your rival's love confession on Friday."
		});
		this.PercentLabel.text = (DatingGlobals.RivalSabotaged * 20).ToString() + "%";
		this.RivalHead.transform.localPosition = new Vector3((float)(-700 + DatingGlobals.RivalSabotaged * 200), 0f, 0f);
		this.Darkness.alpha = 1f;
		Time.timeScale = 1f;
		if (GameGlobals.Eighties)
		{
			this.RivalHead.mainTexture = this.RivalHeads[DateGlobals.Week];
		}
	}

	// Token: 0x06001BEC RID: 7148 RVA: 0x00146DD0 File Offset: 0x00144FD0
	private void Update()
	{
		if (this.Phase == 1)
		{
			this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0f, Time.deltaTime);
			if (this.Darkness.alpha == 0f)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			if (Input.GetButtonDown("A"))
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime);
			if (this.Darkness.alpha == 1f)
			{
				if (!GameGlobals.JustKidnapped)
				{
					SceneManager.LoadScene("HomeScene");
				}
				else
				{
					GameGlobals.JustKidnapped = false;
					SceneManager.LoadScene("HomeScene");
				}
			}
		}
		if (this.Phase > 1)
		{
			this.RivalHead.transform.localPosition = Vector3.Lerp(this.RivalHead.transform.localPosition, new Vector3((float)(-500 + DatingGlobals.RivalSabotaged * 200), 0f, 0f), Time.deltaTime * 10f);
		}
	}

	// Token: 0x0400312A RID: 12586
	public UILabel PercentLabel;

	// Token: 0x0400312B RID: 12587
	public UILabel Label;

	// Token: 0x0400312C RID: 12588
	public Texture[] RivalHeads;

	// Token: 0x0400312D RID: 12589
	public UITexture RivalHead;

	// Token: 0x0400312E RID: 12590
	public UISprite Darkness;

	// Token: 0x0400312F RID: 12591
	public float Timer;

	// Token: 0x04003130 RID: 12592
	public int Phase = 1;
}
