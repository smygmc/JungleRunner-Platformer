using System.Collections;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private GUIStyle _guiStyle = new GUIStyle();
    private int _currentFPS, _maxFPS, _minFPS;

    private int _totalFPSSum = 0;
    private int _totalFpsCalculationCount = 0;

    private int _lastTenSecondsFPSSum = 0;
    private int _lastTenSecondsTotalFPSCalculationCount = 0;

    private bool _showFPS = true;

    private void Awake()
    {
        ChangeGuiStyle();

        _minFPS = 10000;

        StartCoroutine(FPSCalculate());
        StartCoroutine(TenFPSCalculate());
    }

    private void ChangeGuiStyle()
    {
        _guiStyle.fontSize = 32;
        _guiStyle.normal.textColor = Color.yellow;
    }

    private IEnumerator FPSCalculate() //Calculates Fps Values
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);

            _currentFPS = ((int)(1f / Time.unscaledDeltaTime));

            _totalFPSSum += _currentFPS;
            _totalFpsCalculationCount++;

            if (_currentFPS < _minFPS)
                _minFPS = _currentFPS;
            if (_currentFPS > _maxFPS)
                _maxFPS = _currentFPS;

            _lastTenSecondsFPSSum += _currentFPS;
            _lastTenSecondsTotalFPSCalculationCount++;
        }
    }

    private IEnumerator TenFPSCalculate() //Helps Calculating The Avarage Fps Of Last Ten Seconds GamePlay
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            _lastTenSecondsFPSSum = 0;
            _lastTenSecondsTotalFPSCalculationCount = 0;
        }
    }

    private void OnGUI() //Shows Fps Values To Player
    {
        if (GUI.Button(new Rect(10, 10, 160, 50), "Open Fps Settings"))
            _showFPS = !_showFPS;

        if (_showFPS)
        {
            GUI.Label(new Rect(10, 60, 50, 50), "Current FPS: " + _currentFPS, _guiStyle);

            GUI.Label(new Rect(10, 100, 50, 50), "Max FPS: " + _maxFPS, _guiStyle);

            GUI.Label(new Rect(10, 140, 50, 50), "Min FPS: " + _minFPS, _guiStyle);

            if (_totalFpsCalculationCount > 0)
                GUI.Label(new Rect(10, 180, 50, 50), "Avarage FPS: " + _totalFPSSum / _totalFpsCalculationCount,
                    _guiStyle);
            if (_lastTenSecondsTotalFPSCalculationCount > 0)
                GUI.Label(new Rect(10, 220, 50, 50),
                    "Last Ten Seconds FPS: " + _lastTenSecondsFPSSum / _lastTenSecondsTotalFPSCalculationCount,
                    _guiStyle);
        }
    }
}