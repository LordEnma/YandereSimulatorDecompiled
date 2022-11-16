// Decompiled with JetBrains decompiler
// Type: INGUIAtlas
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
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
