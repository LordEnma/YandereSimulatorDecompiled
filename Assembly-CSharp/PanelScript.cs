using System;
using UnityEngine;

// Token: 0x02000391 RID: 913
public class PanelScript : MonoBehaviour
{
	// Token: 0x06001A59 RID: 6745 RVA: 0x00118160 File Offset: 0x00116360
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

	// Token: 0x04002B41 RID: 11073
	public UILabel BuildingLabel;

	// Token: 0x04002B42 RID: 11074
	public DoorBoxScript DoorBox;

	// Token: 0x04002B43 RID: 11075
	public Transform Player;

	// Token: 0x04002B44 RID: 11076
	public string Floor = string.Empty;

	// Token: 0x04002B45 RID: 11077
	public float PracticeBuildingZ;

	// Token: 0x04002B46 RID: 11078
	public float StairsZ;

	// Token: 0x04002B47 RID: 11079
	public float Floor1Height;

	// Token: 0x04002B48 RID: 11080
	public float Floor2Height;

	// Token: 0x04002B49 RID: 11081
	public float Floor3Height;
}
