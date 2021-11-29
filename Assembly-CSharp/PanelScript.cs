using System;
using UnityEngine;

// Token: 0x0200038D RID: 909
public class PanelScript : MonoBehaviour
{
	// Token: 0x06001A2D RID: 6701 RVA: 0x00114F78 File Offset: 0x00113178
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

	// Token: 0x04002AAB RID: 10923
	public UILabel BuildingLabel;

	// Token: 0x04002AAC RID: 10924
	public DoorBoxScript DoorBox;

	// Token: 0x04002AAD RID: 10925
	public Transform Player;

	// Token: 0x04002AAE RID: 10926
	public string Floor = string.Empty;

	// Token: 0x04002AAF RID: 10927
	public float PracticeBuildingZ;

	// Token: 0x04002AB0 RID: 10928
	public float StairsZ;

	// Token: 0x04002AB1 RID: 10929
	public float Floor1Height;

	// Token: 0x04002AB2 RID: 10930
	public float Floor2Height;

	// Token: 0x04002AB3 RID: 10931
	public float Floor3Height;
}
