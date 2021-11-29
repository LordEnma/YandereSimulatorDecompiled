using System;
using UnityEngine;

// Token: 0x020001C4 RID: 452
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Fly_Vision")]
public class CameraFilterPack_Fly_Vision : MonoBehaviour
{
	// Token: 0x170002C9 RID: 713
	// (get) Token: 0x06000F5A RID: 3930 RVA: 0x0007D864 File Offset: 0x0007BA64
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

	// Token: 0x06000F5B RID: 3931 RVA: 0x0007D898 File Offset: 0x0007BA98
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Fly_VisionFX") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Fly_Vision");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F5C RID: 3932 RVA: 0x0007D8D0 File Offset: 0x0007BAD0
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
			this.material.SetFloat("_Value", this.Zoom);
			this.material.SetFloat("_Value2", this.Distortion);
			this.material.SetFloat("_Value3", this.Fade);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetTexture("Texture2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F5D RID: 3933 RVA: 0x0007D9DE File Offset: 0x0007BBDE
	private void Update()
	{
	}

	// Token: 0x06000F5E RID: 3934 RVA: 0x0007D9E0 File Offset: 0x0007BBE0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001393 RID: 5011
	public Shader SCShader;

	// Token: 0x04001394 RID: 5012
	private float TimeX = 1f;

	// Token: 0x04001395 RID: 5013
	private Material SCMaterial;

	// Token: 0x04001396 RID: 5014
	[Range(0.04f, 1.5f)]
	public float Zoom = 0.25f;

	// Token: 0x04001397 RID: 5015
	[Range(0f, 1f)]
	public float Distortion = 0.4f;

	// Token: 0x04001398 RID: 5016
	[Range(0f, 1f)]
	public float Fade = 0.4f;

	// Token: 0x04001399 RID: 5017
	[Range(0f, 10f)]
	private float Value4 = 1f;

	// Token: 0x0400139A RID: 5018
	private Texture2D Texture2;
}
