using System;
using UnityEngine;

// Token: 0x02000390 RID: 912
public class PanelScript : MonoBehaviour
{
	// Token: 0x06001A45 RID: 6725 RVA: 0x00116864 File Offset: 0x00114A64
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

	// Token: 0x04002AF2 RID: 10994
	public UILabel BuildingLabel;

	// Token: 0x04002AF3 RID: 10995
	public DoorBoxScript DoorBox;

	// Token: 0x04002AF4 RID: 10996
	public Transform Player;

	// Token: 0x04002AF5 RID: 10997
	public string Floor = string.Empty;

	// Token: 0x04002AF6 RID: 10998
	public float PracticeBuildingZ;

	// Token: 0x04002AF7 RID: 10999
	public float StairsZ;

	// Token: 0x04002AF8 RID: 11000
	public float Floor1Height;

	// Token: 0x04002AF9 RID: 11001
	public float Floor2Height;

	// Token: 0x04002AFA RID: 11002
	public float Floor3Height;
}
