using System;
using UnityEngine;

// Token: 0x02000265 RID: 613
public class CreditsLabelScript : MonoBehaviour
{
	// Token: 0x060012F5 RID: 4853 RVA: 0x000A7AAC File Offset: 0x000A5CAC
	private void Start()
	{
		this.Rotation = -90f;
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
	}

	// Token: 0x060012F6 RID: 4854 RVA: 0x000A7AFC File Offset: 0x000A5CFC
	private void Update()
	{
		this.Rotation += Time.deltaTime * this.RotationSpeed;
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y + Time.deltaTime * this.MovementSpeed, base.transform.localPosition.z);
		if (this.Rotation > 90f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001AEC RID: 6892
	public float RotationSpeed;

	// Token: 0x04001AED RID: 6893
	public float MovementSpeed;

	// Token: 0x04001AEE RID: 6894
	public float Rotation;
}
