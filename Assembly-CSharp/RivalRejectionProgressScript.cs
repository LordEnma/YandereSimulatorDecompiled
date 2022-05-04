using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003EF RID: 1007
public class RivalRejectionProgressScript : MonoBehaviour
{
	// Token: 0x06001BFC RID: 7164 RVA: 0x00147BE0 File Offset: 0x00145DE0
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

	// Token: 0x06001BFD RID: 7165 RVA: 0x00147CCC File Offset: 0x00145ECC
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

	// Token: 0x04003147 RID: 12615
	public UILabel PercentLabel;

	// Token: 0x04003148 RID: 12616
	public UILabel Label;

	// Token: 0x04003149 RID: 12617
	public Texture[] RivalHeads;

	// Token: 0x0400314A RID: 12618
	public UITexture RivalHead;

	// Token: 0x0400314B RID: 12619
	public UISprite Darkness;

	// Token: 0x0400314C RID: 12620
	public float Timer;

	// Token: 0x0400314D RID: 12621
	public int Phase = 1;
}
