using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003E7 RID: 999
public class RivalRejectionProgressScript : MonoBehaviour
{
	// Token: 0x06001BC2 RID: 7106 RVA: 0x001440D0 File Offset: 0x001422D0
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

	// Token: 0x06001BC3 RID: 7107 RVA: 0x001441BC File Offset: 0x001423BC
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

	// Token: 0x040030B1 RID: 12465
	public UILabel PercentLabel;

	// Token: 0x040030B2 RID: 12466
	public UILabel Label;

	// Token: 0x040030B3 RID: 12467
	public Texture[] RivalHeads;

	// Token: 0x040030B4 RID: 12468
	public UITexture RivalHead;

	// Token: 0x040030B5 RID: 12469
	public UISprite Darkness;

	// Token: 0x040030B6 RID: 12470
	public float Timer;

	// Token: 0x040030B7 RID: 12471
	public int Phase = 1;
}
