using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004B3 RID: 1203
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001FB7 RID: 8119 RVA: 0x001C13C0 File Offset: 0x001BF5C0
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001FB8 RID: 8120 RVA: 0x001C13D4 File Offset: 0x001BF5D4
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001FB9 RID: 8121 RVA: 0x001C1434 File Offset: 0x001BF634
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001FBA RID: 8122 RVA: 0x001C1470 File Offset: 0x001BF670
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001FBB RID: 8123 RVA: 0x001C1474 File Offset: 0x001BF674
	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (isEmptyElement)
		{
			return;
		}
		while (reader.NodeType != XmlNodeType.EndElement)
		{
			reader.ReadStartElement("Element");
			T item = (T)((object)xmlSerializer.Deserialize(reader));
			reader.ReadEndElement();
			base.Add(item);
			reader.MoveToContent();
		}
	}

	// Token: 0x06001FBC RID: 8124 RVA: 0x001C14D8 File Offset: 0x001BF6D8
	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		foreach (T t in this)
		{
			writer.WriteStartElement("Element");
			xmlSerializer.Serialize(writer, t);
			writer.WriteEndElement();
		}
	}

	// Token: 0x04004270 RID: 17008
	[SerializeField]
	private List<T> elements;

	// Token: 0x04004271 RID: 17009
	private const string XML_Element = "Element";
}
