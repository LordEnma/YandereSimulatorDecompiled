using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
	public GameObject BlackScreen;

	public GameObject Disclaimer;

	public GameObject NiceBoat;

	public int Mode;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.N))
		{
			Mode++;
			if (Mode == 4)
			{
				Mode = 1;
			}
			if (Mode == 1)
			{
				BlackScreen.SetActive(value: true);
				Disclaimer.SetActive(value: false);
				NiceBoat.SetActive(value: false);
			}
			else if (Mode == 2)
			{
				BlackScreen.SetActive(value: false);
				Disclaimer.SetActive(value: true);
				NiceBoat.SetActive(value: false);
			}
			else if (Mode == 3)
			{
				BlackScreen.SetActive(value: false);
				Disclaimer.SetActive(value: false);
				NiceBoat.SetActive(value: true);
			}
		}
	}
}
