using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003E4 RID: 996
public class RivalRejectionProgressScript : MonoBehaviour
{
	// Token: 0x06001BB4 RID: 7092 RVA: 0x00141B78 File Offset: 0x0013FD78
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

	// Token: 0x06001BB5 RID: 7093 RVA: 0x00141C64 File Offset: 0x0013FE64
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

	// Token: 0x04003095 RID: 12437
	public UILabel PercentLabel;

	// Token: 0x04003096 RID: 12438
	public UILabel Label;

	// Token: 0x04003097 RID: 12439
	public Texture[] RivalHeads;

	// Token: 0x04003098 RID: 12440
	public UITexture RivalHead;

	// Token: 0x04003099 RID: 12441
	public UISprite Darkness;

	// Token: 0x0400309A RID: 12442
	public float Timer;

	// Token: 0x0400309B RID: 12443
	public int Phase = 1;
}
