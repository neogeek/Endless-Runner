using System.Collections.Generic;
using UnityEngine;

public class SectionSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] _sectionPrefabs;

    private const int _startNumSections = 2;

    private const int _maxNumSections = 3;

    private readonly Queue<GameObject> _spawnedSections = new Queue<GameObject>();

    private Vector3 _nextMountPoint = Vector3.zero;

    private void Start()
    {

        for (var i = 0; i < _startNumSections; i += 1)
        {

            SpawnSection();

        }

    }

    public void SpawnSection()
    {

        var spawnedSection = Instantiate(_sectionPrefabs[Random.Range(0, _sectionPrefabs.Length)], _nextMountPoint,
            Quaternion.identity);

        _nextMountPoint = spawnedSection.GetComponent<SectionController>()._mountPoint.position;

        _spawnedSections.Enqueue(spawnedSection);

        if (_spawnedSections.Count > _maxNumSections)
        {

            Destroy(_spawnedSections.Dequeue());

        }

    }

}
