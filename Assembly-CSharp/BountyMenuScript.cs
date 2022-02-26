using System;
using UnityEngine;

// Token: 0x020000F6 RID: 246
public class BountyMenuScript : MonoBehaviour
{
	// Token: 0x06000A62 RID: 2658 RVA: 0x0005C60B File Offset: 0x0005A80B
	private void Start()
	{
		this.DescLabel.text = this.Descriptions[this.Clock.Day];
		this.GetPortrait(this.StudentIDs[this.Clock.Day]);
	}

	// Token: 0x06000A63 RID: 2659 RVA: 0x0005C642 File Offset: 0x0005A842
	private void Update()
	{
		this.DescLabel.text = this.DescLabel.text.Replace('@', '\n');
	}

	// Token: 0x06000A64 RID: 2660 RVA: 0x0005C664 File Offset: 0x0005A864
	private void GetPortrait(int ID)
	{
		WWW www = new WWW(string.Concat(new string[]
		{
			"file:///",
			Application.streamingAssetsPath,
			"/Portraits/Student_",
			ID.ToString(),
			".png"
		}));
		this.Portrait.mainTexture = www.texture;
	}

	// Token: 0x04000C0C RID: 3084
	public ClockScript Clock;

	// Token: 0x04000C0D RID: 3085
	public UITexture Portrait;

	// Token: 0x04000C0E RID: 3086
	public UILabel DescLabel;

	// Token: 0x04000C0F RID: 3087
	public string[] Descriptions;

	// Token: 0x04000C10 RID: 3088
	public int[] StudentIDs;
}
