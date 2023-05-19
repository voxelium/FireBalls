using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;
using DG.Tweening;

public class LevelProgres : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Tower tower;
    [SerializeField] private TowerBuilder towerBuilder;

    private float startTowerSize;


    private void Start()
    {
        startTowerSize = towerBuilder.GetTowerStartSize();
    }

    private void OnEnable()
    {
        tower.SizeUpdated += OnTowerSizeUpdated;
    }

    private void OnDisable()
    {
        tower.SizeUpdated -= OnTowerSizeUpdated;
    }


    private void OnTowerSizeUpdated(int size)
    {
        //slider.value = (startTowerSize - size) / startTowerSize;
        slider.DOValue((startTowerSize - size) / startTowerSize, 0.5f);
    }
}
