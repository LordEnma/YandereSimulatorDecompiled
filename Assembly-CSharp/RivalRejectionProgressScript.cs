using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003E4 RID: 996
public class RivalRejectionProgressScript : MonoBehaviour
{
	// Token: 0x06001BB6 RID: 7094 RVA: 0x00141F74 File Offset: 0x00140174
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

	// Token: 0x06001BB7 RID: 7095 RVA: 0x00142060 File Offset: 0x00140260
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

	// Token: 0x0400309C RID: 12444
	public UILabel PercentLabel;

	// Token: 0x0400309D RID: 12445
	public UILabel Label;

	// Token: 0x0400309E RID: 12446
	public Texture[] RivalHeads;

	// Token: 0x0400309F RID: 12447
	public UITexture RivalHead;

	// Token: 0x040030A0 RID: 12448
	public UISprite Darkness;

	// Token: 0x040030A1 RID: 12449
	public float Timer;

	// Token: 0x040030A2 RID: 12450
	public int Phase = 1;
}
