using UnityEngine;

public class PanelScript : MonoBehaviour
{
	public UILabel BuildingLabel;

	public DoorBoxScript DoorBox;

	public Transform Player;

	public string Floor = string.Empty;

	public float PracticeBuildingZ;

	public float StairsZ;

	public float Floor1Height;

	public float Floor2Height;

	public float Floor3Height;

	private void Update()
	{
		if (Player.position.z > StairsZ || Player.position.z < 0f - StairsZ)
		{
			Floor = "Stairs";
		}
		else if (Player.position.y < Floor1Height)
		{
			Floor = "First Floor";
		}
		else if (Player.position.y > Floor1Height && Player.position.y < Floor2Height)
		{
			Floor = "Second Floor";
		}
		else if (Player.position.y > Floor2Height && Player.position.y < Floor3Height)
		{
			Floor = "Third Floor";
		}
		else
		{
			Floor = "Rooftop";
		}
		if (Player.position.z < PracticeBuildingZ)
		{
			BuildingLabel.text = "Practice Building, " + Floor;
		}
		else
		{
			BuildingLabel.text = "Classroom Building, " + Floor;
		}
		DoorBox.Show = false;
	}
}
