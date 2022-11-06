// Decompiled with JetBrains decompiler
// Type: INGUIAtlas
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public interface INGUIAtlas
{
  Material spriteMaterial { get; set; }

  List<UISpriteData> spriteList { get; set; }

  Texture texture { get; }

  float pixelSize { get; set; }

  bool premultipliedAlpha { get; }

  INGUIAtlas replacement { get; set; }

  UISpriteData GetSprite(string name);

  BetterList<string> GetListOfSprites();

  BetterList<string> GetListOfSprites(string match);

  bool References(INGUIAtlas atlas);

  void MarkAsChanged();

  void SortAlphabetically();
}
