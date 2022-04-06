using System;
using UnityEngine;

// Token: 0x02000393 RID: 915
public class PanelScript : MonoBehaviour
{
	// Token: 0x06001A65 RID: 6757 RVA: 0x00118924 File Offset: 0x00116B24
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

	// Token: 0x04002B57 RID: 11095
	public UILabel BuildingLabel;

	// Token: 0x04002B58 RID: 11096
	public DoorBoxScript DoorBox;

	// Token: 0x04002B59 RID: 11097
	public Transform Player;

	// Token: 0x04002B5A RID: 11098
	public string Floor = string.Empty;

	// Token: 0x04002B5B RID: 11099
	public float PracticeBuildingZ;

	// Token: 0x04002B5C RID: 11100
	public float StairsZ;

	// Token: 0x04002B5D RID: 11101
	public float Floor1Height;

	// Token: 0x04002B5E RID: 11102
	public float Floor2Height;

	// Token: 0x04002B5F RID: 11103
	public float Floor3Height;
}
