using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<Transform> blocks;
    [SerializeField] private float blockLength = 12f;

    private int _currentBlockNumber;
    private float _currentLength;

    private void Start()
    {
        _currentLength = (blocks.Count - 2) * blockLength;
    }

    public void MoveLevel()
    {
        _currentLength += blockLength;
        var currentPosition = blocks[_currentBlockNumber].position;
        blocks[_currentBlockNumber].position = new Vector3(currentPosition.x, currentPosition.y,
            _currentLength);

        _currentBlockNumber++;
        if (_currentBlockNumber >= blocks.Count)
        {
            _currentBlockNumber = 0;
        }
    }
}
