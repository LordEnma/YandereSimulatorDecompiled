using System;
using UnityEngine;

// Token: 0x02000394 RID: 916
public class PanelScript : MonoBehaviour
{
	// Token: 0x06001A73 RID: 6771 RVA: 0x00119ABC File Offset: 0x00117CBC
	private void Update()
	{
		if (this.Player.position.z > this.StairsZ || this.Player.position.z < -this.StairsZ)
		{
			this.Floor = "Stairs";
		}
		else if (this.Player.position.y < this.Floor1Height)
		{
			this.Floor = "First Floor";
		}
		else if (this.Player.position.y > this.Floor1Height && this.Player.position.y < this.Floor2Height)
		{
			this.Floor = "Second Floor";
		}
		else if (this.Player.position.y > this.Floor2Height && this.Player.position.y < this.Floor3Height)
		{
			this.Floor = "Third Floor";
		}
		else
		{
			this.Floor = "Rooftop";
		}
		if (this.Player.position.z < this.PracticeBuildingZ)
		{
			this.BuildingLabel.text = "Practice Building, " + this.Floor;
		}
		else
		{
			this.BuildingLabel.text = "Classroom Building, " + this.Floor;
		}
		this.DoorBox.Show = false;
	}

	// Token: 0x04002B7A RID: 11130
	public UILabel BuildingLabel;

	// Token: 0x04002B7B RID: 11131
	public DoorBoxScript DoorBox;

	// Token: 0x04002B7C RID: 11132
	public Transform Player;

	// Token: 0x04002B7D RID: 11133
	public string Floor = string.Empty;

	// Token: 0x04002B7E RID: 11134
	public float PracticeBuildingZ;

	// Token: 0x04002B7F RID: 11135
	public float StairsZ;

	// Token: 0x04002B80 RID: 11136
	public float Floor1Height;

	// Token: 0x04002B81 RID: 11137
	public float Floor2Height;

	// Token: 0x04002B82 RID: 11138
	public float Floor3Height;
}
