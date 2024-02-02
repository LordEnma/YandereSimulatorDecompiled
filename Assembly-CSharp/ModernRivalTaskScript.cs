using UnityEngine;

public class ModernRivalTaskScript : MonoBehaviour
{
	public PickUpScript AmaiPlatePickUp;

	public PromptScript Prompt;

	public GameObject AmaiPlate;

	public int RivalID;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f && RivalID == 12)
		{
			AmaiPlate.SetActive(value: true);
			AmaiPlatePickUp.Start();
			AmaiPlatePickUp.BePickedUp();
			base.gameObject.SetActive(value: false);
		}
	}
}
