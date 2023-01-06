using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CsvReader : MonoBehaviour
{
    private string granulo;

    string[] granuloImages = new string[1];

    public string[] pourcentageGranulo = new string[11];

    string[] pourcentageGranuloMR = new string[21];

    public int j;

    float[] granulofloat = new float[11];

    public float[] granulofloatMR = new float[21];

    float Dinf,Dmax;

    public int[] SpawnNumber = new int[11];

    public int[] SpawnNumberMR = new int[20];

    float Weigth = 5000.0f; //Masse totale evaluee en gramme

    float WeigthResidual;

    public bool generateur = false; 

    float[] TrueWeigth = new float[11];

    float[] TrueWeigthMR = new float[20];

    public float TrueWeigthTotal = 0.0f;

    public float TrueWeigthTotalMR = 0.0f;

    public float TrueTotalWeigthfinal= 0.0f;
    
    string Truepercent = "";

    float s = 0;

    public int iteration = 0;

    public float[]
        SizeSieves =
            new float[12]
            {
                0.05f,
                0.080f,
                0.160f,
                0.315f,
                0.630f,
                1.250f,
                2.500f,
                5.00f,
                10.00f,
                14.00f,
                20.00f,
                31.50f
            };

    // Start is called before the first frame update
    void Start()
    {
         j = 0;
        granulo = PlayerPrefs.GetString("granulometrie");
        granuloImages = granulo.Split(new char[] { '\n' });
       
       iteration = granuloImages.Length;
        
    }

    // Update is called once per frame
    void Update()
    {
        ReaderCsv();
    }

    void ReaderCsv()
    {
        if(generateur == true){
       
        //granulo = Resources.Load<TextAsset>("granulometrie");
        //Debug.Log(granulo);

        float Somme = 0;
        float SommeMR = 0;

        //ecrire la granulometrie de l'echantillon sans la matiere residuelle
        for (int i = 0; i <= 10; i++)
        {
            pourcentageGranulo[i] =
                granuloImages[j].Substring(0, granuloImages[j].IndexOf('/'));

            granuloImages[j] =
                granuloImages[j]
                    .Substring((granuloImages[j].IndexOf('/') + 1),
                    (
                    granuloImages[j].Length - granuloImages[j].IndexOf('/') - 1
                    ));

            granulofloat[i] = float.Parse(pourcentageGranulo[i]);
        }

        // ecrire la granulometrie de la matiere residuelle dans l'ordre asphalt,beton,bois,brique et la derniere valeur represente le pourcentage total de matiere residuelle dans l'echantillon
        for (int i = 11; i <= 31; i++)
        {
            pourcentageGranuloMR[i - 11] =
                granuloImages[j].Substring(0, granuloImages[j].IndexOf('/'));

            granuloImages[j] =
                granuloImages[j]
                    .Substring((granuloImages[j].IndexOf('/') + 1),
                    (
                    granuloImages[j].Length - granuloImages[j].IndexOf('/') - 1
                    ));

            granulofloatMR[i - 11] = float.Parse(pourcentageGranuloMR[i - 11]);
        }

        // determiner le nombre de particules a generer sans la matiere residuelle
        WeigthResidual = granulofloatMR[20] * Weigth;

        for (int i = 0; i <= 10; i++)
        {
            switch (i)
            {
                case 0:
                    Dinf = SizeSieves[0];
                    Dmax = SizeSieves[1];
                    break;
                case 1:
                    Dinf = SizeSieves[1];
                    Dmax = SizeSieves[2];
                    break;
                case 2:
                    Dinf = SizeSieves[2];
                    Dmax = SizeSieves[3];
                    break;
                case 3:
                    Dinf = SizeSieves[3];
                    Dmax = SizeSieves[4];
                    break;
                case 4:
                    Dinf = SizeSieves[4];
                    Dmax = SizeSieves[5];
                    break;
                case 5:
                    Dinf = SizeSieves[5];
                    Dmax = SizeSieves[6];
                    break;
                case 6:
                    Dinf = SizeSieves[6];
                    Dmax = SizeSieves[7];
                    break;
                case 7:
                    Dinf = SizeSieves[7];
                    Dmax = SizeSieves[8];
                    break;
                case 8:
                    Dinf = SizeSieves[8];
                    Dmax = SizeSieves[9];
                    break;
                case 9:
                    Dinf = SizeSieves[9];
                    Dmax = SizeSieves[10];
                    break;
                case 10:
                    Dinf = SizeSieves[10];
                    Dmax = SizeSieves[11];
                    break;
            }

            SpawnNumber[i] =
                System.Convert.ToInt32(((Weigth - WeigthResidual) * granulofloat[i]) /(2.4f *4 /3000 *Mathf.PI *Mathf.Pow(((Dmax + Dinf) / 2), 3)));

            Somme = Somme + SpawnNumber[i];

            TrueWeigth[i] =SpawnNumber[i] *(2.4f * 4 / 3000 * Mathf.PI * Mathf.Pow(((Dmax + Dinf) / 2), 3));

            TrueWeigthTotal = TrueWeigthTotal + TrueWeigth[i];
        }

        // determiner le nombre de matiere residuelle a generer
        for (int i = 0; i <= 19; i++)
        {
            switch (i % 5)
            {
                case 0:
                    Dinf = SizeSieves[6];
                    Dmax = SizeSieves[7];
                    break;
                case 1:
                    Dinf = SizeSieves[7];
                    Dmax = SizeSieves[8];
                    break;
                case 2:
                    Dinf = SizeSieves[8];
                    Dmax = SizeSieves[9];
                    break;
                case 3:
                    Dinf = SizeSieves[9];
                    Dmax = SizeSieves[10];
                    break;
                case 4:
                    Dinf = SizeSieves[10];
                    Dmax = SizeSieves[11];
                    break;
            }
            SpawnNumberMR[i] =
                System
                    .Convert
                    .ToInt32((WeigthResidual) *
                    granulofloatMR[i] /
                    (
                    2.4f *
                    4 /
                    3000 *
                    Mathf.PI *
                    Mathf.Pow(((Dmax + Dinf) / 2), 3)
                    ));

            SommeMR = SommeMR + SpawnNumberMR[i];

            TrueWeigthMR[i] =
                SpawnNumberMR[i] *
                (
                2.4f * 4 / 3000 * Mathf.PI * Mathf.Pow(((Dmax + Dinf) / 2), 3)
                );
            TrueWeigthTotalMR = TrueWeigthTotalMR + TrueWeigthMR[i];
        }

        for (int i = 0; i <= 30; i++)
        {
            if (i <= 10)
            {
                Truepercent =
                    Truepercent + (TrueWeigth[i] / TrueWeigthTotal) + ";";
            }
            else
            {
                Truepercent =
                    Truepercent +
                    (TrueWeigthMR[i - 11] / TrueWeigthTotalMR) + ";";
            }
        }
        for (int i = 0; i <= 19; i++)
        {
            s = granulofloatMR[i] + s;
        }
        TrueTotalWeigthfinal=TrueWeigthTotal+TrueWeigthTotalMR;

       //  Debug.Log(Truepercent);
        Debug.Log (TrueTotalWeigthfinal);

        string fichier = Application.dataPath + "/Truegranulo.txt";

        File.AppendAllText(fichier, Truepercent + "\r\n");
        
        Truepercent = "";

     generateur = false;
     
    }
    }
}
