using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public bool buttonLabels = false;

    static public int maxLevel = 0;

    static public List<string> passwords = new List<string>();
    static public List<int> levelSceneIDs = new List<int>();

    void Start()
    {
        passwords.Add("5kX2SRP5"); // level 1
        passwords.Add("9Ilzk3Iz");
        passwords.Add("U336QRe6");
        passwords.Add("L8PG9W7y");
        passwords.Add("fHrI1cVE");
        passwords.Add("76S9e8A9");
        passwords.Add("QkZ2vPBj");
        passwords.Add("5R7A3ilF");
        passwords.Add("2zGTsmhQ");
        passwords.Add("zoHm5pDr");
        passwords.Add("qxVE2Cms");
        passwords.Add("c37UxFzm");
        passwords.Add("nL7xsH8I");
        passwords.Add("2991RpJq");
        passwords.Add("y17vBzxd");
        passwords.Add("j4uT4F0H");
        passwords.Add("05xs7PCR");
        // 17
        // https://randompasswordgenerator.app/ 
        // no symbols, length 8

        levelSceneIDs.Add(8); // level 1
        levelSceneIDs.Add(9); // 2
        levelSceneIDs.Add(10); // 3
        levelSceneIDs.Add(11); // 4
        levelSceneIDs.Add(12); // 5
        levelSceneIDs.Add(13); // 6
        levelSceneIDs.Add(14); // 7
        levelSceneIDs.Add(15); // 8
        levelSceneIDs.Add(16); // 9
        levelSceneIDs.Add(17); // 10
        levelSceneIDs.Add(18); // 11
        levelSceneIDs.Add(19); // 12
        levelSceneIDs.Add(20); // 13
        levelSceneIDs.Add(21); // 14
        levelSceneIDs.Add(22); // 15

    }

}


