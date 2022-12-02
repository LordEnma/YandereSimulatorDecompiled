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
		}
		else if (MyCutter == null)
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
						Physics.IgnoreCollision(GetComponent<Collider>(), MyCutter.MyCollider);
						Prompt.Yandere.DropTimer[Prompt.Yandere.Equipped] = 0.5f;
						Prompt.Yandere.DropWeapon(Prompt.Yandere.Equipped);
						MyCutter.MyRigidbody.useGravity = false;
						MyCutter.MyRigidbody.isKinematic = true;
						MyCutter.MyCollider.isTrigger = true;
						MyCutter.transform.parent = base.transform;
						MyCutter.transform.localPosition = new Vector3(0f, 0.24f, 0f);
						MyCutter.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
						MyCutter.Prompt.Hide();
						MyCutter.Prompt.enabled = false;
						MyCutter.enabled = false;
						MyCutter.gameObject.SetActive(true);
						Prompt.HideButton[0] = true;
						Prompt.HideButton[3] = false;
						PickUp.StuckBoxCutter = MyCutter;
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
