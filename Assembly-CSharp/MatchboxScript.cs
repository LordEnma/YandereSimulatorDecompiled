using UnityEngine;

public class MatchboxScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public PickUpScript PickUp;

	public GameObject Match;

	public AudioSource MyAudio;

	public int Ammo;

	private void Update()
	{
		if (Prompt.PauseScreen.Show)
		{
			return;
		}
		if (Prompt.Yandere.PickUp == PickUp)
		{
			if (Prompt.HideButton[0])
			{
				Prompt.Yandere.Arc.SetActive(true);
				Prompt.HideButton[0] = false;
				Prompt.HideButton[3] = true;
			}
			if (Prompt.Circle[0].fillAmount < 1f && Prompt.Circle[0].fillAmount > 0f)
			{
				Prompt.Circle[0].fillAmount = 0f;
				MyAudio.Play();
				Rigidbody component = Object.Instantiate(Match, Prompt.Yandere.ItemParent.position, Prompt.Yandere.transform.rotation).GetComponent<Rigidbody>();
				component.isKinematic = false;
				component.useGravity = true;
				component.AddRelativeForce(Vector3.up * 250f);
				component.AddRelativeForce(Vector3.forward * 250f);
				Prompt.Yandere.SuspiciousActionTimer = 1f;
				Ammo--;
				if (Ammo < 1)
				{
					Prompt.Yandere.Arc.SetActive(false);
					Prompt.Yandere.PickUp.Drop();
					Object.Destroy(base.gameObject);
				}
			}
		}
		else if (Prompt.Yandere.Arc.activeInHierarchy && !Prompt.HideButton[0])
		{
			Prompt.Yandere.Arc.SetActive(false);
			Prompt.HideButton[0] = true;
			Prompt.HideButton[3] = false;
		}
	}
}
