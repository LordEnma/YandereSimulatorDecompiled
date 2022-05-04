using System;
using UnityEngine;

// Token: 0x02000393 RID: 915
public class PanelScript : MonoBehaviour
{
	// Token: 0x06001A6D RID: 6765 RVA: 0x00119194 File Offset: 0x00117394
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

	// Token: 0x04002B68 RID: 11112
	public UILabel BuildingLabel;

	// Token: 0x04002B69 RID: 11113
	public DoorBoxScript DoorBox;

	// Token: 0x04002B6A RID: 11114
	public Transform Player;

	// Token: 0x04002B6B RID: 11115
	public string Floor = string.Empty;

	// Token: 0x04002B6C RID: 11116
	public float PracticeBuildingZ;

	// Token: 0x04002B6D RID: 11117
	public float StairsZ;

	// Token: 0x04002B6E RID: 11118
	public float Floor1Height;

	// Token: 0x04002B6F RID: 11119
	public float Floor2Height;

	// Token: 0x04002B70 RID: 11120
	public float Floor3Height;
}
