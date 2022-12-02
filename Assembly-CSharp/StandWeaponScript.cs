using UnityEngine;

public class StandWeaponScript : MonoBehaviour
{
	public PromptScript Prompt;

	public StandScript Stand;

	public float RotationSpeed;

	private void Update()
	{
		if (Prompt.enabled)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				MoveToStand();
			}
		}
		else
		{
			base.transform.Rotate(Vector3.forward * (Time.deltaTime * RotationSpeed));
			base.transform.Rotate(Vector3.right * (Time.deltaTime * RotationSpeed));
			base.transform.Rotate(Vector3.up * (Time.deltaTime * RotationSpeed));
		}
	}

	private void MoveToStand()
	{
		Prompt.Hide();
		Prompt.enabled = false;
		Prompt.MyCollider.enabled = false;
		Stand.Weapons++;
		base.transform.parent = Stand.Hands[Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}
}
