using UnityEngine;

public class SenpaiShrineCollectibleScript : MonoBehaviour
{
	public PromptScript Prompt;

	public int ID;

	private void Start()
	{
		if (PlayerGlobals.GetShrineCollectible(ID) && ID != 9)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Debug.Log("Picked up shrine item.");
			Prompt.Yandere.StudentManager.Police.EndOfDay.ShrineItemsCollected++;
			Prompt.Yandere.Inventory.ShrineCollectibles[ID] = true;
			Prompt.Hide();
			Object.Destroy(base.gameObject);
		}
	}
}
