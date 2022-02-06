using System;
using UnityEngine;

// Token: 0x0200038F RID: 911
public class PanelScript : MonoBehaviour
{
	// Token: 0x06001A3E RID: 6718 RVA: 0x00116540 File Offset: 0x00114740
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

	// Token: 0x04002AEC RID: 10988
	public UILabel BuildingLabel;

	// Token: 0x04002AED RID: 10989
	public DoorBoxScript DoorBox;

	// Token: 0x04002AEE RID: 10990
	public Transform Player;

	// Token: 0x04002AEF RID: 10991
	public string Floor = string.Empty;

	// Token: 0x04002AF0 RID: 10992
	public float PracticeBuildingZ;

	// Token: 0x04002AF1 RID: 10993
	public float StairsZ;

	// Token: 0x04002AF2 RID: 10994
	public float Floor1Height;

	// Token: 0x04002AF3 RID: 10995
	public float Floor2Height;

	// Token: 0x04002AF4 RID: 10996
	public float Floor3Height;
}
