using System;
using UnityEngine;

// Token: 0x02000196 RID: 406
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga_Flash")]
public class CameraFilterPack_Drawing_Manga_Flash : MonoBehaviour
{
	// Token: 0x1700029A RID: 666
	// (get) Token: 0x06000E43 RID: 3651 RVA: 0x00079544 File Offset: 0x00077744
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

	// Token: 0x06000E44 RID: 3652 RVA: 0x00079578 File Offset: 0x00077778
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga_Flash");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E45 RID: 3653 RVA: 0x0007959C File Offset: 0x0007779C
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
			this.material.SetFloat("_Value2", (float)this.Speed);
			this.material.SetFloat("_Value3", this.PosX);
			this.material.SetFloat("_Value4", this.PosY);
			this.material.SetFloat("_Intensity", this.Intensity);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E46 RID: 3654 RVA: 0x000796AB File Offset: 0x000778AB
	private void Update()
	{
	}

	// Token: 0x06000E47 RID: 3655 RVA: 0x000796AD File Offset: 0x000778AD
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400127D RID: 4733
	public Shader SCShader;

	// Token: 0x0400127E RID: 4734
	private float TimeX = 1f;

	// Token: 0x0400127F RID: 4735
	private Material SCMaterial;

	// Token: 0x04001280 RID: 4736
	[Range(1f, 10f)]
	public float Size = 1f;

	// Token: 0x04001281 RID: 4737
	[Range(0f, 30f)]
	public int Speed = 5;

	// Token: 0x04001282 RID: 4738
	[Range(-1f, 1f)]
	public float PosX = 0.5f;

	// Token: 0x04001283 RID: 4739
	[Range(-1f, 1f)]
	public float PosY = 0.5f;

	// Token: 0x04001284 RID: 4740
	[Range(0f, 1f)]
	public float Intensity = 1f;
}
