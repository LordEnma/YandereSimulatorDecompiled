using System;
using UnityEngine;

// Token: 0x020000F5 RID: 245
public class BoundaryScript : MonoBehaviour
{
	// Token: 0x06000A61 RID: 2657 RVA: 0x0005C970 File Offset: 0x0005AB70
	private void Update()
	{
		float z = this.Yandere.position.z;
		if (z < -94f)
		{
			this.Intensity = -95f + Mathf.Abs(z);
			this.TextureCycle.gameObject.SetActive(true);
			this.TextureCycle.Sprite.enabled = true;
			this.TextureCycle.enabled = true;
			Color color = this.Static.color + new Color(0.0001f, 0.0001f, 0.0001f, 0.0001f);
			Color color2 = this.Label.color;
			color.a = this.Intensity / 5f;
			color2.a = this.Intensity / 5f;
			this.Static.color = color;
			this.Label.color = color2;
			base.GetComponent<AudioSource>().volume = this.Intensity / 5f * 0.1f;
			Vector3 localPosition = this.Label.transform.localPosition;
			localPosition.x = UnityEngine.Random.Range(-10f, 10f);
			localPosition.y = UnityEngine.Random.Range(-10f, 10f);
			this.Label.transform.localPosition = localPosition;
			return;
		}
		if (this.TextureCycle.enabled)
		{
			this.TextureCycle.gameObject.SetActive(false);
			this.TextureCycle.Sprite.enabled = false;
			this.TextureCycle.enabled = false;
			Color color3 = this.Static.color;
			Color color4 = this.Label.color;
			color3.a = 0f;
			color4.a = 0f;
			this.Static.color = color3;
			this.Label.color = color4;
			base.GetComponent<AudioSource>().volume = 0f;
		}
	}

	// Token: 0x04000C19 RID: 3097
	public TextureCycleScript TextureCycle;

	// Token: 0x04000C1A RID: 3098
	public Transform Yandere;

	// Token: 0x04000C1B RID: 3099
	public UITexture Static;

	// Token: 0x04000C1C RID: 3100
	public UILabel Label;

	// Token: 0x04000C1D RID: 3101
	public float Intensity;
}
