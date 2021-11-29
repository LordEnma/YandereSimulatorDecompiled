using System;
using UnityEngine;

// Token: 0x020000F5 RID: 245
public class BountyMenuScript : MonoBehaviour
{
	// Token: 0x06000A5E RID: 2654 RVA: 0x0005C32F File Offset: 0x0005A52F
	private void Start()
	{
		this.DescLabel.text = this.Descriptions[this.Clock.Day];
		this.GetPortrait(this.StudentIDs[this.Clock.Day]);
	}

	// Token: 0x06000A5F RID: 2655 RVA: 0x0005C366 File Offset: 0x0005A566
	private void Update()
	{
		this.DescLabel.text = this.DescLabel.text.Replace('@', '\n');
	}

	// Token: 0x06000A60 RID: 2656 RVA: 0x0005C388 File Offset: 0x0005A588
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

	// Token: 0x04000C07 RID: 3079
	public ClockScript Clock;

	// Token: 0x04000C08 RID: 3080
	public UITexture Portrait;

	// Token: 0x04000C09 RID: 3081
	public UILabel DescLabel;

	// Token: 0x04000C0A RID: 3082
	public string[] Descriptions;

	// Token: 0x04000C0B RID: 3083
	public int[] StudentIDs;
}
