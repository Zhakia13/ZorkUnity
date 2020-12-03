using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zork;
using TMPro;
using System.Collections.Generic;

public class UnityOutputService : MonoBehaviour, IOutputService
{
    [SerializeField]
    [Range(10, 100)]
    private int MaxEntries = 60;

    [SerializeField]
    private Transform OutputTextContainer;

    [SerializeField]
    private TextMeshProUGUI TextLinePrefab;

    [SerializeField]
    private Image NewLinePrefab;

    public UnityOutputService() => _entries = new List<GameObject>(MaxEntries);
   
    public void Write(string value) => WriteLine(value);

    public void Write(object value) => WriteLine(value.ToString());

    public void WriteLine(object value) => WriteLine(value.ToString());

    public void WriteLine(string value)
    {
        var lines = value.Split(LineDelimiters, StringSplitOptions.None);
        foreach (var line in lines)
        {
            if(_entries.Count >= MaxEntries)
            {
                var entry = _entries.First();
                Destroy(entry);
                _entries.Remove(entry);
            }

            if (string.IsNullOrWhiteSpace(line))
            {
                WriteNewLine();
            }
            else
            {
                WriteLineText(line);
            }
        }
    }

    private void WriteLineText(string value)
    {
        var textLine = Instantiate(TextLinePrefab, OutputTextContainer);
        textLine.text = value;    

        _entries.Add(textLine.gameObject);
    }

    private void WriteNewLine()
    {
       var newLine = Instantiate(NewLinePrefab, OutputTextContainer);
        _entries.Add(newLine.gameObject);
    }

    private static readonly string[] LineDelimiters = { "\n" };

    private readonly List<GameObject> _entries; 
}
