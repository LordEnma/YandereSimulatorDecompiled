using UnityEngine;

public class ClothingScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject FoldedUniform;

	public bool CanPickUp;

	private void Start()
	{
		Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	private void Update()
	{
		if (CanPickUp)
		{
			if (Yandere.Bloodiness == 0f)
			{
				CanPickUp = false;
				Prompt.Hide();
				Prompt.enabled = false;
			}
		}
		else if (Yandere.Bloodiness > 0f)
		{
			CanPickUp = true;
			Prompt.enabled = true;
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.Bloodiness = 0f;
			Object.Instantiate(FoldedUniform, base.transform.position + Vector3.up, Quaternion.identity);
			Object.Destroy(base.gameObject);
		}
	}
}
