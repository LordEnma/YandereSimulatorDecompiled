using System;
using UnityEngine;

// Token: 0x02000013 RID: 19
public class MGPMProjectileScript : MonoBehaviour
{
	// Token: 0x06000041 RID: 65 RVA: 0x00006CD6 File Offset: 0x00004ED6
	private void Start()
	{
		if (this.Eighties)
		{
			base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00006D00 File Offset: 0x00004F00
	private void Update()
	{
		if (base.gameObject.layer == 8)
		{
			base.transform.Translate(Vector3.up * Time.deltaTime * this.Speed);
		}
		else
		{
			base.transform.Translate(Vector3.forward * Time.deltaTime * this.Speed);
		}
		if (this.Angle == 1)
		{
			base.transform.Translate(Vector3.right * Time.deltaTime * this.Speed * 0.2f);
		}
		else if (this.Angle == -1)
		{
			base.transform.Translate(Vector3.right * Time.deltaTime * this.Speed * -0.2f);
		}
		if (base.transform.localPosition.y > 300f || base.transform.localPosition.y < -300f || base.transform.localPosition.x > 134f || base.transform.localPosition.x < -134f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040000F4 RID: 244
	public Transform Sprite;

	// Token: 0x040000F5 RID: 245
	public int Angle;

	// Token: 0x040000F6 RID: 246
	public float Speed;

	// Token: 0x040000F7 RID: 247
	public bool Eighties;
}
