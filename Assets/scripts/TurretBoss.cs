using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBoss : MonoBehaviour
{
    [SerializeField]
    private int remainingTurrets = 9;

    [SerializeField]
    private Animator[] doors = new Animator[9];
    [SerializeField]
    private GameObject turretPrefab;
    [SerializeField]
    private Transform[] turretSpots = new Transform[9];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OpenDoor(Random.Range(1, 4));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CloseDoor(Random.Range(1, 4));
        }*/
    }

    private void OpenDoor(int which)
    {
        doors[which].SetTrigger("open");
    }
    private void CloseDoor(int which)
    {
        doors[which].SetTrigger("close");
    }

    public void SubstractTurret()
    {
        remainingTurrets -= 1;
    }

    private IEnumerator CyclePattern()
    {
        while (true)
        {
            bool[] turretsToPlace = new bool[9];
            for (int i = 0; i < 9; i++)
            {
                if (Random.Range(0, 2) < 1)
                {
                    turretsToPlace[i] = true;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (turretsToPlace[i] == true)
                {
                    doors[i].SetTrigger("open");
                    Instantiate(turretPrefab, turretSpots[i]);
                }
            }
            
            yield return new WaitForSeconds(3);

            for (int i = 0; i < 9; i++)
            {
                if (turretsToPlace[i] == true)
                {
                    doors[i].SetTrigger("close");
                }
            }

            yield return new WaitForSeconds(1.7f);
        }

    }
}
