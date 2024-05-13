using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _counter;

    private TextMeshProUGUI _score;

    private void Awake()
    {
        _score = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _counter.ScoreChanged += Display;
    }

    private void Display(int score)
    {
        _score.text = score.ToString();
    }
}
