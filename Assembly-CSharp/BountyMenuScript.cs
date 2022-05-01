using System;
using UnityEngine;

// Token: 0x020000F6 RID: 246
public class BountyMenuScript : MonoBehaviour
{
	// Token: 0x06000A63 RID: 2659 RVA: 0x0005CB5B File Offset: 0x0005AD5B
	private void Start()
	{
		this.DescLabel.text = this.Descriptions[this.Clock.Day];
		this.GetPortrait(this.StudentIDs[this.Clock.Day]);
	}

	// Token: 0x06000A64 RID: 2660 RVA: 0x0005CB92 File Offset: 0x0005AD92
	private void Update()
	{
		this.DescLabel.text = this.DescLabel.text.Replace('@', '\n');
	}

	// Token: 0x06000A65 RID: 2661 RVA: 0x0005CBB4 File Offset: 0x0005ADB4
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

	// Token: 0x04000C1E RID: 3102
	public ClockScript Clock;

	// Token: 0x04000C1F RID: 3103
	public UITexture Portrait;

	// Token: 0x04000C20 RID: 3104
	public UILabel DescLabel;

	// Token: 0x04000C21 RID: 3105
	public string[] Descriptions;

	// Token: 0x04000C22 RID: 3106
	public int[] StudentIDs;
}
