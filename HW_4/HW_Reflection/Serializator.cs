﻿

using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace HW_Reflection;

public class CsvSerializer<T> where T : class, new()
{
    public char Separator { get; set; } = '=';
    public string? Replacement { get; set; } = " ";
    private List<PropertyInfo> _properties;


    public CsvSerializer()
    {
        var type = typeof(T);

        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance
             | BindingFlags.GetProperty | BindingFlags.SetProperty);

        _properties = (from a in properties
                       where a.GetCustomAttribute<IgnoreFieldAttribute>() == null
                       orderby a.Name
                       select a).ToList();
    }

    public IList<T> Deserialize(Stream stream)
    {
        string[] columns;
        string[] rows;

        try
        {
            using (var sr = new StreamReader(stream))
            {
                columns = sr.ReadLine()!.Split(Separator);
                rows = sr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Invalid.", ex);
        }

        var data = new List<T>();
        for (int row = 0; row < rows.Length; row++)
        {
            var line = rows[row];
            if (string.IsNullOrWhiteSpace(line))
            {
                throw new Exception(string.Format( @"Error line: {0}", row));
            }

            var parts = line.Split(Separator);
            var datum = new T();

            for (int i = 0; i < parts.Length; i++)
            {
                var value = parts[i];
                var column = columns[i];
                value = value.Replace(Replacement!, Separator.ToString());
                var p = _properties.First(a => a.Name == column);
                var converter = TypeDescriptor.GetConverter(p.PropertyType);
                var convertedvalue = converter.ConvertFrom(value);
                p.SetValue(datum, convertedvalue);
            }
            data.Add(datum);
        }
        return data;
    }

    public void Serialize(Stream stream, IList<T> data)
    {
        var sb = new StringBuilder();
        var values = new List<string>();

        sb.AppendLine(GetHeader());

        foreach (var item in data)
        {
            values.Clear();
            foreach (var p in _properties)
            {
                var raw = p.GetValue(item);
                var value = raw == null ?
                            "" :
                            raw.ToString()?.Replace(Separator.ToString(), Replacement);
                values.Add(value!);
            }
            sb.AppendLine(string.Join(Separator.ToString(), values.ToArray()));
        }

        using (var sw = new StreamWriter(stream))
        {
            sw.Write(sb.ToString().Trim());
        }
    }
    private string GetHeader()
    {
        var columns = _properties.Select(a => a.Name).ToArray();
        var header = string.Join(Separator.ToString(), columns);
        return header;
    }
}
