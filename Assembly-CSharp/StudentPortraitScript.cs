using UnityEngine;

public class StudentPortraitScript : MonoBehaviour
{
	public GameObject DeathShadow;

	public GameObject PrisonBars;

	public GameObject Panties;

	public GameObject Friend;

	public UITexture Portrait;

	private void Start()
	{
		DeathShadow.SetActive(value: false);
		PrisonBars.SetActive(value: false);
		Panties.SetActive(value: false);
		Friend.SetActive(value: false);
	}
}
