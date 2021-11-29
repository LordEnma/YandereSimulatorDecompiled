using System;
using UnityEngine;

// Token: 0x020001B6 RID: 438
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Hexagon")]
public class CameraFilterPack_FX_Hexagon : MonoBehaviour
{
	// Token: 0x170002BB RID: 699
	// (get) Token: 0x06000F06 RID: 3846 RVA: 0x0007C548 File Offset: 0x0007A748
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

	// Token: 0x06000F07 RID: 3847 RVA: 0x0007C57C File Offset: 0x0007A77C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Hexagon");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F08 RID: 3848 RVA: 0x0007C5A0 File Offset: 0x0007A7A0
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
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F09 RID: 3849 RVA: 0x0007C63D File Offset: 0x0007A83D
	private void Update()
	{
	}

	// Token: 0x06000F0A RID: 3850 RVA: 0x0007C63F File Offset: 0x0007A83F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001351 RID: 4945
	public Shader SCShader;

	// Token: 0x04001352 RID: 4946
	private float TimeX = 1f;

	// Token: 0x04001353 RID: 4947
	private Material SCMaterial;
}
