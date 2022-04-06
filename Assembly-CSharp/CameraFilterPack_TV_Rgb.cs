using System;
using UnityEngine;

// Token: 0x02000217 RID: 535
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/RGB Display")]
public class CameraFilterPack_TV_Rgb : MonoBehaviour
{
	// Token: 0x1700031B RID: 795
	// (get) Token: 0x0600116F RID: 4463 RVA: 0x00088411 File Offset: 0x00086611
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

	// Token: 0x06001170 RID: 4464 RVA: 0x00088445 File Offset: 0x00086645
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Rgb");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001171 RID: 4465 RVA: 0x00088468 File Offset: 0x00086668
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
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001172 RID: 4466 RVA: 0x0008851E File Offset: 0x0008671E
	private void Update()
	{
	}

	// Token: 0x06001173 RID: 4467 RVA: 0x00088520 File Offset: 0x00086720
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400160E RID: 5646
	public Shader SCShader;

	// Token: 0x0400160F RID: 5647
	private float TimeX = 1f;

	// Token: 0x04001610 RID: 5648
	[Range(0.01f, 4f)]
	public float Distortion = 1f;

	// Token: 0x04001611 RID: 5649
	private Material SCMaterial;
}
