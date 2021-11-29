using System;
using UnityEngine;

// Token: 0x020000F6 RID: 246
public class BringItemScript : MonoBehaviour
{
	// Token: 0x06000A62 RID: 2658 RVA: 0x0005C3EC File Offset: 0x0005A5EC
	private void Start()
	{
		for (int i = 1; i < 8; i++)
		{
			if (PlayerGlobals.GetCannotBringItem(i))
			{
				this.Labels[i].color = new Color(1f, 1f, 1f, 0.5f);
			}
			else
			{
				this.Labels[i].color = new Color(1f, 1f, 1f, 1f);
			}
		}
		if (PlayerGlobals.BringingItem != 0)
		{
			this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 50f - (float)PlayerGlobals.BringingItem * 50f, this.Highlight.localPosition.z);
			this.Checkmark.transform.localPosition = new Vector3(300f, this.Highlight.localPosition.y, 0f);
			this.Checkmark.SetActive(true);
		}
		if (PlayerGlobals.BoughtLockpick)
		{
			this.Labels[8].alpha = 1f;
		}
		if (PlayerGlobals.BoughtSedative)
		{
			this.Labels[9].alpha = 1f;
		}
		if (PlayerGlobals.BoughtNarcotics)
		{
			this.Labels[10].alpha = 1f;
		}
		if (PlayerGlobals.BoughtPoison)
		{
			this.Labels[11].alpha = 1f;
		}
		if (PlayerGlobals.BoughtExplosive)
		{
			this.Labels[12].alpha = 1f;
		}
		this.DescLabel.text = this.Descriptions[this.ID];
	}

	// Token: 0x06000A63 RID: 2659 RVA: 0x0005C578 File Offset: 0x0005A778
	private void Update()
	{
		if (this.HomeWindow.Sprite.color.a > 0.9f)
		{
			if (this.InputManager.TappedDown)
			{
				this.ID++;
				if (this.ID > this.Limit)
				{
					this.ID = 1;
				}
				this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 50f - (float)this.ID * 50f, this.Highlight.localPosition.z);
				this.DescLabel.text = this.Descriptions[this.ID];
			}
			if (this.InputManager.TappedUp)
			{
				this.ID--;
				if (this.ID < 1)
				{
					this.ID = this.Limit;
				}
				this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 50f - (float)this.ID * 50f, this.Highlight.localPosition.z);
				this.DescLabel.text = this.Descriptions[this.ID];
			}
			if (Input.GetButtonDown("A") && this.Labels[this.ID].color.a == 1f)
			{
				if (PlayerGlobals.BringingItem != this.ID)
				{
					this.Checkmark.transform.localPosition = new Vector3(300f, this.Highlight.localPosition.y, 0f);
					this.Checkmark.SetActive(true);
					PlayerGlobals.BringingItem = this.ID;
				}
				else
				{
					this.Checkmark.SetActive(false);
					PlayerGlobals.BringingItem = 0;
				}
			}
			if (Input.GetButtonDown("B"))
			{
				this.HomeExit.HomeWindow.Show = true;
				this.HomeWindow.Show = false;
			}
			if (Input.GetButtonDown("X"))
			{
				this.HomeExit.HomeWindow.Show = true;
				this.HomeWindow.Show = false;
				this.HomeExit.GoToSchool();
			}
		}
	}

	// Token: 0x04000C0C RID: 3084
	public InputManagerScript InputManager;

	// Token: 0x04000C0D RID: 3085
	public HomeWindowScript HomeWindow;

	// Token: 0x04000C0E RID: 3086
	public HomeExitScript HomeExit;

	// Token: 0x04000C0F RID: 3087
	public string[] Descriptions;

	// Token: 0x04000C10 RID: 3088
	public GameObject Checkmark;

	// Token: 0x04000C11 RID: 3089
	public Transform Highlight;

	// Token: 0x04000C12 RID: 3090
	public UILabel DescLabel;

	// Token: 0x04000C13 RID: 3091
	public UILabel[] Labels;

	// Token: 0x04000C14 RID: 3092
	public int Limit = 12;

	// Token: 0x04000C15 RID: 3093
	public int ID = 1;
}
