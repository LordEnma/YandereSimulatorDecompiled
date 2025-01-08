using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Texture")]
public class UITexture : UIBasicSprite
{
	[HideInInspector]
	[SerializeField]
	private Rect mRect = new Rect(0f, 0f, 1f, 1f);

	[HideInInspector]
	[SerializeField]
	private Texture mTexture;

	[HideInInspector]
	[SerializeField]
	private Shader mShader;

	[HideInInspector]
	[SerializeField]
	private Vector4 mBorder = Vector4.zero;

	[HideInInspector]
	[SerializeField]
	private bool mFixedAspect;

	[NonSerialized]
	private int mPMA = -1;

	public override Texture mainTexture
	{
		get
		{
			if (mTexture != null)
			{
				return mTexture;
			}
			if (mMat != null)
			{
				return mMat.mainTexture;
			}
			return null;
		}
		set
		{
			if (mTexture != value)
			{
				if (drawCall != null && drawCall.widgetCount == 1 && mMat == null)
				{
					mTexture = value;
					drawCall.mainTexture = value;
					return;
				}
				RemoveFromPanel();
				mTexture = value;
				mPMA = -1;
				MarkAsChanged();
			}
		}
	}

	public override Material material
	{
		get
		{
			return mMat;
		}
		set
		{
			if (mMat != value)
			{
				RemoveFromPanel();
				mShader = null;
				mMat = value;
				mPMA = -1;
				MarkAsChanged();
			}
		}
	}

	public override Shader shader
	{
		get
		{
			if (mMat != null)
			{
				return mMat.shader;
			}
			if (mShader == null)
			{
				mShader = Shader.Find("Unlit/Transparent Colored");
			}
			return mShader;
		}
		set
		{
			if (mShader != value)
			{
				if (drawCall != null && drawCall.widgetCount == 1 && mMat == null)
				{
					mShader = value;
					drawCall.shader = value;
					return;
				}
				RemoveFromPanel();
				mShader = value;
				mPMA = -1;
				mMat = null;
				MarkAsChanged();
			}
		}
	}

	public override bool premultipliedAlpha
	{
		get
		{
			if (mPMA == -1)
			{
				Material material = this.material;
				mPMA = ((material != null && material.shader != null && material.shader.name.Contains("Premultiplied")) ? 1 : 0);
			}
			return mPMA == 1;
		}
	}

	public override Vector4 border
	{
		get
		{
			return mBorder;
		}
		set
		{
			if (mBorder != value)
			{
				mBorder = value;
				MarkAsChanged();
			}
		}
	}

	public Rect uvRect
	{
		get
		{
			return mRect;
		}
		set
		{
			if (mRect != value)
			{
				mRect = value;
				MarkAsChanged();
			}
		}
	}

	public override Vector4 drawingDimensions
	{
		get
		{
			Vector2 vector = base.pivotOffset;
			float num = (0f - vector.x) * (float)mWidth;
			float num2 = (0f - vector.y) * (float)mHeight;
			float num3 = num + (float)mWidth;
			float num4 = num2 + (float)mHeight;
			if (mTexture != null && mType != Type.Tiled)
			{
				int num5 = mTexture.width;
				int num6 = mTexture.height;
				int num7 = 0;
				int num8 = 0;
				float num9 = 1f;
				float num10 = 1f;
				if (num5 > 0 && num6 > 0 && (mType == Type.Simple || mType == Type.Filled))
				{
					if ((num5 & 1) != 0)
					{
						num7++;
					}
					if ((num6 & 1) != 0)
					{
						num8++;
					}
					num9 = 1f / (float)num5 * (float)mWidth;
					num10 = 1f / (float)num6 * (float)mHeight;
				}
				if (mFlip == Flip.Horizontally || mFlip == Flip.Both)
				{
					num += (float)num7 * num9;
				}
				else
				{
					num3 -= (float)num7 * num9;
				}
				if (mFlip == Flip.Vertically || mFlip == Flip.Both)
				{
					num2 += (float)num8 * num10;
				}
				else
				{
					num4 -= (float)num8 * num10;
				}
			}
			float num11;
			float num12;
			if (mFixedAspect)
			{
				num11 = 0f;
				num12 = 0f;
			}
			else
			{
				Vector4 vector2 = border;
				num11 = vector2.x + vector2.z;
				num12 = vector2.y + vector2.w;
			}
			float x = Mathf.Lerp(num, num3 - num11, mDrawRegion.x);
			float y = Mathf.Lerp(num2, num4 - num12, mDrawRegion.y);
			float z = Mathf.Lerp(num + num11, num3, mDrawRegion.z);
			float w = Mathf.Lerp(num2 + num12, num4, mDrawRegion.w);
			return new Vector4(x, y, z, w);
		}
	}

	public bool fixedAspect
	{
		get
		{
			return mFixedAspect;
		}
		set
		{
			if (mFixedAspect != value)
			{
				mFixedAspect = value;
				mDrawRegion = new Vector4(0f, 0f, 1f, 1f);
				MarkAsChanged();
			}
		}
	}

	public override void MakePixelPerfect()
	{
		base.MakePixelPerfect();
		if (mType == Type.Tiled)
		{
			return;
		}
		Texture texture = mainTexture;
		if (!(texture == null) && (mType == Type.Simple || mType == Type.Filled || !base.hasBorder) && texture != null)
		{
			int num = texture.width;
			int num2 = texture.height;
			if ((num & 1) == 1)
			{
				num++;
			}
			if ((num2 & 1) == 1)
			{
				num2++;
			}
			base.width = num;
			base.height = num2;
		}
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (!mFixedAspect)
		{
			return;
		}
		Texture texture = mainTexture;
		if (texture != null)
		{
			int num = texture.width;
			int num2 = texture.height;
			if ((num & 1) == 1)
			{
				num++;
			}
			if ((num2 & 1) == 1)
			{
				num2++;
			}
			float num3 = mWidth;
			float num4 = mHeight;
			float num5 = num3 / num4;
			float num6 = (float)num / (float)num2;
			if (num6 < num5)
			{
				float num7 = (num3 - num4 * num6) / num3 * 0.5f;
				base.drawRegion = new Vector4(num7, 0f, 1f - num7, 1f);
			}
			else
			{
				float num8 = (num4 - num3 / num6) / num4 * 0.5f;
				base.drawRegion = new Vector4(0f, num8, 1f, 1f - num8);
			}
		}
	}

	public override void OnFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
	{
		Texture texture = mainTexture;
		if (!(texture == null))
		{
			Rect rect = new Rect(mRect.x * (float)texture.width, mRect.y * (float)texture.height, (float)texture.width * mRect.width, (float)texture.height * mRect.height);
			Rect inner = rect;
			Vector4 vector = border;
			inner.xMin += vector.x;
			inner.yMin += vector.y;
			inner.xMax -= vector.z;
			inner.yMax -= vector.w;
			float num = 1f / (float)texture.width;
			float num2 = 1f / (float)texture.height;
			rect.xMin *= num;
			rect.xMax *= num;
			rect.yMin *= num2;
			rect.yMax *= num2;
			inner.xMin *= num;
			inner.xMax *= num;
			inner.yMin *= num2;
			inner.yMax *= num2;
			int count = verts.Count;
			Fill(verts, uvs, cols, rect, inner);
			if (onPostFill != null)
			{
				onPostFill(this, count, verts, uvs, cols);
			}
		}
	}
}
