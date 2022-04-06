using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003EE RID: 1006
public class RivalRejectionProgressScript : MonoBehaviour
{
	// Token: 0x06001BF1 RID: 7153 RVA: 0x00146FC8 File Offset: 0x001451C8
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

	// Token: 0x06001BF2 RID: 7154 RVA: 0x001470B4 File Offset: 0x001452B4
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

	// Token: 0x0400312D RID: 12589
	public UILabel PercentLabel;

	// Token: 0x0400312E RID: 12590
	public UILabel Label;

	// Token: 0x0400312F RID: 12591
	public Texture[] RivalHeads;

	// Token: 0x04003130 RID: 12592
	public UITexture RivalHead;

	// Token: 0x04003131 RID: 12593
	public UISprite Darkness;

	// Token: 0x04003132 RID: 12594
	public float Timer;

	// Token: 0x04003133 RID: 12595
	public int Phase = 1;
}
