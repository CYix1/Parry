
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIOverlay : MonoBehaviour
{
    public static UnityEvent UIUpdate;

    private void Start()
    {
        if (UIUpdate == null)
            UIUpdate = new UnityEvent();
        UIUpdate.AddListener(setText);
    }

    void setText()
    {
        var t = GetComponent<TextMeshProUGUI>();
        t.text = "Health:  " + GameData.instance.health + "\nCoins:" + GameData.instance.coins;

    }
}
