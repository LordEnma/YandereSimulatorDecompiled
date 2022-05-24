using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003F0 RID: 1008
public class RivalRejectionProgressScript : MonoBehaviour
{
	// Token: 0x06001C03 RID: 7171 RVA: 0x00148B50 File Offset: 0x00146D50
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

	// Token: 0x06001C04 RID: 7172 RVA: 0x00148C3C File Offset: 0x00146E3C
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
					SceneManager.LoadScene("CalendarScene");
				}
			}
		}
		if (this.Phase > 1)
		{
			this.RivalHead.transform.localPosition = Vector3.Lerp(this.RivalHead.transform.localPosition, new Vector3((float)(-500 + DatingGlobals.RivalSabotaged * 200), 0f, 0f), Time.deltaTime * 10f);
		}
	}

	// Token: 0x04003164 RID: 12644
	public UILabel PercentLabel;

	// Token: 0x04003165 RID: 12645
	public UILabel Label;

	// Token: 0x04003166 RID: 12646
	public Texture[] RivalHeads;

	// Token: 0x04003167 RID: 12647
	public UITexture RivalHead;

	// Token: 0x04003168 RID: 12648
	public UISprite Darkness;

	// Token: 0x04003169 RID: 12649
	public float Timer;

	// Token: 0x0400316A RID: 12650
	public int Phase = 1;
}
