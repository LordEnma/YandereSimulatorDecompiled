using System;
using UnityEngine;

// Token: 0x02000144 RID: 324
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Subtract")]
public class CameraFilterPack_Blend2Camera_Subtract : MonoBehaviour
{
	// Token: 0x17000248 RID: 584
	// (get) Token: 0x06000C51 RID: 3153 RVA: 0x000715C5 File Offset: 0x0006F7C5
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

	// Token: 0x06000C52 RID: 3154 RVA: 0x000715FC File Offset: 0x0006F7FC
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

	// Token: 0x06000C53 RID: 3155 RVA: 0x00071660 File Offset: 0x0006F860
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

	// Token: 0x06000C54 RID: 3156 RVA: 0x00071750 File Offset: 0x0006F950
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C55 RID: 3157 RVA: 0x00071788 File Offset: 0x0006F988
	private void Update()
	{
	}

	// Token: 0x06000C56 RID: 3158 RVA: 0x0007178A File Offset: 0x0006F98A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C57 RID: 3159 RVA: 0x000717C2 File Offset: 0x0006F9C2
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

	// Token: 0x040010A1 RID: 4257
	private string ShaderName = "CameraFilterPack/Blend2Camera_Subtract";

	// Token: 0x040010A2 RID: 4258
	public Shader SCShader;

	// Token: 0x040010A3 RID: 4259
	public Camera Camera2;

	// Token: 0x040010A4 RID: 4260
	private float TimeX = 1f;

	// Token: 0x040010A5 RID: 4261
	private Material SCMaterial;

	// Token: 0x040010A6 RID: 4262
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x040010A7 RID: 4263
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x040010A8 RID: 4264
	private RenderTexture Camera2tex;
}
