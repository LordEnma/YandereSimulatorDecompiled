using System;
using UnityEngine;

// Token: 0x0200011B RID: 283
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Super Computer")]
public class CameraFilterPack_AAA_SuperComputer : MonoBehaviour
{
	// Token: 0x1700021F RID: 543
	// (get) Token: 0x06000B1F RID: 2847 RVA: 0x0006B028 File Offset: 0x00069228
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

	// Token: 0x06000B20 RID: 2848 RVA: 0x0006B05C File Offset: 0x0006925C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/AAA_Super_Computer");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B21 RID: 2849 RVA: 0x0006B080 File Offset: 0x00069280
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime / 4f;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.ShapeFormula);
			this.material.SetFloat("_Value2", this.Shape);
			this.material.SetFloat("_PositionX", this.center.x);
			this.material.SetFloat("_PositionY", this.center.y);
			this.material.SetFloat("_Radius", this.Radius);
			this.material.SetFloat("_BorderSize", this._BorderSize);
			this.material.SetColor("_BorderColor", this._BorderColor);
			this.material.SetFloat("_AlphaHexa", this._AlphaHexa);
			this.material.SetFloat("_SpotSize", this._SpotSize);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B22 RID: 2850 RVA: 0x0006B1F6 File Offset: 0x000693F6
	private void Update()
	{
	}

	// Token: 0x06000B23 RID: 2851 RVA: 0x0006B1F8 File Offset: 0x000693F8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F16 RID: 3862
	public Shader SCShader;

	// Token: 0x04000F17 RID: 3863
	[Range(0f, 1f)]
	public float _AlphaHexa = 1f;

	// Token: 0x04000F18 RID: 3864
	private float TimeX = 1f;

	// Token: 0x04000F19 RID: 3865
	private Material SCMaterial;

	// Token: 0x04000F1A RID: 3866
	[Range(-20f, 20f)]
	public float ShapeFormula = 10f;

	// Token: 0x04000F1B RID: 3867
	[Range(0f, 6f)]
	public float Shape = 1f;

	// Token: 0x04000F1C RID: 3868
	[Range(-4f, 4f)]
	public float _BorderSize = 1f;

	// Token: 0x04000F1D RID: 3869
	public Color _BorderColor = new Color(0f, 0.2f, 1f, 1f);

	// Token: 0x04000F1E RID: 3870
	public float _SpotSize = 2.5f;

	// Token: 0x04000F1F RID: 3871
	public Vector2 center = new Vector2(0f, 0f);

	// Token: 0x04000F20 RID: 3872
	public float Radius = 0.77f;
}
