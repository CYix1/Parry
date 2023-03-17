using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] private float timeBetweenFlashes = 0.2f;
    [SerializeField] private uint numberOfFlashes = 2;

    private MeshRenderer _meshRenderer;
    private List<Color> _originalColors;
    private bool _isFlashing;

    private const int NormalPerryIndex = 0;
    private const int DodgePerryIndex = 1;
    private int _currentChildIndex;

    private void Start()
    {
        _originalColors = new();
        _isFlashing = false;

        AssignCorrectMeshRendererAndColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Bullet") || other.CompareTag("Canon"))
        {
            PlayHitIndication();

            GameData.instance.health--;

            UIOverlay.UIUpdate.Invoke();
            if (GameData.instance.health <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    #region HitIndication

    private void PlayHitIndication()
    {
        // flash active mesh
        AssignCorrectMeshRendererAndColor();
        StartCoroutine(nameof(FlashRed));
    }

    private IEnumerator FlashRed()
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
        // tell PlayHitAnimation() that it can call coroutine again from now on
        _isFlashing = false;
    }

    #endregion

    #region Renderer & Color

    private void AssignCorrectMeshRendererAndColor()
    {
        Transform activeChild = GetActiveChildAndSetIndex();

        // normal perry has child with mesh renderer, so use this instead of parent
        if (_currentChildIndex == NormalPerryIndex)
        {
            activeChild = activeChild.GetChild(0);
        }

        // get components and set variables
        _meshRenderer = activeChild.GetComponent<MeshRenderer>();
        AssignOriginalColors();
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

    #endregion

    #region Child

    private Transform GetActiveChildAndSetIndex()
    {
        var childNormal
            = transform.GetChild(NormalPerryIndex);

        // check which child is active and return it
        if (childNormal.gameObject.activeSelf)
        {
            _currentChildIndex = NormalPerryIndex;
            return childNormal;
        }

        // no ELSE needed as we return in IF
        _currentChildIndex = DodgePerryIndex;
        return transform.GetChild(DodgePerryIndex);
    }

    #endregion
}