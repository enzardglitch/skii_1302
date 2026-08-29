using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static int level = 1;
    public static int coins = 0;
    public GameObject player;
    public static GameManager instance;

    [SerializeField]
    private GameObject treePrefab;
    [SerializeField]
    private GameObject coinPrefab;



    [SerializeField]
    private GameObject slope;
    [SerializeField]
    private GameObject treeGroup;
    [SerializeField]
    private GameObject finishLine;

    [SerializeField]
    private float slopeSizeStart;
    [SerializeField]
    private float slopeSizeMultiplier;

    [SerializeField]
    private int treeCountStart;
    [SerializeField]
    private int treeCountMultiplier;



    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        LoadGame();
        StartGame();
    }

    public void TakeDamage(Player player, int damage)
    {
        player.HP -= damage;
        UIManager.instance.UpdateStat();
        if (player.HP < 0)
        {
            Die();
        }
    }

    public void TakeCoin(Player player, int point)
    {
        coins += point;
        UIManager.instance.UpdateStat();
    }

    public void Die()
    {
        Time.timeScale = 0;
        AudioManager.instance.PlaySFX(3);
        UIManager.instance.ShowDeath(true);
    }

    public void StartGame()
    {
        UIManager.instance.ResetUI();
        
        float distance = slopeSizeStart + (slopeSizeMultiplier *level);

        slope.gameObject.transform.localScale = new Vector3(25, 1000, distance);
        
        finishLine.gameObject.transform.position = slope.transform.TransformPoint(new Vector3(0, 0.5f, 0.5f));

        SetSpawn(); 

        for (int i = treeGroup.transform.childCount - 1; i >=0; i--)
        {
            Destroy(treeGroup.transform.GetChild(i).gameObject);
        }
        GenerateLevel();

        
    }

    public void SetSpawn()
    {
        Time.timeScale = 1;
        player.GetComponent<Player>().HP = 100;
        UIManager.instance.UpdateStat();
        player.gameObject.transform.position = slope.transform.TransformPoint(new Vector3(0, 0.5f + (2 / slope.transform.localScale.y), -0.5f));
        player.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 0);
        for (int i = treeGroup.transform.childCount - 1; i >= 0; i--)
        {
            treeGroup.transform.GetChild(i).gameObject.SetActive(true);
        }

        AudioManager.instance.PlaySFX(4);
    }

    private void GenerateLevel()
    {
        int treelimit = treeCountStart + (treeCountMultiplier * level);

        for (float position = 1; position < level; position++)
        {
            int treeCounts;
            if (treelimit < 8)
            {
                treeCounts = Random.Range(0, treelimit);
                print("tree small");
            }
            else
            {
                treeCounts = Random.Range(0, 8);
                print("tree big");
            }
            treelimit -= treeCounts;
            List<int> slots = Enumerable.Range(0, 8).ToList();

            int gap = slots[Random.Range(0, slots.Count - 1)];
            slots.Remove(gap);

            for (int i = 0; i < treeCounts; i++)
            {
                print(slots.Count);
                int selectslot = slots[Random.Range(0, slots.Count - 1)];
                slots.Remove(selectslot);
                float Xpos = (float)selectslot / 8;
                float Zoffset = (float)Random.Range(-20, 20) / slope.transform.localScale.z;
                GameObject tree = Instantiate(treePrefab, slope.transform.TransformPoint(new Vector3(Xpos-0.5f, 0.5f + (2/slope.transform.localScale.y), 0.5f - (position/level) + Zoffset)), Quaternion.identity);
                tree.transform.SetParent(treeGroup.transform);

            }

            slots.Add(gap);
            
            int coinslot = slots[Random.Range(0, slots.Count - 1)];
            float X = (float)coinslot / 8;
            float Z = (float)Random.Range(-20, 20)/slope.transform.localScale.z;
            GameObject coin = Instantiate(coinPrefab, slope.transform.TransformPoint(new Vector3(X - 0.5f, 0.5f + (2/slope.transform.localScale.y), 0.5f - (position / level)+Z)), Quaternion.identity);
            coin.transform.SetParent(treeGroup.transform);

        }
    }

    public void FinishGame()
    {
        Time.timeScale = 0;
        print("hi game done");
        UIManager.instance.ShowVictory(true);
        level++;
        SaveGame();
    }

    private void SaveGame()
    {
        PlayerPrefs.SetInt("gameLevel", level);
        PlayerPrefs.SetInt("gameCoins", coins);
    }

    private void LoadGame()
    {
        level = PlayerPrefs.GetInt("gameLevel", 0);
        coins = PlayerPrefs.GetInt("gameCoins", 0);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadMenu());
    }
    public IEnumerator LoadMenu()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("MainMenu");

        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
