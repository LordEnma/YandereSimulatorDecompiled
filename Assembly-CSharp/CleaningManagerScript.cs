using System;
using UnityEngine;

// Token: 0x0200024B RID: 587
public class CleaningManagerScript : MonoBehaviour
{
	// Token: 0x06001265 RID: 4709 RVA: 0x0008E718 File Offset: 0x0008C918
	private void Start()
	{
		if (SchoolGlobals.RoofFence)
		{
			for (int i = 1; i < this.ClappingSpots.Length; i++)
			{
				this.ClappingSpots[i].transform.position = new Vector3(this.ClappingSpots[i].transform.position.x, this.ClappingSpots[i].transform.position.y, this.ClappingSpots[i].transform.position.z + 0.5f);
			}
		}
		this.Eighties = GameGlobals.Eighties;
	}

	// Token: 0x06001266 RID: 4710 RVA: 0x0008E7AC File Offset: 0x0008C9AC
	public void GetRole(int StudentID)
	{
		switch (StudentID)
		{
		case 1:
			this.Role = 4;
			this.Spot = this.Toilets[0];
			return;
		case 2:
			this.Role = 1;
			this.Spot = this.Windows[4];
			return;
		case 3:
			this.Role = 2;
			this.Spot = this.Desks[4];
			return;
		case 4:
			this.Role = 3;
			this.Spot = this.Floors[4];
			return;
		case 5:
			this.Role = 5;
			this.Spot = this.Rooftops[4];
			return;
		case 6:
			this.Role = 3;
			this.Spot = this.Floors[12];
			return;
		case 7:
			this.Role = 3;
			this.Spot = this.Floors[13];
			return;
		case 8:
			this.Role = 3;
			this.Spot = this.Floors[14];
			return;
		case 9:
			this.Role = 3;
			this.Spot = this.Floors[15];
			return;
		case 10:
			if (this.Eighties)
			{
				this.Role = 3;
				this.Spot = this.Floors[45];
				return;
			}
			if (this.StudentManager.Students[11] != null)
			{
				this.Role = 3;
				this.Spot = this.StudentManager.Students[11].transform;
				return;
			}
			break;
		case 11:
			this.Role = 3;
			this.Spot = this.Floors[35];
			return;
		case 12:
			this.Role = 3;
			this.Spot = this.Floors[36];
			return;
		case 13:
			this.Role = 3;
			this.Spot = this.Floors[37];
			return;
		case 14:
			this.Role = 3;
			this.Spot = this.Floors[38];
			return;
		case 15:
			this.Role = 3;
			this.Spot = this.Floors[39];
			return;
		case 16:
			this.Role = 3;
			this.Spot = this.Floors[40];
			return;
		case 17:
			this.Role = 3;
			this.Spot = this.Floors[41];
			return;
		case 18:
			this.Role = 3;
			this.Spot = this.Floors[42];
			return;
		case 19:
			this.Role = 3;
			this.Spot = this.Floors[43];
			return;
		case 20:
			this.Role = 3;
			this.Spot = this.Floors[44];
			return;
		case 21:
			this.Role = 1;
			this.Spot = this.Windows[6];
			return;
		case 22:
			this.Role = 1;
			this.Spot = this.Windows[5];
			return;
		case 23:
			this.Role = 1;
			this.Spot = this.Windows[3];
			return;
		case 24:
			this.Role = 1;
			this.Spot = this.Windows[2];
			return;
		case 25:
			this.Role = 1;
			this.Spot = this.Windows[1];
			return;
		case 26:
			this.Role = 2;
			this.Spot = this.Desks[6];
			return;
		case 27:
			this.Role = 2;
			this.Spot = this.Desks[5];
			return;
		case 28:
			this.Role = 2;
			this.Spot = this.Desks[3];
			return;
		case 29:
			this.Role = 2;
			this.Spot = this.Desks[2];
			return;
		case 30:
			this.Role = 2;
			this.Spot = this.Desks[1];
			return;
		case 31:
			this.Role = 3;
			this.Spot = this.Floors[6];
			return;
		case 32:
			this.Role = 3;
			this.Spot = this.Floors[5];
			return;
		case 33:
			this.Role = 3;
			this.Spot = this.Floors[3];
			return;
		case 34:
			this.Role = 3;
			this.Spot = this.Floors[2];
			return;
		case 35:
			this.Role = 3;
			this.Spot = this.Floors[1];
			return;
		case 36:
			this.Role = 3;
			this.Spot = this.Floors[7];
			return;
		case 37:
			this.Role = 3;
			this.Spot = this.Floors[8];
			return;
		case 38:
			this.Role = 3;
			this.Spot = this.Floors[9];
			return;
		case 39:
			this.Role = 3;
			this.Spot = this.Floors[10];
			return;
		case 40:
			this.Role = 3;
			this.Spot = this.Floors[11];
			return;
		case 41:
			this.Role = 5;
			this.Spot = this.Rooftops[6];
			return;
		case 42:
			this.Role = 5;
			this.Spot = this.Rooftops[5];
			return;
		case 43:
			this.Role = 5;
			this.Spot = this.Rooftops[3];
			return;
		case 44:
			this.Role = 5;
			this.Spot = this.Rooftops[2];
			return;
		case 45:
			this.Role = 5;
			this.Spot = this.Rooftops[1];
			return;
		case 46:
			this.Role = 4;
			this.Spot = this.Toilets[1];
			return;
		case 47:
			this.Role = 4;
			this.Spot = this.Toilets[2];
			return;
		case 48:
			this.Role = 4;
			this.Spot = this.Toilets[3];
			return;
		case 49:
			this.Role = 3;
			this.Spot = this.Floors[16];
			return;
		case 50:
			this.Role = 3;
			this.Spot = this.Floors[17];
			return;
		case 51:
			this.Role = 4;
			this.Spot = this.Toilets[7];
			return;
		case 52:
			this.Role = 4;
			this.Spot = this.Toilets[8];
			return;
		case 53:
			this.Role = 4;
			this.Spot = this.Toilets[9];
			return;
		case 54:
			this.Role = 4;
			this.Spot = this.Toilets[10];
			return;
		case 55:
			this.Role = 4;
			this.Spot = this.Toilets[11];
			return;
		case 56:
			this.Role = 4;
			this.Spot = this.Toilets[4];
			return;
		case 57:
			this.Role = 4;
			this.Spot = this.Toilets[5];
			return;
		case 58:
			this.Role = 4;
			this.Spot = this.Toilets[6];
			return;
		case 59:
			this.Role = 3;
			this.Spot = this.Floors[18];
			return;
		case 60:
			this.Role = 3;
			this.Spot = this.Floors[19];
			return;
		case 61:
			this.Role = 3;
			this.Spot = this.Floors[20];
			return;
		case 62:
			this.Role = 3;
			this.Spot = this.Floors[21];
			return;
		case 63:
			this.Role = 3;
			this.Spot = this.Floors[22];
			return;
		case 64:
			this.Role = 3;
			this.Spot = this.Floors[23];
			return;
		case 65:
			this.Role = 3;
			this.Spot = this.Floors[24];
			return;
		case 66:
			this.Role = 3;
			this.Spot = this.Floors[25];
			return;
		case 67:
			this.Role = 3;
			this.Spot = this.Floors[26];
			return;
		case 68:
			this.Role = 3;
			this.Spot = this.Floors[27];
			return;
		case 69:
			this.Role = 3;
			this.Spot = this.Floors[28];
			return;
		case 70:
			this.Role = 3;
			this.Spot = this.Floors[29];
			return;
		case 71:
			this.Role = 3;
			this.Spot = this.Floors[30];
			return;
		case 72:
			this.Role = 3;
			this.Spot = this.Floors[31];
			return;
		case 73:
			this.Role = 3;
			this.Spot = this.Floors[32];
			return;
		case 74:
			this.Role = 3;
			this.Spot = this.Floors[33];
			return;
		case 75:
			this.Role = 3;
			this.Spot = this.Floors[34];
			break;
		default:
			return;
		}
	}

	// Token: 0x04001774 RID: 6004
	public StudentManagerScript StudentManager;

	// Token: 0x04001775 RID: 6005
	public Transform[] Windows;

	// Token: 0x04001776 RID: 6006
	public Transform[] Desks;

	// Token: 0x04001777 RID: 6007
	public Transform[] Floors;

	// Token: 0x04001778 RID: 6008
	public Transform[] Toilets;

	// Token: 0x04001779 RID: 6009
	public Transform[] Rooftops;

	// Token: 0x0400177A RID: 6010
	public Transform[] ClappingSpots;

	// Token: 0x0400177B RID: 6011
	public Transform Spot;

	// Token: 0x0400177C RID: 6012
	public bool Eighties;

	// Token: 0x0400177D RID: 6013
	public int Role;
}
