using System;
using UnityEngine;

// Token: 0x02000394 RID: 916
public class PanelScript : MonoBehaviour
{
	// Token: 0x06001A74 RID: 6772 RVA: 0x00119CEC File Offset: 0x00117EEC
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

	// Token: 0x04002B81 RID: 11137
	public UILabel BuildingLabel;

	// Token: 0x04002B82 RID: 11138
	public DoorBoxScript DoorBox;

	// Token: 0x04002B83 RID: 11139
	public Transform Player;

	// Token: 0x04002B84 RID: 11140
	public string Floor = string.Empty;

	// Token: 0x04002B85 RID: 11141
	public float PracticeBuildingZ;

	// Token: 0x04002B86 RID: 11142
	public float StairsZ;

	// Token: 0x04002B87 RID: 11143
	public float Floor1Height;

	// Token: 0x04002B88 RID: 11144
	public float Floor2Height;

	// Token: 0x04002B89 RID: 11145
	public float Floor3Height;
}
