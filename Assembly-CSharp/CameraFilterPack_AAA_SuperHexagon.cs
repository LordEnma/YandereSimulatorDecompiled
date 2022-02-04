using System;
using UnityEngine;

// Token: 0x0200011C RID: 284
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Super Hexagon")]
public class CameraFilterPack_AAA_SuperHexagon : MonoBehaviour
{
	// Token: 0x17000220 RID: 544
	// (get) Token: 0x06000B25 RID: 2853 RVA: 0x0006B2A8 File Offset: 0x000694A8
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

	// Token: 0x06000B26 RID: 2854 RVA: 0x0006B2DC File Offset: 0x000694DC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/AAA_Super_Hexagon");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B27 RID: 2855 RVA: 0x0006B300 File Offset: 0x00069500
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

	// Token: 0x06000B28 RID: 2856 RVA: 0x0006B470 File Offset: 0x00069670
	private void Update()
	{
	}

	// Token: 0x06000B29 RID: 2857 RVA: 0x0006B472 File Offset: 0x00069672
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F21 RID: 3873
	public Shader SCShader;

	// Token: 0x04000F22 RID: 3874
	[Range(0f, 1f)]
	public float _AlphaHexa = 1f;

	// Token: 0x04000F23 RID: 3875
	private float TimeX = 1f;

	// Token: 0x04000F24 RID: 3876
	private Material SCMaterial;

	// Token: 0x04000F25 RID: 3877
	[Range(0.2f, 10f)]
	public float HexaSize = 2.5f;

	// Token: 0x04000F26 RID: 3878
	public float _BorderSize = 1f;

	// Token: 0x04000F27 RID: 3879
	public Color _BorderColor = new Color(0.75f, 0.75f, 1f, 1f);

	// Token: 0x04000F28 RID: 3880
	public Color _HexaColor = new Color(0f, 0.5f, 1f, 1f);

	// Token: 0x04000F29 RID: 3881
	public float _SpotSize = 2.5f;

	// Token: 0x04000F2A RID: 3882
	public Vector2 center = new Vector2(0.5f, 0.5f);

	// Token: 0x04000F2B RID: 3883
	public float Radius = 0.25f;
}
