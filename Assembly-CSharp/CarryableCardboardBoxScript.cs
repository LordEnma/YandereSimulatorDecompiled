using UnityEngine;

public class CarryableCardboardBoxScript : MonoBehaviour
{
	public WeaponScript MyCutter;

	public PickUpScript PickUp;

	public PromptScript Prompt;

	public MeshFilter MyRenderer;

	public Mesh ClosedMesh;

	public bool Closed;

	private void Update()
	{
		if (!Closed)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Label[0].text = "     Insert Box Cutter";
				MyRenderer.mesh = ClosedMesh;
				Prompt.HideButton[0] = true;
				Closed = true;
			}
			return;
		}
		if (MyRenderer.mesh != ClosedMesh)
		{
			Prompt.Label[0].text = "     Insert Box Cutter";
			MyRenderer.mesh = ClosedMesh;
			Prompt.HideButton[0] = true;
		}
		if (MyCutter == null)
		{
			Prompt.HideButton[0] = true;
			if (Prompt.Yandere.Armed)
			{
				if (Prompt.Yandere.EquippedWeapon.WeaponID == 5 && !Prompt.Yandere.EquippedWeapon.Blood.enabled)
				{
					Prompt.HideButton[0] = false;
					if (Prompt.Circle[0].fillAmount == 0f)
					{
						MyCutter = Prompt.Yandere.EquippedWeapon;
						MyCutter.GetStuckInBox();
						Prompt.HideButton[0] = true;
						Prompt.HideButton[3] = false;
						PickUp.enabled = true;
					}
				}
				else
				{
					Prompt.HideButton[0] = true;
				}
			}
			else
			{
				Prompt.HideButton[0] = true;
			}
		}
		else if (MyCutter.transform.parent != base.transform)
		{
			MyCutter = null;
		}
	}
}
