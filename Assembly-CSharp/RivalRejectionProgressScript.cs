using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003EE RID: 1006
public class RivalRejectionProgressScript : MonoBehaviour
{
	// Token: 0x06001BF5 RID: 7157 RVA: 0x001473D8 File Offset: 0x001455D8
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

	// Token: 0x06001BF6 RID: 7158 RVA: 0x001474C4 File Offset: 0x001456C4
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

	// Token: 0x04003138 RID: 12600
	public UILabel PercentLabel;

	// Token: 0x04003139 RID: 12601
	public UILabel Label;

	// Token: 0x0400313A RID: 12602
	public Texture[] RivalHeads;

	// Token: 0x0400313B RID: 12603
	public UITexture RivalHead;

	// Token: 0x0400313C RID: 12604
	public UISprite Darkness;

	// Token: 0x0400313D RID: 12605
	public float Timer;

	// Token: 0x0400313E RID: 12606
	public int Phase = 1;
}
