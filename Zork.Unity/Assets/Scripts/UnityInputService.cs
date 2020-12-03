using System;
using UnityEngine;
using Zork;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class UnityInputService : MonoBehaviour, IInputService
{
   // [SerializeField]
   // private int MaxEntries = 5;

    public TMP_InputField InputField;

    public event EventHandler<string> InputReceived;

  //  public UnityInputService() => _entries = new List<string>(MaxEntries);

    public void ProcessInput()
    {
        Assert.IsNotNull(InputField);
        Assert.IsFalse(string.IsNullOrEmpty(InputField.text));

  //      _entries.Add(InputField.text);

        InputReceived?.Invoke(this, InputField.text);
        InputField.text = string.Empty;

 //      if (_entries.Count >= MaxEntries)
 //      {
 //          var entry = _entries.Last();
 //          _entries.Remove(entry);
 //      }
 //  }

 //  private void Update()
 //  {
 //      if (Input.GetKey(KeyCode.UpArrow))
 //      {
 //          MaxEntries--;
 //       
 //
 //      }
 //     else if (Input.GetKey(KeyCode.DownArrow))
 //      {
 //          MaxEntries++;
 //      }
  }
 
  private readonly List<string> _entries;
}
