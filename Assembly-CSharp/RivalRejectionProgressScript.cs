using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003E6 RID: 998
public class RivalRejectionProgressScript : MonoBehaviour
{
	// Token: 0x06001BBD RID: 7101 RVA: 0x001422E8 File Offset: 0x001404E8
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

	// Token: 0x06001BBE RID: 7102 RVA: 0x001423D4 File Offset: 0x001405D4
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

	// Token: 0x040030A2 RID: 12450
	public UILabel PercentLabel;

	// Token: 0x040030A3 RID: 12451
	public UILabel Label;

	// Token: 0x040030A4 RID: 12452
	public Texture[] RivalHeads;

	// Token: 0x040030A5 RID: 12453
	public UITexture RivalHead;

	// Token: 0x040030A6 RID: 12454
	public UISprite Darkness;

	// Token: 0x040030A7 RID: 12455
	public float Timer;

	// Token: 0x040030A8 RID: 12456
	public int Phase = 1;
}
