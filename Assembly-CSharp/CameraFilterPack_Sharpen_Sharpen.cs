using System;
using UnityEngine;

// Token: 0x02000200 RID: 512
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Sharpen/Sharpen")]
public class CameraFilterPack_Sharpen_Sharpen : MonoBehaviour
{
	// Token: 0x17000304 RID: 772
	// (get) Token: 0x060010E5 RID: 4325 RVA: 0x00086004 File Offset: 0x00084204
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

	// Token: 0x060010E6 RID: 4326 RVA: 0x00086038 File Offset: 0x00084238
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Sharpen_Sharpen");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010E7 RID: 4327 RVA: 0x0008605C File Offset: 0x0008425C
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetFloat("_Value", this.Value);
			this.material.SetFloat("_Value2", this.Value2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010E8 RID: 4328 RVA: 0x00086128 File Offset: 0x00084328
	private void Update()
	{
	}

	// Token: 0x060010E9 RID: 4329 RVA: 0x0008612A File Offset: 0x0008432A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001583 RID: 5507
	public Shader SCShader;

	// Token: 0x04001584 RID: 5508
	[Range(0.001f, 100f)]
	public float Value = 4f;

	// Token: 0x04001585 RID: 5509
	[Range(0.001f, 32f)]
	public float Value2 = 1f;

	// Token: 0x04001586 RID: 5510
	private float TimeX = 1f;

	// Token: 0x04001587 RID: 5511
	private Material SCMaterial;
}
