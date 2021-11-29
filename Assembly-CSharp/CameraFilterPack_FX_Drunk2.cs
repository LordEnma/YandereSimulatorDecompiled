using System;
using UnityEngine;

// Token: 0x020001AF RID: 431
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Drunk2")]
public class CameraFilterPack_FX_Drunk2 : MonoBehaviour
{
	// Token: 0x170002B4 RID: 692
	// (get) Token: 0x06000EDC RID: 3804 RVA: 0x0007BBC5 File Offset: 0x00079DC5
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

	// Token: 0x06000EDD RID: 3805 RVA: 0x0007BBF9 File Offset: 0x00079DF9
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Drunk2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EDE RID: 3806 RVA: 0x0007BC1C File Offset: 0x00079E1C
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

	// Token: 0x06000EDF RID: 3807 RVA: 0x0007BD14 File Offset: 0x00079F14
	private void Update()
	{
	}

	// Token: 0x06000EE0 RID: 3808 RVA: 0x0007BD16 File Offset: 0x00079F16
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400132E RID: 4910
	public Shader SCShader;

	// Token: 0x0400132F RID: 4911
	private float TimeX = 1f;

	// Token: 0x04001330 RID: 4912
	private Material SCMaterial;

	// Token: 0x04001331 RID: 4913
	[Range(0f, 10f)]
	private float Value = 1f;

	// Token: 0x04001332 RID: 4914
	[Range(0f, 10f)]
	private float Value2 = 1f;

	// Token: 0x04001333 RID: 4915
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x04001334 RID: 4916
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
