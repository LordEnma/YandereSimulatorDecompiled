using UnityEngine;

public class StudentPortraitScript : MonoBehaviour
{
	public GameObject FuneralFrame;

	public GameObject PrisonBars;

	public GameObject Darkness;

	public GameObject Panties;

	public GameObject Friend;

	public UITexture Portrait;

	private void Start()
	{
		FuneralFrame.SetActive(value: false);
		PrisonBars.SetActive(value: false);
		Darkness.SetActive(value: false);
		Panties.SetActive(value: false);
		Friend.SetActive(value: false);
	}
}
