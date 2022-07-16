// Decompiled with JetBrains decompiler
// Type: TweenLetters
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class TweenLetters : UITweener
{
  public TweenLetters.AnimationProperties hoverOver;
  public TweenLetters.AnimationProperties hoverOut;
  private UILabel mLabel;
  private int mVertexCount = -1;
  private int[] mLetterOrder;
  private TweenLetters.LetterProperties[] mLetter;
  private TweenLetters.AnimationProperties mCurrent;

  private void OnEnable()
  {
    this.mVertexCount = -1;
    UILabel mLabel = this.mLabel;
    mLabel.onPostFill = mLabel.onPostFill + new UIWidget.OnPostFillCallback(this.OnPostFill);
  }

  private void OnDisable()
  {
    UILabel mLabel = this.mLabel;
    mLabel.onPostFill = mLabel.onPostFill - new UIWidget.OnPostFillCallback(this.OnPostFill);
  }

  private void Awake()
  {
    this.mLabel = this.GetComponent<UILabel>();
    this.mCurrent = this.hoverOver;
  }

  public override void Play(bool forward)
  {
    this.mCurrent = forward ? this.hoverOver : this.hoverOut;
    base.Play(forward);
  }

  private void OnPostFill(
    UIWidget widget,
    int bufferOffset,
    List<Vector3> verts,
    List<Vector2> uvs,
    List<Color> cols)
  {
    if (verts == null)
      return;
    int count = verts.Count;
    if (verts == null || count == 0)
      return;
    if ((UnityEngine.Object) this.mLabel == (UnityEngine.Object) null)
      return;
    try
    {
      int quadsPerCharacter = this.mLabel.quadsPerCharacter;
      int letterCount = count / quadsPerCharacter / 4;
      string printedText = this.mLabel.printedText;
      if (this.mVertexCount != count)
      {
        this.mVertexCount = count;
        this.SetLetterOrder(letterCount);
        this.GetLetterDuration(letterCount);
      }
      Matrix4x4 identity1 = Matrix4x4.identity;
      Vector3 zero1 = Vector3.zero;
      Quaternion identity2 = Quaternion.identity;
      Vector3 one = Vector3.one;
      Vector3 zero2 = Vector3.zero;
      Quaternion a = Quaternion.Euler(this.mCurrent.rot);
      Vector3 zero3 = Vector3.zero;
      Color clear = Color.clear;
      float num1 = this.tweenFactor * this.duration;
      for (int index1 = 0; index1 < quadsPerCharacter; ++index1)
      {
        for (int index2 = 0; index2 < letterCount; ++index2)
        {
          int index3 = this.mLetterOrder[index2];
          int firstVert = index1 * letterCount * 4 + index3 * 4;
          if (firstVert < count)
          {
            float start = this.mLetter[index3].start;
            float t = this.animationCurve.Evaluate(Mathf.Clamp(num1 - start, 0.0f, this.mLetter[index3].duration) / this.mLetter[index3].duration);
            Vector3 center = TweenLetters.GetCenter(verts, firstVert, 4);
            Vector2 offset = this.mLetter[index3].offset;
            Vector3 pos = Vector3.LerpUnclamped(this.mCurrent.pos + new Vector3(offset.x, offset.y, 0.0f), Vector3.zero, t);
            Quaternion q = Quaternion.SlerpUnclamped(a, Quaternion.identity, t);
            Vector3 s = Vector3.LerpUnclamped(this.mCurrent.scale, Vector3.one, t);
            float num2 = Mathf.LerpUnclamped(this.mCurrent.alpha, 1f, t);
            identity1.SetTRS(pos, q, s);
            for (int index4 = firstVert; index4 < firstVert + 4; ++index4)
            {
              Vector3 point = verts[index4] - center;
              Vector3 vector3 = identity1.MultiplyPoint3x4(point) + center;
              verts[index4] = vector3;
              Color col = cols[index4];
              col.a *= num2;
              cols[index4] = col;
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
      this.enabled = false;
    }
  }

  protected override void OnUpdate(float factor, bool isFinished) => this.mLabel.MarkAsChanged();

  private void SetLetterOrder(int letterCount)
  {
    if (letterCount == 0)
    {
      this.mLetter = (TweenLetters.LetterProperties[]) null;
      this.mLetterOrder = (int[]) null;
    }
    else
    {
      this.mLetterOrder = new int[letterCount];
      this.mLetter = new TweenLetters.LetterProperties[letterCount];
      for (int index1 = 0; index1 < letterCount; ++index1)
      {
        this.mLetterOrder[index1] = this.mCurrent.animationOrder == TweenLetters.AnimationLetterOrder.Reverse ? letterCount - 1 - index1 : index1;
        int index2 = this.mLetterOrder[index1];
        this.mLetter[index2] = new TweenLetters.LetterProperties();
        this.mLetter[index2].offset = new Vector2(UnityEngine.Random.Range(-this.mCurrent.offsetRange.x, this.mCurrent.offsetRange.x), UnityEngine.Random.Range(-this.mCurrent.offsetRange.y, this.mCurrent.offsetRange.y));
      }
      if (this.mCurrent.animationOrder != TweenLetters.AnimationLetterOrder.Random)
        return;
      System.Random random = new System.Random();
      int index3 = letterCount;
      while (index3 > 1)
      {
        int index4 = random.Next(--index3 + 1);
        int num = this.mLetterOrder[index4];
        this.mLetterOrder[index4] = this.mLetterOrder[index3];
        this.mLetterOrder[index3] = num;
      }
    }
  }

  private void GetLetterDuration(int letterCount)
  {
    if (this.mCurrent.randomDurations)
    {
      for (int index = 0; index < this.mLetter.Length; ++index)
      {
        this.mLetter[index].start = UnityEngine.Random.Range(0.0f, this.mCurrent.randomness.x * this.duration);
        float num = UnityEngine.Random.Range(this.mCurrent.randomness.y * this.duration, this.duration);
        this.mLetter[index].duration = num - this.mLetter[index].start;
      }
    }
    else
    {
      float num1 = this.duration / (float) letterCount;
      float num2 = 1f - this.mCurrent.overlap;
      float num3 = num1 * (float) letterCount * num2;
      float num4 = this.ScaleRange(num1, num3 + num1 * this.mCurrent.overlap, this.duration);
      float num5 = 0.0f;
      for (int index1 = 0; index1 < this.mLetter.Length; ++index1)
      {
        int index2 = this.mLetterOrder[index1];
        this.mLetter[index2].start = num5;
        this.mLetter[index2].duration = num4;
        num5 += this.mLetter[index2].duration * num2;
      }
    }
  }

  private float ScaleRange(float value, float baseMax, float limitMax) => limitMax * value / baseMax;

  private static Vector3 GetCenter(List<Vector3> verts, int firstVert, int length)
  {
    Vector3 vert = verts[firstVert];
    for (int index = firstVert + 1; index < firstVert + length; ++index)
      vert += verts[index];
    return vert / (float) length;
  }

  [DoNotObfuscateNGUI]
  public enum AnimationLetterOrder
  {
    Forward,
    Reverse,
    Random,
  }

  private class LetterProperties
  {
    public float start;
    public float duration;
    public Vector2 offset;
  }

  [Serializable]
  public class AnimationProperties
  {
    public TweenLetters.AnimationLetterOrder animationOrder = TweenLetters.AnimationLetterOrder.Random;
    [Range(0.0f, 1f)]
    public float overlap = 0.5f;
    public bool randomDurations;
    [MinMaxRange(0.0f, 1f)]
    public Vector2 randomness = new Vector2(0.25f, 0.75f);
    public Vector2 offsetRange = Vector2.zero;
    public Vector3 pos = Vector3.zero;
    public Vector3 rot = Vector3.zero;
    public Vector3 scale = Vector3.one;
    public float alpha = 1f;
  }
}
