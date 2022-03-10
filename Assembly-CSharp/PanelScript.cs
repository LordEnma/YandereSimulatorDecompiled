using System;
using UnityEngine;

// Token: 0x02000391 RID: 913
public class PanelScript : MonoBehaviour
{
	// Token: 0x06001A4F RID: 6735 RVA: 0x00117650 File Offset: 0x00115850
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

	// Token: 0x04002B18 RID: 11032
	public UILabel BuildingLabel;

	// Token: 0x04002B19 RID: 11033
	public DoorBoxScript DoorBox;

	// Token: 0x04002B1A RID: 11034
	public Transform Player;

	// Token: 0x04002B1B RID: 11035
	public string Floor = string.Empty;

	// Token: 0x04002B1C RID: 11036
	public float PracticeBuildingZ;

	// Token: 0x04002B1D RID: 11037
	public float StairsZ;

	// Token: 0x04002B1E RID: 11038
	public float Floor1Height;

	// Token: 0x04002B1F RID: 11039
	public float Floor2Height;

	// Token: 0x04002B20 RID: 11040
	public float Floor3Height;
}
