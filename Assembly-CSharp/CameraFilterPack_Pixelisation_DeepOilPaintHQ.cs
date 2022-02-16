using System;
using UnityEngine;

// Token: 0x020001F8 RID: 504
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/Deep OilPaint HQ")]
public class CameraFilterPack_Pixelisation_DeepOilPaintHQ : MonoBehaviour
{
	// Token: 0x170002FC RID: 764
	// (get) Token: 0x060010B2 RID: 4274 RVA: 0x00084A1F File Offset: 0x00082C1F
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

	// Token: 0x060010B3 RID: 4275 RVA: 0x00084A53 File Offset: 0x00082C53
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Deep_OilPaintHQ");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010B4 RID: 4276 RVA: 0x00084A74 File Offset: 0x00082C74
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
			if (this.AutoAnimatedNear)
			{
				this._Distance += Time.deltaTime * this.AutoAnimatedNearSpeed;
				if (this._Distance > 1f)
				{
					this._Distance = -1f;
				}
				if (this._Distance < -1f)
				{
					this._Distance = 1f;
				}
				this.material.SetFloat("_Near", this._Distance);
			}
			else
			{
				this.material.SetFloat("_Near", this._Distance);
			}
			this.material.SetFloat("_Far", this._Size);
			this.material.SetFloat("_FixDistance", this._FixDistance);
			this.material.SetFloat("_LightIntensity", this.Intensity);
			this.material.SetFloat("_Visualize", (float)(this._Visualize ? 1 : 0));
			float farClipPlane = base.GetComponent<Camera>().farClipPlane;
			this.material.SetFloat("_FarCamera", 1000f / farClipPlane);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010B5 RID: 4277 RVA: 0x00084C21 File Offset: 0x00082E21
	private void Update()
	{
	}

	// Token: 0x060010B6 RID: 4278 RVA: 0x00084C23 File Offset: 0x00082E23
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400153A RID: 5434
	public Shader SCShader;

	// Token: 0x0400153B RID: 5435
	private float TimeX = 1f;

	// Token: 0x0400153C RID: 5436
	public bool _Visualize;

	// Token: 0x0400153D RID: 5437
	private Material SCMaterial;

	// Token: 0x0400153E RID: 5438
	[Range(0f, 100f)]
	public float _FixDistance = 1.5f;

	// Token: 0x0400153F RID: 5439
	[Range(-0.99f, 0.99f)]
	public float _Distance = 0.4f;

	// Token: 0x04001540 RID: 5440
	[Range(0f, 0.5f)]
	public float _Size = 0.5f;

	// Token: 0x04001541 RID: 5441
	[Range(0f, 8f)]
	public float Intensity = 1f;

	// Token: 0x04001542 RID: 5442
	public bool AutoAnimatedNear;

	// Token: 0x04001543 RID: 5443
	[Range(-5f, 5f)]
	public float AutoAnimatedNearSpeed = 0.5f;

	// Token: 0x04001544 RID: 5444
	public static Color ChangeColorRGB;
}
