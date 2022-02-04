using System;
using UnityEngine;

// Token: 0x02000222 RID: 546
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/WideScreenHorizontal")]
public class CameraFilterPack_TV_WideScreenHorizontal : MonoBehaviour
{
	// Token: 0x17000326 RID: 806
	// (get) Token: 0x060011AE RID: 4526 RVA: 0x00088B73 File Offset: 0x00086D73
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

	// Token: 0x060011AF RID: 4527 RVA: 0x00088BA7 File Offset: 0x00086DA7
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_WideScreenHorizontal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011B0 RID: 4528 RVA: 0x00088BC8 File Offset: 0x00086DC8
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

	// Token: 0x060011B1 RID: 4529 RVA: 0x00088CC0 File Offset: 0x00086EC0
	private void Update()
	{
	}

	// Token: 0x060011B2 RID: 4530 RVA: 0x00088CC2 File Offset: 0x00086EC2
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001638 RID: 5688
	public Shader SCShader;

	// Token: 0x04001639 RID: 5689
	private float TimeX = 1f;

	// Token: 0x0400163A RID: 5690
	private Material SCMaterial;

	// Token: 0x0400163B RID: 5691
	[Range(0f, 0.8f)]
	public float Size = 0.55f;

	// Token: 0x0400163C RID: 5692
	[Range(0.001f, 0.4f)]
	public float Smooth = 0.01f;

	// Token: 0x0400163D RID: 5693
	[Range(0f, 10f)]
	private float StretchX = 1f;

	// Token: 0x0400163E RID: 5694
	[Range(0f, 10f)]
	private float StretchY = 1f;
}
