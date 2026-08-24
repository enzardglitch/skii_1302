using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static int level = 50;
    public GameObject player;
    public GameManager instance;

    [SerializeField]
    private GameObject treeprefab;



    [SerializeField]
    private GameObject slope;
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
        StartGame();
    }

    void StartGame()
    {
        
        float distance = slopeSizeStart + (slopeSizeMultiplier *level);

        slope.gameObject.transform.localScale = new Vector3(25, 1, distance);
        player.gameObject.transform.position = slope.transform.TransformPoint(new Vector3(0, 1, -0.5f));
        finishLine.gameObject.transform.position = slope.transform.TransformPoint(new Vector3(0, 1, 0.5f));

        GenerateTrees();

    }

    void GenerateTrees()
    {
        int treelimit = treeCountStart + (treeCountMultiplier * level);

        for (float position = 1; position < level - 1; position++)
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
                GameObject tree = Instantiate(treeprefab, slope.transform.TransformPoint(new Vector3(Xpos-0.5f, 1, 0.5f - (position/level)  )), Quaternion.identity);

            }
        }
    }

    public void FinishGame()
    {
        UIManager.instance.ShowNotiText($"You Win!\n with {0} points!"); //player.points!!!!!!!!
    }

}
