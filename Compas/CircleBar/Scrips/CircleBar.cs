// NULLcode Studio © 2015
// null-code.ru

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CircleBar : MonoBehaviour {

	public Image circleBar;
	private static float maxValue;
	private static float value;
	private static Image bar;

	public static float currentValue
	{
		get {return value;}
	}

	void Awake()
	{
		bar = circleBar;
	}

	public static void SetDefault(float max)
	{
		maxValue = max;
		value = max;
		bar.fillAmount = 1;
	}

	public static void SetSettings(float max, float current)
	{
		maxValue = max;
		value = current;
		bar.fillAmount = current/max;
	}

	public static void AdjustCurrentValue(float adjust)
	{
		value += adjust;
		if(value < 0) value = 0;
		if(value > maxValue) value = maxValue;
		bar.fillAmount = value/maxValue;
	}
}
