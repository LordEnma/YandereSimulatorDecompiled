using UnityEngine;

public class CleaningManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public Transform[] Windows;

	public Transform[] Desks;

	public Transform[] Floors;

	public Transform[] Toilets;

	public Transform[] Rooftops;

	public Transform[] ClappingSpots;

	public Transform Spot;

	public bool Eighties;

	public int Role;

	private void Start()
	{
		if (SchoolGlobals.RoofFence)
		{
			for (int i = 1; i < ClappingSpots.Length; i++)
			{
				ClappingSpots[i].transform.position = new Vector3(ClappingSpots[i].transform.position.x, ClappingSpots[i].transform.position.y, ClappingSpots[i].transform.position.z + 0.5f);
			}
		}
		Eighties = GameGlobals.Eighties;
	}

	public void GetRole(int StudentID)
	{
		switch (StudentID)
		{
		case 1:
			Role = 4;
			Spot = Toilets[0];
			break;
		case 11:
			Role = 3;
			Spot = Floors[35];
			break;
		case 12:
			Role = 3;
			Spot = Floors[36];
			break;
		case 13:
			Role = 3;
			Spot = Floors[37];
			break;
		case 14:
			Role = 3;
			Spot = Floors[38];
			break;
		case 15:
			Role = 3;
			Spot = Floors[39];
			break;
		case 16:
			Role = 3;
			Spot = Floors[40];
			break;
		case 17:
			Role = 3;
			Spot = Floors[41];
			break;
		case 18:
			Role = 3;
			Spot = Floors[42];
			break;
		case 19:
			Role = 3;
			Spot = Floors[43];
			break;
		case 20:
			Role = 3;
			Spot = Floors[44];
			break;
		case 2:
			Role = 1;
			Spot = Windows[4];
			break;
		case 21:
			Role = 1;
			Spot = Windows[6];
			break;
		case 22:
			Role = 1;
			Spot = Windows[5];
			break;
		case 23:
			Role = 1;
			Spot = Windows[3];
			break;
		case 24:
			Role = 1;
			Spot = Windows[2];
			break;
		case 25:
			Role = 1;
			Spot = Windows[1];
			break;
		case 3:
			Role = 2;
			Spot = Desks[4];
			break;
		case 26:
			Role = 2;
			Spot = Desks[6];
			break;
		case 27:
			Role = 2;
			Spot = Desks[5];
			break;
		case 28:
			Role = 2;
			Spot = Desks[3];
			break;
		case 29:
			Role = 2;
			Spot = Desks[2];
			break;
		case 30:
			Role = 2;
			Spot = Desks[1];
			break;
		case 4:
			Role = 3;
			Spot = Floors[4];
			break;
		case 31:
			Role = 3;
			Spot = Floors[6];
			break;
		case 32:
			Role = 3;
			Spot = Floors[5];
			break;
		case 33:
			Role = 3;
			Spot = Floors[3];
			break;
		case 34:
			Role = 3;
			Spot = Floors[2];
			break;
		case 35:
			Role = 3;
			Spot = Floors[1];
			break;
		case 36:
			Role = 3;
			Spot = Floors[7];
			break;
		case 37:
			Role = 3;
			Spot = Floors[8];
			break;
		case 38:
			Role = 3;
			Spot = Floors[9];
			break;
		case 39:
			Role = 3;
			Spot = Floors[10];
			break;
		case 40:
			Role = 3;
			Spot = Floors[11];
			break;
		case 5:
			Role = 5;
			Spot = Rooftops[4];
			break;
		case 41:
			Role = 5;
			Spot = Rooftops[6];
			break;
		case 42:
			Role = 5;
			Spot = Rooftops[5];
			break;
		case 43:
			Role = 5;
			Spot = Rooftops[3];
			break;
		case 44:
			Role = 5;
			Spot = Rooftops[2];
			break;
		case 45:
			Role = 5;
			Spot = Rooftops[1];
			break;
		case 46:
			Role = 4;
			Spot = Toilets[1];
			break;
		case 47:
			Role = 4;
			Spot = Toilets[2];
			break;
		case 48:
			Role = 4;
			Spot = Toilets[3];
			break;
		case 56:
			Role = 4;
			Spot = Toilets[4];
			break;
		case 57:
			Role = 4;
			Spot = Toilets[5];
			break;
		case 58:
			Role = 4;
			Spot = Toilets[6];
			break;
		case 51:
			Role = 4;
			Spot = Toilets[7];
			break;
		case 52:
			Role = 4;
			Spot = Toilets[8];
			break;
		case 53:
			Role = 4;
			Spot = Toilets[9];
			break;
		case 54:
			Role = 4;
			Spot = Toilets[10];
			break;
		case 55:
			Role = 4;
			Spot = Toilets[11];
			break;
		case 6:
			Role = 3;
			Spot = Floors[12];
			break;
		case 7:
			Role = 3;
			Spot = Floors[13];
			break;
		case 8:
			Role = 3;
			Spot = Floors[14];
			break;
		case 9:
			Role = 3;
			Spot = Floors[15];
			break;
		case 10:
			if (!Eighties)
			{
				if (StudentManager.Students[11] != null)
				{
					Role = 3;
					Spot = StudentManager.Students[11].transform;
				}
			}
			else
			{
				Role = 3;
				Spot = Floors[45];
			}
			break;
		case 49:
			Role = 3;
			Spot = Floors[16];
			break;
		case 50:
			Role = 3;
			Spot = Floors[17];
			break;
		case 59:
			Role = 3;
			Spot = Floors[18];
			break;
		case 60:
			Role = 3;
			Spot = Floors[19];
			break;
		case 61:
			Role = 3;
			Spot = Floors[20];
			break;
		case 62:
			Role = 3;
			Spot = Floors[21];
			break;
		case 63:
			Role = 3;
			Spot = Floors[22];
			break;
		case 64:
			Role = 3;
			Spot = Floors[23];
			break;
		case 65:
			Role = 3;
			Spot = Floors[24];
			break;
		case 66:
			Role = 3;
			Spot = Floors[25];
			break;
		case 67:
			Role = 3;
			Spot = Floors[26];
			break;
		case 68:
			Role = 3;
			Spot = Floors[27];
			break;
		case 69:
			Role = 3;
			Spot = Floors[28];
			break;
		case 70:
			Role = 3;
			Spot = Floors[29];
			break;
		case 71:
			Role = 3;
			Spot = Floors[30];
			break;
		case 72:
			Role = 3;
			Spot = Floors[31];
			break;
		case 73:
			Role = 3;
			Spot = Floors[32];
			break;
		case 74:
			Role = 3;
			Spot = Floors[33];
			break;
		case 75:
			Role = 3;
			Spot = Floors[34];
			break;
		}
	}
}
