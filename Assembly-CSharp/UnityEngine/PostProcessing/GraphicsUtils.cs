namespace UnityEngine.PostProcessing
{
	public static class GraphicsUtils
	{
		private static Texture2D s_WhiteTexture;

		private static Mesh s_Quad;

		public static bool isLinearColorSpace
		{
			get
			{
				return QualitySettings.activeColorSpace == ColorSpace.Linear;
			}
		}

		public static bool supportsDX11
		{
			get
			{
				if (SystemInfo.graphicsShaderLevel >= 50)
				{
					return SystemInfo.supportsComputeShaders;
				}
				return false;
			}
		}

		public static Texture2D whiteTexture
		{
			get
			{
				if (s_WhiteTexture != null)
				{
					return s_WhiteTexture;
				}
				s_WhiteTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
				s_WhiteTexture.SetPixel(0, 0, new Color(1f, 1f, 1f, 1f));
				s_WhiteTexture.Apply();
				return s_WhiteTexture;
			}
		}

		public static Mesh quad
		{
			get
			{
				if (s_Quad != null)
				{
					return s_Quad;
				}
				Vector3[] vertices = new Vector3[4]
				{
					new Vector3(-1f, -1f, 0f),
					new Vector3(1f, 1f, 0f),
					new Vector3(1f, -1f, 0f),
					new Vector3(-1f, 1f, 0f)
				};
				Vector2[] uv = new Vector2[4]
				{
					new Vector2(0f, 0f),
					new Vector2(1f, 1f),
					new Vector2(1f, 0f),
					new Vector2(0f, 1f)
				};
				int[] triangles = new int[6] { 0, 1, 2, 1, 0, 3 };
				s_Quad = new Mesh
				{
					vertices = vertices,
					uv = uv,
					triangles = triangles
				};
				s_Quad.RecalculateNormals();
				s_Quad.RecalculateBounds();
				return s_Quad;
			}
		}

		public static void Blit(Material material, int pass)
		{
			GL.PushMatrix();
			GL.LoadOrtho();
			material.SetPass(pass);
			GL.Begin(5);
			GL.TexCoord2(0f, 0f);
			GL.Vertex3(0f, 0f, 0.1f);
			GL.TexCoord2(1f, 0f);
			GL.Vertex3(1f, 0f, 0.1f);
			GL.TexCoord2(0f, 1f);
			GL.Vertex3(0f, 1f, 0.1f);
			GL.TexCoord2(1f, 1f);
			GL.Vertex3(1f, 1f, 0.1f);
			GL.End();
			GL.PopMatrix();
		}

		public static void ClearAndBlit(Texture source, RenderTexture destination, Material material, int pass, bool clearColor = true, bool clearDepth = false)
		{
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = destination;
			GL.Clear(false, clearColor, Color.clear);
			GL.PushMatrix();
			GL.LoadOrtho();
			material.SetTexture("_MainTex", source);
			material.SetPass(pass);
			GL.Begin(5);
			GL.TexCoord2(0f, 0f);
			GL.Vertex3(0f, 0f, 0.1f);
			GL.TexCoord2(1f, 0f);
			GL.Vertex3(1f, 0f, 0.1f);
			GL.TexCoord2(0f, 1f);
			GL.Vertex3(0f, 1f, 0.1f);
			GL.TexCoord2(1f, 1f);
			GL.Vertex3(1f, 1f, 0.1f);
			GL.End();
			GL.PopMatrix();
			RenderTexture.active = active;
		}

		public static void Destroy(Object obj)
		{
			if (obj != null)
			{
				Object.Destroy(obj);
			}
		}

		public static void Dispose()
		{
			Destroy(s_Quad);
		}
	}
}
