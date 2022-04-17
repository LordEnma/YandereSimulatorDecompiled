using System;
using UnityEngine;

// Token: 0x02000238 RID: 568
public class CarryableCardboardBoxScript : MonoBehaviour
{
	// Token: 0x06001230 RID: 4656 RVA: 0x0008BC14 File Offset: 0x00089E14
	private void Update()
	{
		if (!this.Closed)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Label[0].text = "     Insert Box Cutter";
				this.MyRenderer.mesh = this.ClosedMesh;
				this.Prompt.HideButton[0] = true;
				this.Closed = true;
				return;
			}
		}
		else if (this.MyCutter == null)
		{
			this.Prompt.HideButton[0] = true;
			if (!this.Prompt.Yandere.Armed)
			{
				this.Prompt.HideButton[0] = true;
				return;
			}
			if (this.Prompt.Yandere.EquippedWeapon.WeaponID != 5 || this.Prompt.Yandere.EquippedWeapon.Blood.enabled)
			{
				this.Prompt.HideButton[0] = true;
				return;
			}
			this.Prompt.HideButton[0] = false;
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.MyCutter = this.Prompt.Yandere.EquippedWeapon;
				Physics.IgnoreCollision(base.GetComponent<Collider>(), this.MyCutter.MyCollider);
				this.Prompt.Yandere.DropTimer[this.Prompt.Yandere.Equipped] = 0.5f;
				this.Prompt.Yandere.DropWeapon(this.Prompt.Yandere.Equipped);
				this.MyCutter.MyRigidbody.useGravity = false;
				this.MyCutter.MyRigidbody.isKinematic = true;
				this.MyCutter.MyCollider.isTrigger = true;
				this.MyCutter.transform.parent = base.transform;
				this.MyCutter.transform.localPosition = new Vector3(0f, 0.24f, 0f);
				this.MyCutter.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
				this.MyCutter.Prompt.Hide();
				this.MyCutter.Prompt.enabled = false;
				this.MyCutter.enabled = false;
				this.MyCutter.gameObject.SetActive(true);
				this.Prompt.HideButton[0] = true;
				this.Prompt.HideButton[3] = false;
				this.PickUp.StuckBoxCutter = this.MyCutter;
				this.PickUp.enabled = true;
				return;
			}
		}
		else if (this.MyCutter.transform.parent != base.transform)
		{
			this.MyCutter = null;
		}
	}

	// Token: 0x040016E4 RID: 5860
	public WeaponScript MyCutter;

	// Token: 0x040016E5 RID: 5861
	public PickUpScript PickUp;

	// Token: 0x040016E6 RID: 5862
	public PromptScript Prompt;

	// Token: 0x040016E7 RID: 5863
	public MeshFilter MyRenderer;

	// Token: 0x040016E8 RID: 5864
	public Mesh ClosedMesh;

	// Token: 0x040016E9 RID: 5865
	public bool Closed;
}
