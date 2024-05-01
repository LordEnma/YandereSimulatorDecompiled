using UnityEngine;

public class BountyMenuScript : MonoBehaviour
{
	public ClockScript Clock;

	public UITexture Portrait;

	public UILabel DescLabel;

	public string[] Descriptions;

	public int[] StudentIDs;

	private void Start()
	{
		DescLabel.text = Descriptions[Clock.GameplayDay];
		GetPortrait(StudentIDs[Clock.GameplayDay]);
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
