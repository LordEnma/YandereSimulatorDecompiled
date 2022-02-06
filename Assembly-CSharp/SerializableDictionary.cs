using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x02000499 RID: 1177
public class SerializableDictionary<K, V> : Dictionary<K, V>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F52 RID: 8018 RVA: 0x001B92F7 File Offset: 0x001B74F7
	public SerializableDictionary()
	{
		this.keys = new List<K>();
		this.values = new List<V>();
	}

	// Token: 0x06001F53 RID: 8019 RVA: 0x001B9318 File Offset: 0x001B7518
	public void OnBeforeSerialize()
	{
		this.keys.Clear();
		this.values.Clear();
		foreach (KeyValuePair<K, V> keyValuePair in this)
		{
			this.keys.Add(keyValuePair.Key);
			this.values.Add(keyValuePair.Value);
		}
	}

	// Token: 0x06001F54 RID: 8020 RVA: 0x001B939C File Offset: 0x001B759C
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.keys.Count; i++)
		{
			base.Add(this.keys[i], this.values[i]);
		}
	}

	// Token: 0x06001F55 RID: 8021 RVA: 0x001B93E3 File Offset: 0x001B75E3
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F56 RID: 8022 RVA: 0x001B93E8 File Offset: 0x001B75E8
	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(K));
		XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(V));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (isEmptyElement)
		{
			return;
		}
		while (reader.NodeType != XmlNodeType.EndElement)
		{
			reader.ReadStartElement("Item");
			reader.ReadStartElement("Key");
			K key = (K)((object)xmlSerializer.Deserialize(reader));
			reader.ReadEndElement();
			reader.ReadStartElement("Value");
			V value = (V)((object)xmlSerializer2.Deserialize(reader));
			reader.ReadEndElement();
			base.Add(key, value);
			reader.ReadEndElement();
			reader.MoveToContent();
		}
		reader.ReadEndElement();
	}

	// Token: 0x06001F57 RID: 8023 RVA: 0x001B9494 File Offset: 0x001B7694
	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(K));
		XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(V));
		foreach (KeyValuePair<K, V> keyValuePair in this)
		{
			writer.WriteStartElement("Item");
			writer.WriteStartElement("Key");
			xmlSerializer.Serialize(writer, keyValuePair.Key);
			writer.WriteEndElement();
			writer.WriteStartElement("Value");
			xmlSerializer2.Serialize(writer, keyValuePair.Value);
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
	}

	// Token: 0x04004173 RID: 16755
	[SerializeField]
	private List<K> keys;

	// Token: 0x04004174 RID: 16756
	[SerializeField]
	private List<V> values;

	// Token: 0x04004175 RID: 16757
	private const string XML_Item = "Item";

	// Token: 0x04004176 RID: 16758
	private const string XML_Key = "Key";

	// Token: 0x04004177 RID: 16759
	private const string XML_Value = "Value";
}
