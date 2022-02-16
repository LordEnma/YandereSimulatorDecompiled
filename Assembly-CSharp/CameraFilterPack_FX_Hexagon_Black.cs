using System;
using UnityEngine;

// Token: 0x020001B8 RID: 440
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Hexagon_Black")]
public class CameraFilterPack_FX_Hexagon_Black : MonoBehaviour
{
	// Token: 0x170002BC RID: 700
	// (get) Token: 0x06000F10 RID: 3856 RVA: 0x0007C9B4 File Offset: 0x0007ABB4
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

	// Token: 0x06000F11 RID: 3857 RVA: 0x0007C9E8 File Offset: 0x0007ABE8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Hexagon_Black");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F12 RID: 3858 RVA: 0x0007CA0C File Offset: 0x0007AC0C
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

	// Token: 0x06000F13 RID: 3859 RVA: 0x0007CAC2 File Offset: 0x0007ACC2
	private void Update()
	{
	}

	// Token: 0x06000F14 RID: 3860 RVA: 0x0007CAC4 File Offset: 0x0007ACC4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400135C RID: 4956
	public Shader SCShader;

	// Token: 0x0400135D RID: 4957
	private float TimeX = 1f;

	// Token: 0x0400135E RID: 4958
	private Material SCMaterial;

	// Token: 0x0400135F RID: 4959
	[Range(0.2f, 10f)]
	public float Value = 1f;
}
