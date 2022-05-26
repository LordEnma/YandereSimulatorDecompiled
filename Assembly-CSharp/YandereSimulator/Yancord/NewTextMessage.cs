// Decompiled with JetBrains decompiler
// Type: YandereSimulator.Yancord.NewTextMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
  [Serializable]
  public class NewTextMessage
  {
    public string Message;
    public bool isQuestion;
    public bool sentByPlayer;
    public bool isSystemMessage;
    [Header("== Question Related ==")]
    public string OptionQ;
    public string OptionR;
    public string OptionF;
    [Space(20f)]
    public string ReactionQ;
    public string ReactionR;
    public string ReactionF;
  }
}
