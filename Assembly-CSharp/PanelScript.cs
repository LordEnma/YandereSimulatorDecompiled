using System;
using UnityEngine;

// Token: 0x02000392 RID: 914
public class PanelScript : MonoBehaviour
{
	// Token: 0x06001A5F RID: 6751 RVA: 0x001187B8 File Offset: 0x001169B8
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

	// Token: 0x04002B54 RID: 11092
	public UILabel BuildingLabel;

	// Token: 0x04002B55 RID: 11093
	public DoorBoxScript DoorBox;

	// Token: 0x04002B56 RID: 11094
	public Transform Player;

	// Token: 0x04002B57 RID: 11095
	public string Floor = string.Empty;

	// Token: 0x04002B58 RID: 11096
	public float PracticeBuildingZ;

	// Token: 0x04002B59 RID: 11097
	public float StairsZ;

	// Token: 0x04002B5A RID: 11098
	public float Floor1Height;

	// Token: 0x04002B5B RID: 11099
	public float Floor2Height;

	// Token: 0x04002B5C RID: 11100
	public float Floor3Height;
}
