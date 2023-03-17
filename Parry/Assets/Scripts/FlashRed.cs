using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashRed : MonoBehaviour
{
    [SerializeField] private float timeBetweenFlashes = 0.2f;
    [SerializeField] private uint numberOfFlashes = 2;

    private MeshRenderer _meshRenderer;
    private List<Color> _originalColors;
    private bool _isFlashing;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _originalColors = new List<Color>();
        _isFlashing = false;


        AssignOriginalColors();
    }

    public void Flash()
    {
        StartCoroutine(nameof(FlashCoroutine));
    }

    private IEnumerator FlashCoroutine()
    {
        _isFlashing = true;

        for (int i = 0; i < numberOfFlashes; i++)
        {
            // switch between red and white in certain interval
            ChangeColorForAllTo(Color.red);
            yield return new WaitForSeconds(timeBetweenFlashes);

            ChangeColorForAllTo(Color.white);
            yield return new WaitForSeconds(timeBetweenFlashes);
        }

        // switch back to original color
        ResetColor();

        _isFlashing = false;
    }

    private void AssignOriginalColors()
    {
        ClearOriginalColors();

        var materialCount = _meshRenderer.materials.Length;

        for (int i = 0; i < materialCount; i++)
        {
            _originalColors.Add(_meshRenderer.materials[i].color);
        }
    }

    private void ClearOriginalColors()
    {
        _originalColors.Clear();
    }

    private void ResetColor()
    {
        var materialCount = _meshRenderer.materials.Length;

        for (int i = 0; i < materialCount; i++)
        {
            ChangeColorTo(_originalColors[i], i);
        }
    }

    private void ChangeColorTo(Color color, int index)
    {
        _meshRenderer.materials[index].color = color;
    }

    private void ChangeColorForAllTo(Color color)
    {
        var materialCount = _meshRenderer.materials.Length;

        for (int i = 0; i < materialCount; i++)
        {
            ChangeColorTo(color, i);
        }
    }
}