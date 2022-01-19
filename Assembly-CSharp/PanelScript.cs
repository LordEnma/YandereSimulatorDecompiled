using System;
using UnityEngine;

// Token: 0x0200038F RID: 911
public class PanelScript : MonoBehaviour
{
	// Token: 0x06001A3B RID: 6715 RVA: 0x00115F28 File Offset: 0x00114128
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

	// Token: 0x04002AE2 RID: 10978
	public UILabel BuildingLabel;

	// Token: 0x04002AE3 RID: 10979
	public DoorBoxScript DoorBox;

	// Token: 0x04002AE4 RID: 10980
	public Transform Player;

	// Token: 0x04002AE5 RID: 10981
	public string Floor = string.Empty;

	// Token: 0x04002AE6 RID: 10982
	public float PracticeBuildingZ;

	// Token: 0x04002AE7 RID: 10983
	public float StairsZ;

	// Token: 0x04002AE8 RID: 10984
	public float Floor1Height;

	// Token: 0x04002AE9 RID: 10985
	public float Floor2Height;

	// Token: 0x04002AEA RID: 10986
	public float Floor3Height;
}
