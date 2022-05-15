using System;
using UnityEngine;

// Token: 0x020000F7 RID: 247
public class BountyMenuScript : MonoBehaviour
{
	// Token: 0x06000A65 RID: 2661 RVA: 0x0005CE97 File Offset: 0x0005B097
	private void Start()
	{
		this.DescLabel.text = this.Descriptions[this.Clock.Day];
		this.GetPortrait(this.StudentIDs[this.Clock.Day]);
	}

	// Token: 0x06000A66 RID: 2662 RVA: 0x0005CECE File Offset: 0x0005B0CE
	private void Update()
	{
		this.DescLabel.text = this.DescLabel.text.Replace('@', '\n');
	}

	// Token: 0x06000A67 RID: 2663 RVA: 0x0005CEF0 File Offset: 0x0005B0F0
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

	// Token: 0x04000C23 RID: 3107
	public ClockScript Clock;

	// Token: 0x04000C24 RID: 3108
	public UITexture Portrait;

	// Token: 0x04000C25 RID: 3109
	public UILabel DescLabel;

	// Token: 0x04000C26 RID: 3110
	public string[] Descriptions;

	// Token: 0x04000C27 RID: 3111
	public int[] StudentIDs;
}
