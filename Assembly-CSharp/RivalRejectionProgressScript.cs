using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003E9 RID: 1001
public class RivalRejectionProgressScript : MonoBehaviour
{
	// Token: 0x06001BD4 RID: 7124 RVA: 0x00145384 File Offset: 0x00143584
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

	// Token: 0x06001BD5 RID: 7125 RVA: 0x00145470 File Offset: 0x00143670
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

	// Token: 0x040030DD RID: 12509
	public UILabel PercentLabel;

	// Token: 0x040030DE RID: 12510
	public UILabel Label;

	// Token: 0x040030DF RID: 12511
	public Texture[] RivalHeads;

	// Token: 0x040030E0 RID: 12512
	public UITexture RivalHead;

	// Token: 0x040030E1 RID: 12513
	public UISprite Darkness;

	// Token: 0x040030E2 RID: 12514
	public float Timer;

	// Token: 0x040030E3 RID: 12515
	public int Phase = 1;
}
