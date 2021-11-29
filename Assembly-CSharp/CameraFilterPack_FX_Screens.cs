using System;
using UnityEngine;

// Token: 0x020001BE RID: 446
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Screens")]
public class CameraFilterPack_FX_Screens : MonoBehaviour
{
	// Token: 0x170002C3 RID: 707
	// (get) Token: 0x06000F36 RID: 3894 RVA: 0x0007CFA7 File Offset: 0x0007B1A7
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

	// Token: 0x06000F37 RID: 3895 RVA: 0x0007CFDB File Offset: 0x0007B1DB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Screens");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F38 RID: 3896 RVA: 0x0007CFFC File Offset: 0x0007B1FC
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
			this.material.SetFloat("_Value", this.Tiles);
			this.material.SetFloat("_Value2", this.Speed);
			this.material.SetFloat("_Value3", this.PosX);
			this.material.SetFloat("_Value4", this.PosY);
			this.material.SetColor("_color", this.color);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F39 RID: 3897 RVA: 0x0007D10A File Offset: 0x0007B30A
	private void Update()
	{
	}

	// Token: 0x06000F3A RID: 3898 RVA: 0x0007D10C File Offset: 0x0007B30C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001374 RID: 4980
	public Shader SCShader;

	// Token: 0x04001375 RID: 4981
	private float TimeX = 1f;

	// Token: 0x04001376 RID: 4982
	private Material SCMaterial;

	// Token: 0x04001377 RID: 4983
	[Range(0f, 256f)]
	public float Tiles = 8f;

	// Token: 0x04001378 RID: 4984
	[Range(0f, 5f)]
	public float Speed = 0.25f;

	// Token: 0x04001379 RID: 4985
	public Color color = new Color(0f, 1f, 1f, 1f);

	// Token: 0x0400137A RID: 4986
	[Range(-1f, 1f)]
	public float PosX;

	// Token: 0x0400137B RID: 4987
	[Range(-1f, 1f)]
	public float PosY;
}
