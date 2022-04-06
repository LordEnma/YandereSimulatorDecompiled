using System;
using UnityEngine;

// Token: 0x02000127 RID: 295
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Chroma Key/BlueScreen")]
public class CameraFilterPack_Blend2Camera_BlueScreen : MonoBehaviour
{
	// Token: 0x1700022B RID: 555
	// (get) Token: 0x06000B6C RID: 2924 RVA: 0x0006D1AF File Offset: 0x0006B3AF
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

	// Token: 0x06000B6D RID: 2925 RVA: 0x0006D1E3 File Offset: 0x0006B3E3
	private void OnValidate()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
	}

	// Token: 0x06000B6E RID: 2926 RVA: 0x0006D208 File Offset: 0x0006B408
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture((int)this.ScreenSize.x, (int)this.ScreenSize.y, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B6F RID: 2927 RVA: 0x0006D27C File Offset: 0x0006B47C
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			if (this.Camera2 != null)
			{
				this.material.SetTexture("_MainTex2", this.Camera2tex);
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetFloat("_Value2", this.Adjust);
			this.material.SetFloat("_Value3", this.Precision);
			this.material.SetFloat("_Value4", this.Luminosity);
			this.material.SetFloat("_Value5", this.Change_Red);
			this.material.SetFloat("_Value6", this.Change_Green);
			this.material.SetFloat("_Value7", this.Change_Blue);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B70 RID: 2928 RVA: 0x0006D3AD File Offset: 0x0006B5AD
	private void Update()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
		bool isPlaying = Application.isPlaying;
	}

	// Token: 0x06000B71 RID: 2929 RVA: 0x0006D3D7 File Offset: 0x0006B5D7
	private void OnEnable()
	{
		this.Start();
	}

	// Token: 0x06000B72 RID: 2930 RVA: 0x0006D3DF File Offset: 0x0006B5DF
	private void OnDisable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2.targetTexture = null;
		}
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F9C RID: 3996
	private string ShaderName = "CameraFilterPack/Blend2Camera_BlueScreen";

	// Token: 0x04000F9D RID: 3997
	public Shader SCShader;

	// Token: 0x04000F9E RID: 3998
	public Camera Camera2;

	// Token: 0x04000F9F RID: 3999
	private float TimeX = 1f;

	// Token: 0x04000FA0 RID: 4000
	private Material SCMaterial;

	// Token: 0x04000FA1 RID: 4001
	[Range(0f, 1f)]
	public float BlendFX = 1f;

	// Token: 0x04000FA2 RID: 4002
	[Range(-0.2f, 0.2f)]
	public float Adjust;

	// Token: 0x04000FA3 RID: 4003
	[Range(-0.2f, 0.2f)]
	public float Precision;

	// Token: 0x04000FA4 RID: 4004
	[Range(-0.2f, 0.2f)]
	public float Luminosity;

	// Token: 0x04000FA5 RID: 4005
	[Range(-0.3f, 0.3f)]
	public float Change_Red;

	// Token: 0x04000FA6 RID: 4006
	[Range(-0.3f, 0.3f)]
	public float Change_Green;

	// Token: 0x04000FA7 RID: 4007
	[Range(-0.3f, 0.3f)]
	public float Change_Blue;

	// Token: 0x04000FA8 RID: 4008
	private RenderTexture Camera2tex;

	// Token: 0x04000FA9 RID: 4009
	private Vector2 ScreenSize;
}
