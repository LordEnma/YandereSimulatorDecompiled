using UnityEngine;

public class RooftopCorpseDisposalScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public Collider MyCollider;

	public Transform DropSpot;

	private void Start()
	{
		if (SchoolGlobals.RoofFence)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
		if (MyCollider.bounds.Contains(Yandere.transform.position))
		{
			if (Yandere.Ragdoll != null)
			{
				if (!Yandere.Dropping)
				{
					Prompt.enabled = true;
					Prompt.transform.position = new Vector3(Yandere.transform.position.x, Yandere.transform.position.y + 1.66666f, Yandere.transform.position.z);
					if (Prompt.Circle[0].fillAmount == 0f)
					{
						DropSpot.position = new Vector3(DropSpot.position.x, DropSpot.position.y, Yandere.transform.position.z);
						Yandere.CharacterAnimation.CrossFade(Yandere.Carrying ? "f02_carryIdleA_00" : "f02_dragIdle_00");
						Yandere.DropSpot = DropSpot;
						Yandere.Dropping = true;
						Yandere.CanMove = false;
						Prompt.Hide();
						Prompt.enabled = false;
						Yandere.Ragdoll.GetComponent<RagdollScript>().BloodPoolSpawner.Falling = true;
						Yandere.Ragdoll.GetComponent<RagdollScript>().DroppedFromRooftop = true;
					}
				}
			}
			else
			{
				Prompt.Hide();
				Prompt.enabled = false;
			}
		}
		else
		{
			Prompt.Hide();
			Prompt.enabled = false;
		}
	}
}
