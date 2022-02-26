using System;
using UnityEngine;

// Token: 0x02000266 RID: 614
public class CreditsLabelScript : MonoBehaviour
{
	// Token: 0x060012F9 RID: 4857 RVA: 0x000A7C74 File Offset: 0x000A5E74
	private void Start()
	{
		this.Rotation = -90f;
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
	}

	// Token: 0x060012FA RID: 4858 RVA: 0x000A7CC4 File Offset: 0x000A5EC4
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

	// Token: 0x04001AF2 RID: 6898
	public float RotationSpeed;

	// Token: 0x04001AF3 RID: 6899
	public float MovementSpeed;

	// Token: 0x04001AF4 RID: 6900
	public float Rotation;
}
