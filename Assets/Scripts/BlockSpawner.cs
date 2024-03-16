using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    #region SINGLETON
    public static BlockSpawner instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion
    private int _numOfBlock = 8;
    public GameObject panelGameOver;

    [SerializeField] private Block _blockPrefab;
    [SerializeField] private float _distanceBetweenBlocks = 8f;
    private int _rowsSpawned = 0;
    private List<Block> _blocksSpawned = new List<Block>();
    public TMP_Text scoreText;
    public int score;
    public TMP_Text recordText;
    private void OnEnable()
    {
        SpawnBlocks();
    }
    public void Start()
    {
        panelGameOver.SetActive(false);
        score = 0;
        recordText.text = PlayerPrefs.GetInt("record", 0).ToString();
    }

    public void SpawnBlocks()
    {
        foreach (var block in _blocksSpawned)
        {
            if(block != null)
            {
                block.transform.position += Vector3.down * _distanceBetweenBlocks;
            }
        }

        for (int i = 0; i < _numOfBlock; i++)
        {
            if(UnityEngine.Random.Range(0,100) > 50)
            {
                var block = Instantiate(_blockPrefab, GetPosition(i), Quaternion.identity);
                int hits = UnityEngine.Random.Range(1, 4) + _rowsSpawned;
                block.SetHit(hits);
                _blocksSpawned.Add(block);
            }
        }

        _rowsSpawned++;
    }
    public void Update()
    {
        scoreText.text = score.ToString();
        if(score > PlayerPrefs.GetInt("record", 0))
        {
            PlayerPrefs.SetInt("record", score);
            recordText.text = score.ToString();
        }
       
    }

    public void BorrarRecord()
    {
        PlayerPrefs.DeleteKey("record");
        recordText.text = "0";
    }

    private Vector3 GetPosition(int i)
    {
        Vector3 position = transform.position;
        position += Vector3.right * i * _distanceBetweenBlocks;
        return position;
    }
    public void GameOver()
    {
        panelGameOver.SetActive(true);
    }
}
