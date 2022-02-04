using System;
using UnityEngine;

// Token: 0x02000140 RID: 320
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Screen")]
public class CameraFilterPack_Blend2Camera_Screen : MonoBehaviour
{
	// Token: 0x17000244 RID: 580
	// (get) Token: 0x06000C30 RID: 3120 RVA: 0x0007076F File Offset: 0x0006E96F
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

	// Token: 0x06000C31 RID: 3121 RVA: 0x000707A4 File Offset: 0x0006E9A4
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

	// Token: 0x06000C32 RID: 3122 RVA: 0x00070808 File Offset: 0x0006EA08
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

	// Token: 0x06000C33 RID: 3123 RVA: 0x000708F8 File Offset: 0x0006EAF8
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C34 RID: 3124 RVA: 0x00070930 File Offset: 0x0006EB30
	private void Update()
	{
	}

	// Token: 0x06000C35 RID: 3125 RVA: 0x00070932 File Offset: 0x0006EB32
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C36 RID: 3126 RVA: 0x0007096A File Offset: 0x0006EB6A
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

	// Token: 0x04001066 RID: 4198
	private string ShaderName = "CameraFilterPack/Blend2Camera_Screen";

	// Token: 0x04001067 RID: 4199
	public Shader SCShader;

	// Token: 0x04001068 RID: 4200
	public Camera Camera2;

	// Token: 0x04001069 RID: 4201
	private float TimeX = 1f;

	// Token: 0x0400106A RID: 4202
	private Material SCMaterial;

	// Token: 0x0400106B RID: 4203
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400106C RID: 4204
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400106D RID: 4205
	private RenderTexture Camera2tex;
}
