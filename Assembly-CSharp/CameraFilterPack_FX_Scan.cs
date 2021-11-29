using System;
using UnityEngine;

// Token: 0x020001BD RID: 445
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Scan")]
public class CameraFilterPack_FX_Scan : MonoBehaviour
{
	// Token: 0x170002C2 RID: 706
	// (get) Token: 0x06000F30 RID: 3888 RVA: 0x0007CDFC File Offset: 0x0007AFFC
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

	// Token: 0x06000F31 RID: 3889 RVA: 0x0007CE30 File Offset: 0x0007B030
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Scan");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F32 RID: 3890 RVA: 0x0007CE54 File Offset: 0x0007B054
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
			this.material.SetFloat("_Value2", this.Speed);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F33 RID: 3891 RVA: 0x0007CF4C File Offset: 0x0007B14C
	private void Update()
	{
	}

	// Token: 0x06000F34 RID: 3892 RVA: 0x0007CF4E File Offset: 0x0007B14E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400136D RID: 4973
	public Shader SCShader;

	// Token: 0x0400136E RID: 4974
	private float TimeX = 1f;

	// Token: 0x0400136F RID: 4975
	private Material SCMaterial;

	// Token: 0x04001370 RID: 4976
	[Range(0.001f, 0.1f)]
	public float Size = 0.025f;

	// Token: 0x04001371 RID: 4977
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04001372 RID: 4978
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x04001373 RID: 4979
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
