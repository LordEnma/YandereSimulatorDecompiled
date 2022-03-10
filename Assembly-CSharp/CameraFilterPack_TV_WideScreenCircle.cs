using System;
using UnityEngine;

// Token: 0x02000220 RID: 544
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/WideScreenCircle")]
public class CameraFilterPack_TV_WideScreenCircle : MonoBehaviour
{
	// Token: 0x17000324 RID: 804
	// (get) Token: 0x060011A3 RID: 4515 RVA: 0x00088BCC File Offset: 0x00086DCC
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

	// Token: 0x060011A4 RID: 4516 RVA: 0x00088C00 File Offset: 0x00086E00
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_WideScreenCircle");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011A5 RID: 4517 RVA: 0x00088C24 File Offset: 0x00086E24
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

	// Token: 0x060011A6 RID: 4518 RVA: 0x00088D1C File Offset: 0x00086F1C
	private void Update()
	{
	}

	// Token: 0x060011A7 RID: 4519 RVA: 0x00088D1E File Offset: 0x00086F1E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001636 RID: 5686
	public Shader SCShader;

	// Token: 0x04001637 RID: 5687
	private float TimeX = 1f;

	// Token: 0x04001638 RID: 5688
	private Material SCMaterial;

	// Token: 0x04001639 RID: 5689
	[Range(0f, 0.8f)]
	public float Size = 0.55f;

	// Token: 0x0400163A RID: 5690
	[Range(0.01f, 0.4f)]
	public float Smooth = 0.01f;

	// Token: 0x0400163B RID: 5691
	[Range(0f, 10f)]
	private float StretchX = 1f;

	// Token: 0x0400163C RID: 5692
	[Range(0f, 10f)]
	private float StretchY = 1f;
}
