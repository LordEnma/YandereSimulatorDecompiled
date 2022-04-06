using System;
using UnityEngine;

// Token: 0x02000222 RID: 546
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/WideScreenHorizontal")]
public class CameraFilterPack_TV_WideScreenHorizontal : MonoBehaviour
{
	// Token: 0x17000326 RID: 806
	// (get) Token: 0x060011B1 RID: 4529 RVA: 0x0008939B File Offset: 0x0008759B
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

	// Token: 0x060011B2 RID: 4530 RVA: 0x000893CF File Offset: 0x000875CF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_WideScreenHorizontal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011B3 RID: 4531 RVA: 0x000893F0 File Offset: 0x000875F0
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

	// Token: 0x060011B4 RID: 4532 RVA: 0x000894E8 File Offset: 0x000876E8
	private void Update()
	{
	}

	// Token: 0x060011B5 RID: 4533 RVA: 0x000894EA File Offset: 0x000876EA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400164B RID: 5707
	public Shader SCShader;

	// Token: 0x0400164C RID: 5708
	private float TimeX = 1f;

	// Token: 0x0400164D RID: 5709
	private Material SCMaterial;

	// Token: 0x0400164E RID: 5710
	[Range(0f, 0.8f)]
	public float Size = 0.55f;

	// Token: 0x0400164F RID: 5711
	[Range(0.001f, 0.4f)]
	public float Smooth = 0.01f;

	// Token: 0x04001650 RID: 5712
	[Range(0f, 10f)]
	private float StretchX = 1f;

	// Token: 0x04001651 RID: 5713
	[Range(0f, 10f)]
	private float StretchY = 1f;
}
