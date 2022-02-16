using System;
using UnityEngine;

// Token: 0x020001B0 RID: 432
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Drunk2")]
public class CameraFilterPack_FX_Drunk2 : MonoBehaviour
{
	// Token: 0x170002B4 RID: 692
	// (get) Token: 0x06000EE0 RID: 3808 RVA: 0x0007BF0D File Offset: 0x0007A10D
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

	// Token: 0x06000EE1 RID: 3809 RVA: 0x0007BF41 File Offset: 0x0007A141
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Drunk2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EE2 RID: 3810 RVA: 0x0007BF64 File Offset: 0x0007A164
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
			this.material.SetFloat("_Value", this.Value);
			this.material.SetFloat("_Value2", this.Value2);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EE3 RID: 3811 RVA: 0x0007C05C File Offset: 0x0007A25C
	private void Update()
	{
	}

	// Token: 0x06000EE4 RID: 3812 RVA: 0x0007C05E File Offset: 0x0007A25E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001336 RID: 4918
	public Shader SCShader;

	// Token: 0x04001337 RID: 4919
	private float TimeX = 1f;

	// Token: 0x04001338 RID: 4920
	private Material SCMaterial;

	// Token: 0x04001339 RID: 4921
	[Range(0f, 10f)]
	private float Value = 1f;

	// Token: 0x0400133A RID: 4922
	[Range(0f, 10f)]
	private float Value2 = 1f;

	// Token: 0x0400133B RID: 4923
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x0400133C RID: 4924
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
