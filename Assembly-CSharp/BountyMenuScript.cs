using System;
using UnityEngine;

// Token: 0x020000F6 RID: 246
public class BountyMenuScript : MonoBehaviour
{
	// Token: 0x06000A62 RID: 2658 RVA: 0x0005C753 File Offset: 0x0005A953
	private void Start()
	{
		this.DescLabel.text = this.Descriptions[this.Clock.Day];
		this.GetPortrait(this.StudentIDs[this.Clock.Day]);
	}

	// Token: 0x06000A63 RID: 2659 RVA: 0x0005C78A File Offset: 0x0005A98A
	private void Update()
	{
		this.DescLabel.text = this.DescLabel.text.Replace('@', '\n');
	}

	// Token: 0x06000A64 RID: 2660 RVA: 0x0005C7AC File Offset: 0x0005A9AC
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

	// Token: 0x04000C15 RID: 3093
	public ClockScript Clock;

	// Token: 0x04000C16 RID: 3094
	public UITexture Portrait;

	// Token: 0x04000C17 RID: 3095
	public UILabel DescLabel;

	// Token: 0x04000C18 RID: 3096
	public string[] Descriptions;

	// Token: 0x04000C19 RID: 3097
	public int[] StudentIDs;
}
