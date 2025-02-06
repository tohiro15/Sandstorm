using TMPro;
using UnityEngine;

public class FpsSensor : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        float fps = 1f / Time.deltaTime;
        _text.text = $"FPS: {Mathf.RoundToInt(fps)}";
    }
}
