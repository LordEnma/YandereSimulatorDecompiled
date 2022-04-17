using System;
using UnityEngine;

// Token: 0x02000393 RID: 915
public class PanelScript : MonoBehaviour
{
	// Token: 0x06001A69 RID: 6761 RVA: 0x00118C2C File Offset: 0x00116E2C
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

	// Token: 0x04002B5F RID: 11103
	public UILabel BuildingLabel;

	// Token: 0x04002B60 RID: 11104
	public DoorBoxScript DoorBox;

	// Token: 0x04002B61 RID: 11105
	public Transform Player;

	// Token: 0x04002B62 RID: 11106
	public string Floor = string.Empty;

	// Token: 0x04002B63 RID: 11107
	public float PracticeBuildingZ;

	// Token: 0x04002B64 RID: 11108
	public float StairsZ;

	// Token: 0x04002B65 RID: 11109
	public float Floor1Height;

	// Token: 0x04002B66 RID: 11110
	public float Floor2Height;

	// Token: 0x04002B67 RID: 11111
	public float Floor3Height;
}
