using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    public ImageSynthesis synth;

    public ImageSynthesis synthBottom;

    public Camera MainCamera, BottomCamera, visionneuse;

    public int[] SpawnNumber = new int[11];

    public int[] SpawnNumberMR = new int[11];

    float Dinf,Dmax;

    public GameObject[] Asphalt,Beton,Bois,Brique,Particles;

    public bool generateur = false;

    public float[] LimitesX = new float[2];

    public float[] LimitesY = new float[2];

    public float[] LimitesZ = new float[2];

    public int nombre = 0;

    private float massevolumiqueGravel, massevolumiqueSand, massevolumiqueAsphalt, massevolumiqueBeton, massevolumiqueBois, massevolumiqueBrique;

    public int palier = 500;

    public CsvReader csvReader;

    public Arata arata;

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

    IEnumerator coroutine()
    {   
        int compteur =  csvReader.iteration;

        for(int z = 1; z <= compteur ; z++){

        csvReader.generateur = true;
        yield return new WaitForSeconds(5);

        SpawnNumber = csvReader.SpawnNumber;
        SpawnNumberMR = csvReader.SpawnNumberMR;

        for (int i = 0; i <= 10; i++)
        {
            int resultquo;
            int NewSpawnNumber = SpawnNumber[i];
            int restdiv;

            restdiv = NewSpawnNumber % palier;

            resultquo = (NewSpawnNumber - restdiv) / palier;

            Debug.Log("je suis au tamis : " + i);

            for (int k = 0; k < resultquo; k++)
            {
                for (int j = 0; j < palier; j++)
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

                    float randspawn = Random.Range(Dinf, Dmax);

                    int indexParticle;

                    indexParticle = Random.Range(0, Particles.Length-1);

                    float
                        X,
                        Y,
                        Z;
                    X = Random.Range(LimitesX[0], LimitesX[1]);
                    Y = Random.Range(LimitesY[0], LimitesY[1]);
                    Z = Random.Range(LimitesZ[0], LimitesZ[1]);
                    Vector3 position = new Vector3(X, Y, Z);

                    var objet =
                        Instantiate(Particles[indexParticle],
                        position,
                        Random.rotation);

                    objet.transform.localScale =
                        new Vector3(objet.transform.localScale.x * randspawn,
                            objet.transform.localScale.y * randspawn,
                            objet.transform.localScale.z * randspawn);


                                if (randspawn <= SizeSieves[7]){
                                        massevolumiqueSand = Random.Range(0.0014f,0.0016f);
                        objet.GetComponent<Rigidbody>().mass = 4 * Mathf.PI * Mathf.Pow(randspawn,3) * massevolumiqueSand/ 3;
                    }else if(randspawn> SizeSieves[7]){
                        massevolumiqueGravel = Random.Range(0.0016f,0.0018f);
                        objet.GetComponent<Rigidbody>().mass = 4 * Mathf.PI * Mathf.Pow(randspawn,3) * massevolumiqueGravel/ 3;
                }

                    
                    
            }
            Debug.Log("je genere " +palier +" particules pour la vague numero " +k +" et le nombre total a genrer est " +(SpawnNumber[i] - SpawnNumber[i] % palier));
                 yield return new WaitForSeconds(5);
            }
            Debug.Log("je genere les : " + restdiv + " particules restantes");
            for (int j = 0; j < restdiv; j++)
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
                float randspawn = Random.Range(Dinf, Dmax);

                int indexParticle;

                indexParticle = Random.Range(0, Particles.Length-1);

                float
                    X,
                    Y,
                    Z;
                X = Random.Range(LimitesX[0], LimitesX[1]);
                Y = Random.Range(LimitesY[0], LimitesY[1]);
                Z = Random.Range(LimitesZ[0], LimitesZ[1]);
                Vector3 position = new Vector3(X, Y, Z);

                var objet =
                    Instantiate(Particles[indexParticle],
                    position,
                    Random.rotation);
                
                objet.transform.localScale =
                    new Vector3(objet.transform.localScale.x * randspawn,
                        objet.transform.localScale.y * randspawn,
                        objet.transform.localScale.z * randspawn);

                        if (randspawn <= SizeSieves[7]){
                                        massevolumiqueSand = Random.Range(0.0014f,0.0016f);
                        objet.GetComponent<Rigidbody>().mass = 4 * Mathf.PI * Mathf.Pow(randspawn,3) * massevolumiqueSand/ 3;
                    }else if(randspawn> SizeSieves[7]){
                        massevolumiqueGravel = Random.Range(0.0016f,0.0018f);
                        objet.GetComponent<Rigidbody>().mass = 4 * Mathf.PI * Mathf.Pow(randspawn,3) * massevolumiqueGravel/ 3;
                }
            }
        }
         

        for (int i = 0; i <= 19; i++)
        {


        int resultquoMR;
        int NewSpawnNumberMR = SpawnNumberMR[i];
        int restdivMR;
            
           
            restdivMR = NewSpawnNumberMR % palier;

            resultquoMR = (NewSpawnNumberMR - restdivMR) / palier;

            Debug.Log("je suis au tamis pour les residus : " + i);
 
       for (int k = 0; k < resultquoMR; k++)
            {
                for (int j = 0; j < palier; j++)
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

                float randspawn = Random.Range(Dinf, Dmax);
                
                float
                    X,
                    Y,
                    Z;
                X = Random.Range(LimitesX[0], LimitesX[1]);
                Y = Random.Range(LimitesY[0], LimitesY[1]);
                Z = Random.Range(LimitesZ[0], LimitesZ[1]);

                Vector3 position = new Vector3(X, Y, Z);

                int indexAsphalt, indexBeton, indexBois, indexBrique;

                if(i>=0&&i<=4){
                    indexAsphalt = Random.Range(0, Asphalt.Length-1);
                    var objet =
                    Instantiate(Asphalt[indexAsphalt], position, Random.rotation);
                    massevolumiqueAsphalt = Random.Range(0.00235f,0.00245f);
                    objet.GetComponent<Rigidbody>().mass = 4 * Mathf.PI * Mathf.Pow(randspawn,3) * massevolumiqueAsphalt/ 3;
                    objet.transform.localScale =
                    new Vector3(objet.transform.localScale.x * randspawn,
                        objet.transform.localScale.y * randspawn,
                        objet.transform.localScale.z * randspawn);
                }
                if(i>=5&&i<=9){
                    indexBeton = Random.Range(0, Beton.Length-1);
                    var objet =
                    Instantiate(Beton[indexBeton], position, Random.rotation);
                    massevolumiqueBeton = Random.Range(0.00235f,0.0025f);
                    objet.GetComponent<Rigidbody>().mass = 4 * Mathf.PI * Mathf.Pow(randspawn,3) * massevolumiqueBeton/ 3;
                    objet.transform.localScale =
                    new Vector3(objet.transform.localScale.x * randspawn,
                        objet.transform.localScale.y * randspawn,
                        objet.transform.localScale.z * randspawn);
                }
                 if(i>=10&&i<=14){
                    indexBois = Random.Range(0, Bois.Length-1);
                    var objet =
                    Instantiate(Bois[indexBois], position, Random.rotation);
                    massevolumiqueBois = Random.Range(0.000080f,0.0014f);
                    objet.GetComponent<Rigidbody>().mass = 4 * Mathf.PI * Mathf.Pow(randspawn,3) * massevolumiqueBois/ 3;
                    objet.transform.localScale =
                    new Vector3(objet.transform.localScale.x * randspawn,
                        objet.transform.localScale.y * randspawn,
                        objet.transform.localScale.z * randspawn);
                }
                  if(i>=15&&i<=19){
                    indexBrique = Random.Range(0, Brique.Length-1);
                     var objet =
                    Instantiate(Brique[indexBrique], position, Random.rotation);
                    massevolumiqueBrique = Random.Range(0.0018f,0.0021f);
                    objet.GetComponent<Rigidbody>().mass = 4 * Mathf.PI * Mathf.Pow(randspawn,3) * massevolumiqueBrique/ 3;
                    objet.transform.localScale =
                    new Vector3(objet.transform.localScale.x * randspawn,
                        objet.transform.localScale.y * randspawn,
                        objet.transform.localScale.z * randspawn);
                }
            

            }
                     Debug.Log("je genere " +
                    palier +
                    " particules pour la vague numero " +
                    k +
                    " et le nombre total a genrer est " +
                    (SpawnNumberMR[i] - SpawnNumberMR[i] % palier));
                    yield return new WaitForSeconds(5);
            }
Debug.Log("je genere les : " + restdivMR + " particules restantes");
            for (int j = 0; j < restdivMR; j++)
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

                float randspawn = Random.Range(Dinf, Dmax);
                
                float
                    X,
                    Y,
                    Z;
                X = Random.Range(LimitesX[0], LimitesX[1]);
                Y = Random.Range(LimitesY[0], LimitesY[1]);
                Z = Random.Range(LimitesZ[0], LimitesZ[1]);

                Vector3 position = new Vector3(X, Y, Z);

                int indexAsphalt, indexBeton, indexBois, indexBrique;
                if(i>=0&&i<=4){
                    indexAsphalt = Random.Range(0, Asphalt.Length-1);
                      var objet =
                    Instantiate(Asphalt[indexAsphalt], position, Random.rotation);
                    massevolumiqueAsphalt = Random.Range(0.00235f,0.00245f);
                    objet.GetComponent<Rigidbody>().mass = 4 * Mathf.PI * Mathf.Pow(randspawn,3) * massevolumiqueAsphalt/ 3;
                     objet.transform.localScale =
                    new Vector3(objet.transform.localScale.x * randspawn,
                        objet.transform.localScale.y * randspawn,
                        objet.transform.localScale.z * randspawn);
                }
                if(i>=5&&i<=9){
                    indexBeton = Random.Range(0, Beton.Length-1);
                      var objet =
                    Instantiate(Beton[indexBeton], position, Random.rotation);
                    massevolumiqueBeton = Random.Range(0.00235f,0.0025f);
                    objet.GetComponent<Rigidbody>().mass = 4 * Mathf.PI * Mathf.Pow(randspawn,3) * massevolumiqueBeton/ 3;
                     objet.transform.localScale =
                    new Vector3(objet.transform.localScale.x * randspawn,
                        objet.transform.localScale.y * randspawn,
                        objet.transform.localScale.z * randspawn);
                }
                 if(i>=10&&i<=14){
                    indexBois = Random.Range(0, Bois.Length-1);
                      var objet =
                    Instantiate(Bois[indexBois], position, Random.rotation);
                    massevolumiqueBois = Random.Range(0.000080f,0.0014f);
                    objet.GetComponent<Rigidbody>().mass = 4 * Mathf.PI * Mathf.Pow(randspawn,3) * massevolumiqueBois/ 3;
                     objet.transform.localScale =
                    new Vector3(objet.transform.localScale.x * randspawn,
                        objet.transform.localScale.y * randspawn,
                        objet.transform.localScale.z * randspawn);
                }
                  if(i>=15&&i<=19){
                    indexBrique = Random.Range(0, Brique.Length-1);
                     var objet =
                    Instantiate(Brique[indexBrique], position, Random.rotation);
                    massevolumiqueBrique = Random.Range(0.0018f,0.0021f);
                    objet.GetComponent<Rigidbody>().mass = 4 * Mathf.PI * Mathf.Pow(randspawn,3) * massevolumiqueBrique/ 3;
                     objet.transform.localScale =
                    new Vector3(objet.transform.localScale.x * randspawn,
                        objet.transform.localScale.y * randspawn,
                        objet.transform.localScale.z * randspawn);
                }
            
            }
        }
        synth.OnSceneChange(false);
         nombre++ ;
         csvReader.j = nombre;
         csvReader.TrueWeigthTotal = 0.0f;
         csvReader.TrueWeigthTotalMR = 0.0f;
         csvReader.TrueTotalWeigthfinal = 0.0f;
         yield return new WaitForSeconds(10);
        
         synth.Save("Images_Up_"+(nombre), 3840, 2160, "ImagesSynthetiques", 1);
         synth.Save("Images_Up_"+(nombre), 3840, 2160, "ImagesSynthetiques", 3);
         synthBottom.Save("Images_Down_"+(nombre), 3840, 2160, "ImagesSynthetiquesbottom", 1);
         synthBottom.Save("Images_Down_"+(nombre), 3840, 2160, "ImagesSynthetiquesbottom", 3);
       // SaveCameraView(MainCamera,"Images_Up_"+(nombre),"ImagesSynthetiques");
       // SaveCameraView(BottomCamera,"Images_Down_"+(nombre),"ImagesSynthetiquesbottom");
         yield return new WaitForSeconds(5);
         arata.arata();
      }

     SceneManager.LoadScene("interface");

    }

    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(coroutine());
    }

    
    /*void SaveCameraView(Camera cam, string filename,string path)
 {
    synth.Save(filename, 3840, 2160, path, 1);
    RenderTexture screenTexture = new RenderTexture(Screen.width, Screen.height, 16);
    cam.targetTexture = screenTexture;
    RenderTexture.active = screenTexture;
    cam.Render();
    Texture2D renderedTexture = new Texture2D(Screen.width, Screen.height);
    renderedTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
    RenderTexture.active = null;
    byte[] byteArray = renderedTexture.EncodeToJPG();
    System.IO.File.WriteAllBytes(Application.dataPath +"/"+path+"/"+ filename +".jpg", byteArray);
 }*/
}
