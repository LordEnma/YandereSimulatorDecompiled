using System;
using UnityEngine;

// Token: 0x020001B0 RID: 432
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Drunk2")]
public class CameraFilterPack_FX_Drunk2 : MonoBehaviour
{
	// Token: 0x170002B4 RID: 692
	// (get) Token: 0x06000EDF RID: 3807 RVA: 0x0007BDBD File Offset: 0x00079FBD
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

	// Token: 0x06000EE0 RID: 3808 RVA: 0x0007BDF1 File Offset: 0x00079FF1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Drunk2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EE1 RID: 3809 RVA: 0x0007BE14 File Offset: 0x0007A014
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

	// Token: 0x06000EE2 RID: 3810 RVA: 0x0007BF0C File Offset: 0x0007A10C
	private void Update()
	{
	}

	// Token: 0x06000EE3 RID: 3811 RVA: 0x0007BF0E File Offset: 0x0007A10E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001333 RID: 4915
	public Shader SCShader;

	// Token: 0x04001334 RID: 4916
	private float TimeX = 1f;

	// Token: 0x04001335 RID: 4917
	private Material SCMaterial;

	// Token: 0x04001336 RID: 4918
	[Range(0f, 10f)]
	private float Value = 1f;

	// Token: 0x04001337 RID: 4919
	[Range(0f, 10f)]
	private float Value2 = 1f;

	// Token: 0x04001338 RID: 4920
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x04001339 RID: 4921
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
