using System;
using UnityEngine;

// Token: 0x0200038E RID: 910
public class PanelScript : MonoBehaviour
{
	// Token: 0x06001A37 RID: 6711 RVA: 0x00115A84 File Offset: 0x00113C84
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

	// Token: 0x04002AD9 RID: 10969
	public UILabel BuildingLabel;

	// Token: 0x04002ADA RID: 10970
	public DoorBoxScript DoorBox;

	// Token: 0x04002ADB RID: 10971
	public Transform Player;

	// Token: 0x04002ADC RID: 10972
	public string Floor = string.Empty;

	// Token: 0x04002ADD RID: 10973
	public float PracticeBuildingZ;

	// Token: 0x04002ADE RID: 10974
	public float StairsZ;

	// Token: 0x04002ADF RID: 10975
	public float Floor1Height;

	// Token: 0x04002AE0 RID: 10976
	public float Floor2Height;

	// Token: 0x04002AE1 RID: 10977
	public float Floor3Height;
}
