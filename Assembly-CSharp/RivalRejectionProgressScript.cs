using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003E8 RID: 1000
public class RivalRejectionProgressScript : MonoBehaviour
{
	// Token: 0x06001BC9 RID: 7113 RVA: 0x001443D0 File Offset: 0x001425D0
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

	// Token: 0x06001BCA RID: 7114 RVA: 0x001444BC File Offset: 0x001426BC
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

	// Token: 0x040030B7 RID: 12471
	public UILabel PercentLabel;

	// Token: 0x040030B8 RID: 12472
	public UILabel Label;

	// Token: 0x040030B9 RID: 12473
	public Texture[] RivalHeads;

	// Token: 0x040030BA RID: 12474
	public UITexture RivalHead;

	// Token: 0x040030BB RID: 12475
	public UISprite Darkness;

	// Token: 0x040030BC RID: 12476
	public float Timer;

	// Token: 0x040030BD RID: 12477
	public int Phase = 1;
}
