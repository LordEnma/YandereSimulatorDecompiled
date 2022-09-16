// Decompiled with JetBrains decompiler
// Type: SerializableDictionary`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

public class SerializableDictionary<K, V> : 
  Dictionary<K, V>,
  ISerializationCallbackReceiver,
  IXmlSerializable
{
  [SerializeField]
  private List<K> keys;
  [SerializeField]
  private List<V> values;
  private const string XML_Item = "Item";
  private const string XML_Key = "Key";
  private const string XML_Value = "Value";

  public SerializableDictionary()
  {
    this.keys = new List<K>();
    this.values = new List<V>();
  }

  public void OnBeforeSerialize()
  {
    this.keys.Clear();
    this.values.Clear();
    foreach (KeyValuePair<K, V> keyValuePair in (Dictionary<K, V>) this)
    {
      this.keys.Add(keyValuePair.Key);
      this.values.Add(keyValuePair.Value);
    }
  }

  public void OnAfterDeserialize()
  {
    this.Clear();
    for (int index = 0; index < this.keys.Count; ++index)
      this.Add(this.keys[index], this.values[index]);
  }

  public XmlSchema GetSchema() => (XmlSchema) null;

  public void ReadXml(XmlReader reader)
  {
    XmlSerializer xmlSerializer1 = new XmlSerializer(typeof (K));
    XmlSerializer xmlSerializer2 = new XmlSerializer(typeof (V));
    int num = reader.IsEmptyElement ? 1 : 0;
    reader.Read();
    if (num != 0)
      return;
    while (reader.NodeType != XmlNodeType.EndElement)
    {
      reader.ReadStartElement("Item");
      reader.ReadStartElement("Key");
      K key = (K) xmlSerializer1.Deserialize(reader);
      reader.ReadEndElement();
      reader.ReadStartElement("Value");
      V v = (V) xmlSerializer2.Deserialize(reader);
      reader.ReadEndElement();
      this.Add(key, v);
      reader.ReadEndElement();
      int content = (int) reader.MoveToContent();
    }
    reader.ReadEndElement();
  }

  public void WriteXml(XmlWriter writer)
  {
    XmlSerializer xmlSerializer1 = new XmlSerializer(typeof (K));
    XmlSerializer xmlSerializer2 = new XmlSerializer(typeof (V));
    foreach (KeyValuePair<K, V> keyValuePair in (Dictionary<K, V>) this)
    {
      writer.WriteStartElement("Item");
      writer.WriteStartElement("Key");
      xmlSerializer1.Serialize(writer, (object) keyValuePair.Key);
      writer.WriteEndElement();
      writer.WriteStartElement("Value");
      xmlSerializer2.Serialize(writer, (object) keyValuePair.Value);
      writer.WriteEndElement();
      writer.WriteEndElement();
    }
  }
}
