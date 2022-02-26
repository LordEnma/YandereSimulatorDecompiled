using System;
using UnityEngine;

// Token: 0x02000391 RID: 913
public class PanelScript : MonoBehaviour
{
	// Token: 0x06001A4E RID: 6734 RVA: 0x00117278 File Offset: 0x00115478
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

	// Token: 0x04002B02 RID: 11010
	public UILabel BuildingLabel;

	// Token: 0x04002B03 RID: 11011
	public DoorBoxScript DoorBox;

	// Token: 0x04002B04 RID: 11012
	public Transform Player;

	// Token: 0x04002B05 RID: 11013
	public string Floor = string.Empty;

	// Token: 0x04002B06 RID: 11014
	public float PracticeBuildingZ;

	// Token: 0x04002B07 RID: 11015
	public float StairsZ;

	// Token: 0x04002B08 RID: 11016
	public float Floor1Height;

	// Token: 0x04002B09 RID: 11017
	public float Floor2Height;

	// Token: 0x04002B0A RID: 11018
	public float Floor3Height;
}
