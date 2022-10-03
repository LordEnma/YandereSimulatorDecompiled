// Decompiled with JetBrains decompiler
// Type: SerializableHashSet`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
  [SerializeField]
  private List<T> elements;
  private const string XML_Element = "Element";

  public SerializableHashSet() => this.elements = new List<T>();

  public void OnBeforeSerialize()
  {
    this.elements.Clear();
    foreach (T obj in (HashSet<T>) this)
      this.elements.Add(obj);
  }

  public void OnAfterDeserialize()
  {
    this.Clear();
    for (int index = 0; index < this.elements.Count; ++index)
      this.Add(this.elements[index]);
  }

  public XmlSchema GetSchema() => (XmlSchema) null;

  public void ReadXml(XmlReader reader)
  {
    XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
    int num = reader.IsEmptyElement ? 1 : 0;
    reader.Read();
    if (num != 0)
      return;
    while (reader.NodeType != XmlNodeType.EndElement)
    {
      reader.ReadStartElement("Element");
      T obj = (T) xmlSerializer.Deserialize(reader);
      reader.ReadEndElement();
      this.Add(obj);
      int content = (int) reader.MoveToContent();
    }
  }

  public void WriteXml(XmlWriter writer)
  {
    XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
    foreach (T o in (HashSet<T>) this)
    {
      writer.WriteStartElement("Element");
      xmlSerializer.Serialize(writer, (object) o);
      writer.WriteEndElement();
    }
  }
}
