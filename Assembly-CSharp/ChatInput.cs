// Decompiled with JetBrains decompiler
// Type: ChatInput
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (UIInput))]
[AddComponentMenu("NGUI/Examples/Chat Input")]
public class ChatInput : MonoBehaviour
{
  public UITextList textList;
  public bool fillWithDummyData;
  private UIInput mInput;

  private void Start()
  {
    this.mInput = this.GetComponent<UIInput>();
    this.mInput.label.maxLineCount = 1;
    if (!this.fillWithDummyData || !((Object) this.textList != (Object) null))
      return;
    for (int index = 0; index < 30; ++index)
      this.textList.Add((index % 2 == 0 ? "[FFFFFF]" : "[AAAAAA]") + "This is an example paragraph for the text list, testing line " + index.ToString() + "[-]");
  }

  public void OnSubmit()
  {
    if (!((Object) this.textList != (Object) null))
      return;
    string text = NGUIText.StripSymbols(this.mInput.value);
    if (string.IsNullOrEmpty(text))
      return;
    this.textList.Add(text);
    this.mInput.value = "";
    this.mInput.isSelected = false;
  }
}
