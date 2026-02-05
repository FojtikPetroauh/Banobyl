using UnityEngine;
using TMPro;

public class SimpleInventoryUI : MonoBehaviour
{
    public SimpleInventory inventory;

    [Header("Text Fields")]
    public TextMeshProUGUI berriesText;
    public TextMeshProUGUI waterText;
    public TextMeshProUGUI woodText;

    void Update()
    {
        if (inventory == null) return;

        if (berriesText) berriesText.text = "x " + inventory.berriesCount;
        if (waterText) waterText.text = "x " + inventory.waterCount;
        if (woodText) woodText.text = "x " + inventory.woodCount;
    }
}