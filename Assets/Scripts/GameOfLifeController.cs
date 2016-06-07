using UnityEngine;
using System.Collections;

public class GameOfLifeController : MonoBehaviour {

    public GameOfLife gameOfLife;

    public GameObject Sejt;
    public float Varakozas = .1f;

    private GameObject[,] Sejtek;

	// Use this for initialization
	void Start () {
        Kirak();
        InvokeRepeating("Frissit", Varakozas, Varakozas);
    }
	

    void Frissit()
    {
        gameOfLife.Leptet();
        Kirak();
    }

    void Kirak()
    {
        if (gameOfLife.allapot != null)
        {
            int x = gameOfLife.allapot.GetLength(0);
            int y = gameOfLife.allapot.GetLength(1);

            if (Sejtek == null || Sejtek.GetLength(0) != x || Sejtek.GetLength(1) != y)
            {
                Reset();
                Sejtek = new GameObject[x, y];
            }

            for (int i=0; i< x; i++)
            {
                for (int j=0; j< y; j++)
                {
                    if (gameOfLife.allapot[i,j])
                    {
                        if (Sejtek[i,j] == null)
                        {
                            var pos = new Vector3(i, 0, j);
                            Sejtek[i, j] = Letrehoz(pos, Sejt);
                        }
                    } else
                    {
                        if (Sejtek[i,j] != null)
                        {
                            Destroy(Sejtek[i, j]);
                            Sejtek[i, j] = null;
                        }
                    }

                }
            }

        }
    }

    void Reset()
    {
        if (Sejtek == null)
            return;

        for (int i=0; i<Sejtek.GetLength(0); i++)
        {
            for (int j=0; j<Sejtek.GetLongLength(1); j++)
            {
                if (Sejtek[i, j] != null)
                    Destroy(Sejtek[i, j]);
            }
        }
        Sejtek = null;
    }

    GameObject Letrehoz(Vector3 pos, GameObject epitoElem)
    {
        var t = (Instantiate(epitoElem, transform.position + pos + epitoElem.transform.position, Quaternion.identity) as GameObject);
        t.transform.parent = transform;
        return t;
    }


}
