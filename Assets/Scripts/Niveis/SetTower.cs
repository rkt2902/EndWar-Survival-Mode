using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTower : MonoBehaviour
{
    public int Selected;
    public GameObject[] towers;
    public int[] prices; 
    public GameObject Tile;
    public Money mscr;
    public CharacterData characterData;
    private GameManager gameManager;
    


    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameManager.Instance;
        mscr = GameObject.Find("GameLogic").GetComponent<Money>();
        characterData = gameManager.gameData.characters[gameManager.currentCharacterIndex];




    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,50))
        {
            if (hit.transform.CompareTag("Tile"))
            {
                Tile = hit.transform.gameObject;
            }
            else
            {
                Tile = null;
            }
        }
        if (Input.GetMouseButtonDown(0) && Tile != null)
        {
            TileTaken tscr = Tile.GetComponent<TileTaken>();
            if (!tscr.isTaken && mscr.money >= prices[Selected])
            {
                mscr.money -= prices[Selected];
                Vector3 pos = new Vector3(Tile.transform.position.x, 0.95f, Tile.transform.position.z);
             
                GameObject towerObj = Instantiate(towers[Selected], pos, Quaternion.identity);
                Health health = towerObj.GetComponent<Health>();

                // Set the tower data for health
                TowerData towerData = towerObj.GetComponent<TowerData>();

                towerData.level = characterData.GetTowerLevel(towerData.id);

                health.SetTowerData(towerData);

                tscr.Tower = towerObj;
                tscr.isTaken = true;
            }
        }
    }
}
