using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003EA RID: 1002
public class RivalRejectionProgressScript : MonoBehaviour
{
	// Token: 0x06001BE1 RID: 7137 RVA: 0x00146228 File Offset: 0x00144428
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

	// Token: 0x06001BE2 RID: 7138 RVA: 0x00146314 File Offset: 0x00144514
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

	// Token: 0x04003111 RID: 12561
	public UILabel PercentLabel;

	// Token: 0x04003112 RID: 12562
	public UILabel Label;

	// Token: 0x04003113 RID: 12563
	public Texture[] RivalHeads;

	// Token: 0x04003114 RID: 12564
	public UITexture RivalHead;

	// Token: 0x04003115 RID: 12565
	public UISprite Darkness;

	// Token: 0x04003116 RID: 12566
	public float Timer;

	// Token: 0x04003117 RID: 12567
	public int Phase = 1;
}
