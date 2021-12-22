using System;
using UnityEngine;

// Token: 0x0200038E RID: 910
public class PanelScript : MonoBehaviour
{
	// Token: 0x06001A35 RID: 6709 RVA: 0x001157A8 File Offset: 0x001139A8
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

	// Token: 0x04002AD5 RID: 10965
	public UILabel BuildingLabel;

	// Token: 0x04002AD6 RID: 10966
	public DoorBoxScript DoorBox;

	// Token: 0x04002AD7 RID: 10967
	public Transform Player;

	// Token: 0x04002AD8 RID: 10968
	public string Floor = string.Empty;

	// Token: 0x04002AD9 RID: 10969
	public float PracticeBuildingZ;

	// Token: 0x04002ADA RID: 10970
	public float StairsZ;

	// Token: 0x04002ADB RID: 10971
	public float Floor1Height;

	// Token: 0x04002ADC RID: 10972
	public float Floor2Height;

	// Token: 0x04002ADD RID: 10973
	public float Floor3Height;
}
