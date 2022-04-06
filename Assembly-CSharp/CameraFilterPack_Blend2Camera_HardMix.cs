using System;
using UnityEngine;

// Token: 0x02000133 RID: 307
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/HardMix")]
public class CameraFilterPack_Blend2Camera_HardMix : MonoBehaviour
{
	// Token: 0x17000237 RID: 567
	// (get) Token: 0x06000BCA RID: 3018 RVA: 0x0006EE87 File Offset: 0x0006D087
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

	// Token: 0x06000BCB RID: 3019 RVA: 0x0006EEBC File Offset: 0x0006D0BC
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

	// Token: 0x06000BCC RID: 3020 RVA: 0x0006EF20 File Offset: 0x0006D120
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

	// Token: 0x06000BCD RID: 3021 RVA: 0x0006F010 File Offset: 0x0006D210
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BCE RID: 3022 RVA: 0x0006F048 File Offset: 0x0006D248
	private void Update()
	{
	}

	// Token: 0x06000BCF RID: 3023 RVA: 0x0006F04A File Offset: 0x0006D24A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BD0 RID: 3024 RVA: 0x0006F082 File Offset: 0x0006D282
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

	// Token: 0x0400100F RID: 4111
	private string ShaderName = "CameraFilterPack/Blend2Camera_HardMix";

	// Token: 0x04001010 RID: 4112
	public Shader SCShader;

	// Token: 0x04001011 RID: 4113
	public Camera Camera2;

	// Token: 0x04001012 RID: 4114
	private float TimeX = 1f;

	// Token: 0x04001013 RID: 4115
	private Material SCMaterial;

	// Token: 0x04001014 RID: 4116
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001015 RID: 4117
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001016 RID: 4118
	private RenderTexture Camera2tex;
}
