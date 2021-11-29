using System;
using UnityEngine;

// Token: 0x0200011A RID: 282
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Super Computer")]
public class CameraFilterPack_AAA_SuperComputer : MonoBehaviour
{
	// Token: 0x1700021F RID: 543
	// (get) Token: 0x06000B1C RID: 2844 RVA: 0x0006AE30 File Offset: 0x00069030
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

	// Token: 0x06000B1D RID: 2845 RVA: 0x0006AE64 File Offset: 0x00069064
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/AAA_Super_Computer");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B1E RID: 2846 RVA: 0x0006AE88 File Offset: 0x00069088
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

	// Token: 0x06000B1F RID: 2847 RVA: 0x0006AFFE File Offset: 0x000691FE
	private void Update()
	{
	}

	// Token: 0x06000B20 RID: 2848 RVA: 0x0006B000 File Offset: 0x00069200
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F11 RID: 3857
	public Shader SCShader;

	// Token: 0x04000F12 RID: 3858
	[Range(0f, 1f)]
	public float _AlphaHexa = 1f;

	// Token: 0x04000F13 RID: 3859
	private float TimeX = 1f;

	// Token: 0x04000F14 RID: 3860
	private Material SCMaterial;

	// Token: 0x04000F15 RID: 3861
	[Range(-20f, 20f)]
	public float ShapeFormula = 10f;

	// Token: 0x04000F16 RID: 3862
	[Range(0f, 6f)]
	public float Shape = 1f;

	// Token: 0x04000F17 RID: 3863
	[Range(-4f, 4f)]
	public float _BorderSize = 1f;

	// Token: 0x04000F18 RID: 3864
	public Color _BorderColor = new Color(0f, 0.2f, 1f, 1f);

	// Token: 0x04000F19 RID: 3865
	public float _SpotSize = 2.5f;

	// Token: 0x04000F1A RID: 3866
	public Vector2 center = new Vector2(0f, 0f);

	// Token: 0x04000F1B RID: 3867
	public float Radius = 0.77f;
}
