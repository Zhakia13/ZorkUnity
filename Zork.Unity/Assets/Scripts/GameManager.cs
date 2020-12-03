using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using Zork;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private string GameFilename = "Zork";

    [SerializeField]
    private UnityInputService InputService;

    [SerializeField]
    private UnityOutputService OutputService;

    [SerializeField]
    private TextMeshProUGUI LocationText;

    [SerializeField]
    private TextMeshProUGUI MovesText;

    [SerializeField]
    private TextMeshProUGUI ScoreText;

    private void Start()
    {
        TextAsset gameTextAsset = Resources.Load<TextAsset>(GameFilename);
        _game = JsonConvert.DeserializeObject<Game>(gameTextAsset.text);
        Assert.IsNotNull(_game);

        _game.Initialize(InputService, OutputService);
        _game.Player.LocationChanged += (sender, e) => LocationText.text = e.NewLocation != null ? e.NewLocation.Name : "Unknown";
        _game.Player.ScoreChanged += (sender, e) => ScoreText.text = $"Score: {e}";
        _game.Player.MovesChanged += (sender, e) => MovesText.text = $"Moves: {e}";

        LocationText.text = _game.Player.Location.Name;
        InputService.InputField.Select();
        InputService.InputField.ActivateInputField();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return) && string.IsNullOrEmpty(InputService.InputField.text) == false)
        {
            OutputService.WriteLine($"> {InputService.InputField.text}");
            InputService.ProcessInput();
            OutputService.WriteLine(string.Empty);
            InputService.InputField.Select();
            InputService.InputField.ActivateInputField();
        }

        if (_game.IsRunning == false)
        {
#if UNITY_EDITOR
            // Application.Quit() does not work in editor so                  
            // UnityEditor.EditorApplication.isPlaying need to be set to false
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    private Game _game;

}