using UnityEngine.UI;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public Slider healthSlider;

    // Start is called before the first frame update
    public void UpdateHealthBar(float value)
    {
        healthSlider.value = value;
    }
}
