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
        if(passwords.Count == 0){      // level number
            passwords.Add("5kX2SRP5"); // 1
            passwords.Add("90xzk3Jz"); // 2
            passwords.Add("U336QRe6"); // 3
            passwords.Add("L8PG9W7y"); // 4
            passwords.Add("fHr0LcVE"); // 5
            passwords.Add("76S9e8A9"); // 6
            passwords.Add("QkZ2vPBj"); // 7
            passwords.Add("5R7A3iXF"); // 8
            passwords.Add("2zGTsmhQ"); // 9
            passwords.Add("zoHm5pDr"); // 10

            passwords.Add("qxVE2Cms"); // 11
            passwords.Add("c37UxFzm"); // 12
            passwords.Add("nL7xsH8o"); // 13
            passwords.Add("2991RpJq"); // 14
            passwords.Add("y17vBzxd"); // 15
            passwords.Add("j4uT4F0H"); // 16
            passwords.Add("05xs7PCR"); // 17
            passwords.Add("310aK6Yb"); // 18
            passwords.Add("1y92Sx7p"); // 19
            passwords.Add("opBRad06"); // 20

            passwords.Add("3nd02L51"); // 21
            passwords.Add("sW0G46KM"); // 22
            passwords.Add("2MO21G2p"); // 23
            passwords.Add("nX350Yf7"); // 24
            passwords.Add("fuLkXW62"); // 25
            passwords.Add("Yx7Lhg85"); // 26
            passwords.Add("VMw0c098"); // 27
            passwords.Add("rWWS5c29"); // 28
            passwords.Add("AHnSE28g"); // 29
            passwords.Add("Te3ZD5B6"); // 30

            passwords.Add("8uB40beK"); // 31
            passwords.Add("k3YV01Cx"); // 32
            passwords.Add("7xyW3kDe"); // 33
            passwords.Add("mqJ5c0K0"); // 34
            passwords.Add("aLu9m30N"); // 35
            passwords.Add("uG3abGH9"); // 36
            passwords.Add("tzYg0184"); // 37
            passwords.Add("kmSw9TRN"); // 38
            passwords.Add("A3K21yaG"); // 39
            passwords.Add("69Lz0CDH"); // 40

        }
        
        if(levelSceneIDs.Count == 0){ // level number
            levelSceneIDs.Add(8); // 1
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
            levelSceneIDs.Add(23); // 16
            levelSceneIDs.Add(24); // 17
            levelSceneIDs.Add(25); // 18
            levelSceneIDs.Add(26); // 19
            levelSceneIDs.Add(27); // 20

            levelSceneIDs.Add(28); // 21
            levelSceneIDs.Add(29); // 22
            levelSceneIDs.Add(30); // 23
            levelSceneIDs.Add(31); // 24
            levelSceneIDs.Add(32); // 25
            levelSceneIDs.Add(33); // 26
            levelSceneIDs.Add(34); // 27
            levelSceneIDs.Add(35); // 28
            levelSceneIDs.Add(36); // 29
            levelSceneIDs.Add(37); // 30

            levelSceneIDs.Add(38); // 31
            levelSceneIDs.Add(39); // 32
            levelSceneIDs.Add(40); // 33
            levelSceneIDs.Add(41); // 34
            levelSceneIDs.Add(42); // 35
            levelSceneIDs.Add(43); // 36
            levelSceneIDs.Add(44); // 37
            levelSceneIDs.Add(45); // 38
            levelSceneIDs.Add(46); // 39
            levelSceneIDs.Add(47); // 40
        }        
    }
}


