using System;
using UnityEngine;

// Token: 0x02000175 RID: 373
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Dissipation")]
public class CameraFilterPack_Distortion_Dissipation : MonoBehaviour
{
	// Token: 0x1700027A RID: 634
	// (get) Token: 0x06000D7F RID: 3455 RVA: 0x00076456 File Offset: 0x00074656
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

	// Token: 0x06000D80 RID: 3456 RVA: 0x0007648A File Offset: 0x0007468A
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Dissipation");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D81 RID: 3457 RVA: 0x000764AC File Offset: 0x000746AC
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
			this.material.SetFloat("_Value", this.Dissipation);
			this.material.SetFloat("_Value2", this.Colors);
			this.material.SetFloat("_Value3", this.Green_Mod);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D82 RID: 3458 RVA: 0x000765A4 File Offset: 0x000747A4
	private void Update()
	{
	}

	// Token: 0x06000D83 RID: 3459 RVA: 0x000765A6 File Offset: 0x000747A6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011C5 RID: 4549
	public Shader SCShader;

	// Token: 0x040011C6 RID: 4550
	private float TimeX = 1f;

	// Token: 0x040011C7 RID: 4551
	private Material SCMaterial;

	// Token: 0x040011C8 RID: 4552
	[Range(0f, 2.99f)]
	public float Dissipation = 1f;

	// Token: 0x040011C9 RID: 4553
	[Range(0f, 16f)]
	private float Colors = 11f;

	// Token: 0x040011CA RID: 4554
	[Range(-1f, 1f)]
	private float Green_Mod = 1f;

	// Token: 0x040011CB RID: 4555
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
