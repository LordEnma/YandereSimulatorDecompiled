using System;
using UnityEngine;

// Token: 0x0200011B RID: 283
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Super Computer")]
public class CameraFilterPack_AAA_SuperComputer : MonoBehaviour
{
	// Token: 0x1700021F RID: 543
	// (get) Token: 0x06000B22 RID: 2850 RVA: 0x0006B850 File Offset: 0x00069A50
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

	// Token: 0x06000B23 RID: 2851 RVA: 0x0006B884 File Offset: 0x00069A84
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/AAA_Super_Computer");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B24 RID: 2852 RVA: 0x0006B8A8 File Offset: 0x00069AA8
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

	// Token: 0x06000B25 RID: 2853 RVA: 0x0006BA1E File Offset: 0x00069C1E
	private void Update()
	{
	}

	// Token: 0x06000B26 RID: 2854 RVA: 0x0006BA20 File Offset: 0x00069C20
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F29 RID: 3881
	public Shader SCShader;

	// Token: 0x04000F2A RID: 3882
	[Range(0f, 1f)]
	public float _AlphaHexa = 1f;

	// Token: 0x04000F2B RID: 3883
	private float TimeX = 1f;

	// Token: 0x04000F2C RID: 3884
	private Material SCMaterial;

	// Token: 0x04000F2D RID: 3885
	[Range(-20f, 20f)]
	public float ShapeFormula = 10f;

	// Token: 0x04000F2E RID: 3886
	[Range(0f, 6f)]
	public float Shape = 1f;

	// Token: 0x04000F2F RID: 3887
	[Range(-4f, 4f)]
	public float _BorderSize = 1f;

	// Token: 0x04000F30 RID: 3888
	public Color _BorderColor = new Color(0f, 0.2f, 1f, 1f);

	// Token: 0x04000F31 RID: 3889
	public float _SpotSize = 2.5f;

	// Token: 0x04000F32 RID: 3890
	public Vector2 center = new Vector2(0f, 0f);

	// Token: 0x04000F33 RID: 3891
	public float Radius = 0.77f;
}
