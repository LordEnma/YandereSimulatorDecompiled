using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003E7 RID: 999
public class RivalRejectionProgressScript : MonoBehaviour
{
	// Token: 0x06001BC0 RID: 7104 RVA: 0x00143F38 File Offset: 0x00142138
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

	// Token: 0x06001BC1 RID: 7105 RVA: 0x00144024 File Offset: 0x00142224
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

	// Token: 0x040030AE RID: 12462
	public UILabel PercentLabel;

	// Token: 0x040030AF RID: 12463
	public UILabel Label;

	// Token: 0x040030B0 RID: 12464
	public Texture[] RivalHeads;

	// Token: 0x040030B1 RID: 12465
	public UITexture RivalHead;

	// Token: 0x040030B2 RID: 12466
	public UISprite Darkness;

	// Token: 0x040030B3 RID: 12467
	public float Timer;

	// Token: 0x040030B4 RID: 12468
	public int Phase = 1;
}
