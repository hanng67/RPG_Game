using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public CharStats[] playerStats;

    public bool gameMenuOpen, dialogActive, fadingBetweenAreas;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController.Instance.CanMove = !(gameMenuOpen || dialogActive || fadingBetweenAreas);
    }
}
