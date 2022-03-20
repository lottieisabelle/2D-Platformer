using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public bool buttonLabels = false;

    static public int maxLevel = 0;

    static public List<string> levelCodes = new List<string>();
    static public List<int> levelSceneIDs = new List<int>();

    void Start()
    {
        levelCodes.Add("5kX2SRP5"); // level 1
        levelCodes.Add("9Ilzk3Iz");
        levelCodes.Add("U336QRe6");
        levelCodes.Add("L8PG9W7y");
        levelCodes.Add("fHrI1cVE");
        levelCodes.Add("76S9e8A9");
        levelCodes.Add("QkZ2vPBj");
        levelCodes.Add("5R7A3ilF");
        levelCodes.Add("2zGTsmhQ");
        levelCodes.Add("zoHm5pDr");
        levelCodes.Add("qxVE2Cms");
        levelCodes.Add("c37UxFzm");
        levelCodes.Add("nL7xsH8I");
        levelCodes.Add("2991RpJq");
        levelCodes.Add("y17vBzxd");
        levelCodes.Add("j4uT4F0H");
        levelCodes.Add("05xs7PCR");
        // 17
        // https://randompasswordgenerator.app/ 
        // no symbols, length 8

        levelSceneIDs.Add(5); // level 1
        levelSceneIDs.Add(6);
        levelSceneIDs.Add(9);
        levelSceneIDs.Add(10);
        levelSceneIDs.Add(11);
        levelSceneIDs.Add(12);
        levelSceneIDs.Add(13);
        levelSceneIDs.Add(14);
        levelSceneIDs.Add(15);
        levelSceneIDs.Add(16);
        levelSceneIDs.Add(17);
        levelSceneIDs.Add(18);
        levelSceneIDs.Add(19);
        levelSceneIDs.Add(20);
        levelSceneIDs.Add(21);

    }

}


