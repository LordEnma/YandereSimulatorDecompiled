using System;
using UnityEngine;

// Token: 0x0200011B RID: 283
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Super Hexagon")]
public class CameraFilterPack_AAA_SuperHexagon : MonoBehaviour
{
	// Token: 0x17000220 RID: 544
	// (get) Token: 0x06000B22 RID: 2850 RVA: 0x0006B0B0 File Offset: 0x000692B0
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

	// Token: 0x06000B23 RID: 2851 RVA: 0x0006B0E4 File Offset: 0x000692E4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/AAA_Super_Hexagon");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B24 RID: 2852 RVA: 0x0006B108 File Offset: 0x00069308
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
			this.material.SetFloat("_Value", this.HexaSize);
			this.material.SetFloat("_PositionX", this.center.x);
			this.material.SetFloat("_PositionY", this.center.y);
			this.material.SetFloat("_Radius", this.Radius);
			this.material.SetFloat("_BorderSize", this._BorderSize);
			this.material.SetColor("_BorderColor", this._BorderColor);
			this.material.SetColor("_HexaColor", this._HexaColor);
			this.material.SetFloat("_AlphaHexa", this._AlphaHexa);
			this.material.SetFloat("_SpotSize", this._SpotSize);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B25 RID: 2853 RVA: 0x0006B278 File Offset: 0x00069478
	private void Update()
	{
	}

	// Token: 0x06000B26 RID: 2854 RVA: 0x0006B27A File Offset: 0x0006947A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F1C RID: 3868
	public Shader SCShader;

	// Token: 0x04000F1D RID: 3869
	[Range(0f, 1f)]
	public float _AlphaHexa = 1f;

	// Token: 0x04000F1E RID: 3870
	private float TimeX = 1f;

	// Token: 0x04000F1F RID: 3871
	private Material SCMaterial;

	// Token: 0x04000F20 RID: 3872
	[Range(0.2f, 10f)]
	public float HexaSize = 2.5f;

	// Token: 0x04000F21 RID: 3873
	public float _BorderSize = 1f;

	// Token: 0x04000F22 RID: 3874
	public Color _BorderColor = new Color(0.75f, 0.75f, 1f, 1f);

	// Token: 0x04000F23 RID: 3875
	public Color _HexaColor = new Color(0f, 0.5f, 1f, 1f);

	// Token: 0x04000F24 RID: 3876
	public float _SpotSize = 2.5f;

	// Token: 0x04000F25 RID: 3877
	public Vector2 center = new Vector2(0.5f, 0.5f);

	// Token: 0x04000F26 RID: 3878
	public float Radius = 0.25f;
}
