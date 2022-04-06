using System;
using UnityEngine;

// Token: 0x0200017D RID: 381
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Heat")]
public class CameraFilterPack_Distortion_Heat : MonoBehaviour
{
	// Token: 0x17000281 RID: 641
	// (get) Token: 0x06000DAF RID: 3503 RVA: 0x000777FA File Offset: 0x000759FA
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

	// Token: 0x06000DB0 RID: 3504 RVA: 0x0007782E File Offset: 0x00075A2E
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Heat");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DB1 RID: 3505 RVA: 0x00077850 File Offset: 0x00075A50
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

	// Token: 0x06000DB2 RID: 3506 RVA: 0x00077906 File Offset: 0x00075B06
	private void Update()
	{
	}

	// Token: 0x06000DB3 RID: 3507 RVA: 0x00077908 File Offset: 0x00075B08
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001201 RID: 4609
	public Shader SCShader;

	// Token: 0x04001202 RID: 4610
	private float TimeX = 1f;

	// Token: 0x04001203 RID: 4611
	private Material SCMaterial;

	// Token: 0x04001204 RID: 4612
	[Range(1f, 100f)]
	public float Distortion = 35f;
}
