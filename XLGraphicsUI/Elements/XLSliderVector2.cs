using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace XLGraphicsUI.Elements
{
	public class XLSliderVector2 : MonoBehaviour
	{
		//public Slider sliderX;
		//public Slider sliderY;
		//public TMP_Text valueTextX;
		//public TMP_Text valueTextY;
		public XLSlider sliderX;
		public XLSlider sliderY;

		[HideInInspector]
		public event UnityAction<Vector2> onValueChange = v => { };

		public void Awake() {
			UnityAction<float> action = v => {
				var vec = new Vector2(sliderX.slider.value, sliderY.slider.value);
				onValueChange.Invoke(vec);
				SetValueText(vec);
			};
			sliderX.onValueChange += action;
			sliderY.onValueChange += action;
		}

		private void SetValueText(Vector2 v) {
			if (sliderX.slider.wholeNumbers) {
				sliderX.valueText.text = $"{(int)v.x}";
				sliderY.valueText.text = $"{(int)v.y}";
			}
			else {
				sliderX.valueText.text = $"{v.x:N}";
				sliderY.valueText.text = $"{v.y:N}";
			}
		}

		public void OverrideValue(Vector2 v) {
			sliderX.OverrideValue(v.x);
			sliderY.OverrideValue(v.y);

			SetValueText(v);
		}
	}
}
