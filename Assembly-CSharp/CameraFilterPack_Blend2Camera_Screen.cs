using System;
using UnityEngine;

// Token: 0x02000140 RID: 320
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Screen")]
public class CameraFilterPack_Blend2Camera_Screen : MonoBehaviour
{
	// Token: 0x17000244 RID: 580
	// (get) Token: 0x06000C31 RID: 3121 RVA: 0x00070B1B File Offset: 0x0006ED1B
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

	// Token: 0x06000C32 RID: 3122 RVA: 0x00070B50 File Offset: 0x0006ED50
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C33 RID: 3123 RVA: 0x00070BB4 File Offset: 0x0006EDB4
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
			this.material.SetFloat("_Value2", this.SwitchCameraToCamera2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C34 RID: 3124 RVA: 0x00070CA4 File Offset: 0x0006EEA4
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C35 RID: 3125 RVA: 0x00070CDC File Offset: 0x0006EEDC
	private void Update()
	{
	}

	// Token: 0x06000C36 RID: 3126 RVA: 0x00070CDE File Offset: 0x0006EEDE
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C37 RID: 3127 RVA: 0x00070D16 File Offset: 0x0006EF16
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

	// Token: 0x04001072 RID: 4210
	private string ShaderName = "CameraFilterPack/Blend2Camera_Screen";

	// Token: 0x04001073 RID: 4211
	public Shader SCShader;

	// Token: 0x04001074 RID: 4212
	public Camera Camera2;

	// Token: 0x04001075 RID: 4213
	private float TimeX = 1f;

	// Token: 0x04001076 RID: 4214
	private Material SCMaterial;

	// Token: 0x04001077 RID: 4215
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001078 RID: 4216
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001079 RID: 4217
	private RenderTexture Camera2tex;
}
