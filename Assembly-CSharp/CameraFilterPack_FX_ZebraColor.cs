using System;
using UnityEngine;

// Token: 0x020001C0 RID: 448
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/ZebraColor")]
public class CameraFilterPack_FX_ZebraColor : MonoBehaviour
{
	// Token: 0x170002C5 RID: 709
	// (get) Token: 0x06000F42 RID: 3906 RVA: 0x0007D30B File Offset: 0x0007B50B
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

	// Token: 0x06000F43 RID: 3907 RVA: 0x0007D33F File Offset: 0x0007B53F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_ZebraColor");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F44 RID: 3908 RVA: 0x0007D360 File Offset: 0x0007B560
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F45 RID: 3909 RVA: 0x0007D416 File Offset: 0x0007B616
	private void Update()
	{
	}

	// Token: 0x06000F46 RID: 3910 RVA: 0x0007D418 File Offset: 0x0007B618
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001381 RID: 4993
	public Shader SCShader;

	// Token: 0x04001382 RID: 4994
	private float TimeX = 1f;

	// Token: 0x04001383 RID: 4995
	private Material SCMaterial;

	// Token: 0x04001384 RID: 4996
	[Range(1f, 10f)]
	public float Value = 3f;
}
