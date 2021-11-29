using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003E3 RID: 995
public class RivalRejectionProgressScript : MonoBehaviour
{
	// Token: 0x06001BAC RID: 7084 RVA: 0x001412B8 File Offset: 0x0013F4B8
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

	// Token: 0x06001BAD RID: 7085 RVA: 0x001413A4 File Offset: 0x0013F5A4
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

	// Token: 0x0400306B RID: 12395
	public UILabel PercentLabel;

	// Token: 0x0400306C RID: 12396
	public UILabel Label;

	// Token: 0x0400306D RID: 12397
	public Texture[] RivalHeads;

	// Token: 0x0400306E RID: 12398
	public UITexture RivalHead;

	// Token: 0x0400306F RID: 12399
	public UISprite Darkness;

	// Token: 0x04003070 RID: 12400
	public float Timer;

	// Token: 0x04003071 RID: 12401
	public int Phase = 1;
}
