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
		DeathShadow.SetActive(false);
		PrisonBars.SetActive(false);
		Panties.SetActive(false);
		Friend.SetActive(false);
	}
}
