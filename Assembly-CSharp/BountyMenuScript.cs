using UnityEngine;

public class BountyMenuScript : MonoBehaviour
{
	public ClockScript Clock;

	public UITexture Portrait;

	public UILabel DescLabel;

	public string[] Descriptions;

	public int[] StudentIDs;

	public Texture InfoChan;

	private void Start()
	{
		DescLabel.text = Descriptions[Clock.GameplayDay];
		GetPortrait(StudentIDs[Clock.GameplayDay]);
		if ((Clock.GameplayDay == 2 && Clock.StudentManager.Students[11] == null) || Clock.StudentManager.Students[StudentIDs[Clock.GameplayDay]] == null)
		{
			DescLabel.text = "Sorry, I have no bounty available for you today.";
			Portrait.mainTexture = InfoChan;
		}
	}

	private void Update()
	{
		DescLabel.text = DescLabel.text.Replace('@', '\n');
	}

	private void GetPortrait(int ID)
	{
		WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + ID + ".png");
		Portrait.mainTexture = wWW.texture;
	}
}
