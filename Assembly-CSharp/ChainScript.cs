using UnityEngine;

public class ChainScript : MonoBehaviour
{
	public PromptScript Prompt;

	public TarpScript Tarp;

	public AudioClip ChainRattle;

	public GameObject[] Chains;

	public int Unlocked;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		if (Prompt.Yandere.Inventory.MysteriousKeys > 0)
		{
			AudioSource.PlayClipAtPoint(ChainRattle, base.transform.position);
			Unlocked++;
			Chains[Unlocked].SetActive(value: false);
			Prompt.Yandere.Inventory.MysteriousKeys--;
			if (Unlocked == 5)
			{
				Tarp.Prompt.enabled = true;
				Tarp.enabled = true;
				Prompt.Hide();
				Prompt.enabled = false;
				Object.Destroy(base.gameObject);
			}
		}
	}
}
