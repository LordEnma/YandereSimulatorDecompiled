using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003E7 RID: 999
public class RivalRejectionProgressScript : MonoBehaviour
{
	// Token: 0x06001BBF RID: 7103 RVA: 0x001439F0 File Offset: 0x00141BF0
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

	// Token: 0x06001BC0 RID: 7104 RVA: 0x00143ADC File Offset: 0x00141CDC
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

	// Token: 0x040030A7 RID: 12455
	public UILabel PercentLabel;

	// Token: 0x040030A8 RID: 12456
	public UILabel Label;

	// Token: 0x040030A9 RID: 12457
	public Texture[] RivalHeads;

	// Token: 0x040030AA RID: 12458
	public UITexture RivalHead;

	// Token: 0x040030AB RID: 12459
	public UISprite Darkness;

	// Token: 0x040030AC RID: 12460
	public float Timer;

	// Token: 0x040030AD RID: 12461
	public int Phase = 1;
}
