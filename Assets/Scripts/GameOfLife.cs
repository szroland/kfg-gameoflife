using UnityEngine;
using System.Collections;
using System.IO;

public class GameOfLife : MonoBehaviour {

    public string KezdetiAllapot;
    public int Puffer = 10;
    public bool Korkoros;

    public bool[,] allapot;

    public void Leptet()
    {
        //uj allapot meghatarozasa
    }


    // Use this for initialization
    void Start()
    {
        Betolt();
    }

    void Betolt()
    {
        string file = KezdetiAllapot;
        if (!file.EndsWith(".txt"))
            file += ".txt";
        string[] lines = File.ReadAllLines(file);
        int sorok = lines.Length;
        int oszlopok = 0;
        foreach (string line in lines)
        {
            if (line.Length > oszlopok)
                oszlopok = line.Length;
        }
        allapot = new bool[oszlopok + 2*Puffer, sorok+2*Puffer];
        for (int x = 0; x < sorok; x++)
        {
            for (int y = 0; y < lines[x].Length; y++)
            {
                allapot[y+Puffer, x+Puffer] = lines[x][y] != ' ' && lines[x][y] != '.';
            }
        }
    }
	

}
