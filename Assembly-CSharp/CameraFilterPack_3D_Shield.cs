using System;
using UnityEngine;

// Token: 0x02000115 RID: 277
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Shield")]
public class CameraFilterPack_3D_Shield : MonoBehaviour
{
	// Token: 0x17000219 RID: 537
	// (get) Token: 0x06000AFC RID: 2812 RVA: 0x0006A41C File Offset: 0x0006861C
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

	// Token: 0x06000AFD RID: 2813 RVA: 0x0006A450 File Offset: 0x00068650
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/3D_Shield");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000AFE RID: 2814 RVA: 0x0006A474 File Offset: 0x00068674
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
			this.material.SetFloat("_LightIntensity", this.LightIntensity * 64f);
			this.material.SetFloat("_Visualize", (float)(this._Visualize ? 1 : 0));
			this.material.SetFloat("_FadeShield", this._FadeShield);
			this.material.SetFloat("_Value", this.Speed);
			this.material.SetFloat("_Value2", this.Speed_X);
			this.material.SetFloat("_Value3", this.Speed_Y);
			this.material.SetFloat("_Value4", this.Intensity);
			float farClipPlane = base.GetComponent<Camera>().farClipPlane;
			this.material.SetFloat("_FarCamera", 1000f / farClipPlane);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000AFF RID: 2815 RVA: 0x0006A695 File Offset: 0x00068895
	private void Update()
	{
	}

	// Token: 0x06000B00 RID: 2816 RVA: 0x0006A697 File Offset: 0x00068897
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000ED0 RID: 3792
	public Shader SCShader;

	// Token: 0x04000ED1 RID: 3793
	public bool _Visualize;

	// Token: 0x04000ED2 RID: 3794
	private float TimeX = 1f;

	// Token: 0x04000ED3 RID: 3795
	private Material SCMaterial;

	// Token: 0x04000ED4 RID: 3796
	[Range(0f, 100f)]
	public float _FixDistance = 1.5f;

	// Token: 0x04000ED5 RID: 3797
	[Range(-0.99f, 0.99f)]
	public float _Distance = 0.4f;

	// Token: 0x04000ED6 RID: 3798
	[Range(0f, 0.5f)]
	public float _Size = 0.5f;

	// Token: 0x04000ED7 RID: 3799
	[Range(0f, 1f)]
	public float _FadeShield = 0.75f;

	// Token: 0x04000ED8 RID: 3800
	[Range(-0.2f, 0.2f)]
	public float LightIntensity = 0.025f;

	// Token: 0x04000ED9 RID: 3801
	public bool AutoAnimatedNear;

	// Token: 0x04000EDA RID: 3802
	[Range(-5f, 5f)]
	public float AutoAnimatedNearSpeed = 0.5f;

	// Token: 0x04000EDB RID: 3803
	[Range(0f, 10f)]
	public float Speed = 0.2f;

	// Token: 0x04000EDC RID: 3804
	[Range(0f, 10f)]
	public float Speed_X = 0.2f;

	// Token: 0x04000EDD RID: 3805
	[Range(0f, 1f)]
	public float Speed_Y = 0.3f;

	// Token: 0x04000EDE RID: 3806
	[Range(0f, 10f)]
	public float Intensity = 2.4f;

	// Token: 0x04000EDF RID: 3807
	public static Color ChangeColorRGB;
}
