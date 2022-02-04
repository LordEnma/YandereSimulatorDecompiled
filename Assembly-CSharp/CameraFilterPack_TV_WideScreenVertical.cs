using System;
using UnityEngine;

// Token: 0x02000223 RID: 547
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/WideScreenVertical")]
public class CameraFilterPack_TV_WideScreenVertical : MonoBehaviour
{
	// Token: 0x17000327 RID: 807
	// (get) Token: 0x060011B4 RID: 4532 RVA: 0x00088D1B File Offset: 0x00086F1B
	private Material material
	{
		get
		{
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.SCMaterial;
		}
	}

	// Token: 0x060011B5 RID: 4533 RVA: 0x00088D4F File Offset: 0x00086F4F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_WideScreenVertical");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011B6 RID: 4534 RVA: 0x00088D70 File Offset: 0x00086F70
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", this.Smooth);
			this.material.SetFloat("_Value3", this.StretchX);
			this.material.SetFloat("_Value4", this.StretchY);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011B7 RID: 4535 RVA: 0x00088E68 File Offset: 0x00087068
	private void Update()
	{
	}

	// Token: 0x060011B8 RID: 4536 RVA: 0x00088E6A File Offset: 0x0008706A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400163F RID: 5695
	public Shader SCShader;

	// Token: 0x04001640 RID: 5696
	private float TimeX = 1f;

	// Token: 0x04001641 RID: 5697
	private Material SCMaterial;

	// Token: 0x04001642 RID: 5698
	[Range(0f, 0.8f)]
	public float Size = 0.55f;

	// Token: 0x04001643 RID: 5699
	[Range(0.001f, 0.4f)]
	public float Smooth = 0.01f;

	// Token: 0x04001644 RID: 5700
	[Range(0f, 10f)]
	private float StretchX = 1f;

	// Token: 0x04001645 RID: 5701
	[Range(0f, 10f)]
	private float StretchY = 1f;
}
