using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;


public class game : MonoBehaviour
{
   
    
    public Soru[] sorular;
    private static List<Soru> sorulmamisSorular;

    private Soru simdikiSoru;


    public Text soruText;
    public Text bestText;
    public Button sik_A;
    public Button sik_B;
    public Button sik_C;
    public Button sik_D;

    public Image times;

    public float zaman;
    public Text timer;


    public GameObject panel;
    public GameObject sonPanel;
    public GameObject finishPanel;
    public GameObject timePanel;

    public GameObject timesNow;

    private static int durum;

    private int rekor;

    public AudioSource ses;
    public AudioSource yanlis;

    public bool durumumuz;

    public Text puan;

    private static int dogru;

    // Start is called before the first frame update
    void Start()
    {
        
        if (sorulmamisSorular == null)
        {
            sorulmamisSorular = sorular.ToList<Soru>();
        }

        if (sorulmamisSorular.Count < 1)
        {
            SoruBitti();
        }
        else
        {
            durum = 1;
            
            SoruSor();
        }
    }

    // Update is called once per frame
    void Update()
    {

        

        puan.text = dogru + "";

        
        rekor = int.Parse(bestText.text); 
        if(rekor < dogru)
        {
            rekor = dogru;
        }

        PlayerPrefs.SetInt("best", rekor);


        if (durum == 1)
        {
            zaman -= Time.deltaTime;
            timer.text = zaman.ToString("f2");


            if (zaman <= 5)
            {

                
                times.GetComponentInChildren<Image>().color = Color.red;
                timesNow.SetActive(true);

            }

            if (zaman <= 0)
            {
                yanlis.Play();
                timer.text = "0,00  ";
                sureBitti();

            }
        }
        else
        {
            timer.text = zaman.ToString("f2");
        }

        

    }

  
    void SoruSor()
    {

        int rakam = PlayerPrefs.GetInt("best");
        bestText.text = rakam +"";

        int soruIndex = Random.Range(0, sorulmamisSorular.Count);
        simdikiSoru = sorulmamisSorular[soruIndex];

        soruText.text = simdikiSoru.soru;

        sik_A.GetComponentInChildren<Text>().text = simdikiSoru.aSikki;
        sik_B.GetComponentInChildren<Text>().text = simdikiSoru.bSikki;
        sik_C.GetComponentInChildren<Text>().text = simdikiSoru.cSikki;
        sik_D.GetComponentInChildren<Text>().text = simdikiSoru.dSikki;

        sorulmamisSorular.RemoveAt(soruIndex);
    }

    public void apick()
    {
        if (simdikiSoru.cevap == 1)
        {
            if (!durumumuz)
            {
                sik_A.GetComponentInChildren<Image>().color = Color.green;
                ++dogru;
                puan.text = dogru + "";

                durum = 0;

                rekor = int.Parse(bestText.text);
                if (rekor < dogru)
                {
                    rekor = dogru;
                }

                PlayerPrefs.SetInt("best", rekor);
                int rakam = PlayerPrefs.GetInt("best");
                bestText.text = rakam + "";
                durumumuz = true;
                ses.Play();
                timesNow.SetActive(false);
                StartCoroutine(next());
            }
            

        }
        else
        {
            if (!durumumuz)
            {
                timesNow.SetActive(false);
                yanlis.Play();
                sik_A.GetComponentInChildren<Image>().color = Color.red;
                StartCoroutine(finish());
                durum = 0;
                durumumuz = true;
            }
            
        }
        

    }
    public void bpick()
    {
        if (simdikiSoru.cevap == 2)
        {
            if (!durumumuz)
            {
                timesNow.SetActive(false);
                sik_B.GetComponentInChildren<Image>().color = Color.green;
                ++dogru;
                puan.text = dogru + "";
                durum = 0;
                rekor = int.Parse(bestText.text);
                if (rekor < dogru)
                {
                    rekor = dogru;
                }
                durumumuz = true;
                ses.Play();
                PlayerPrefs.SetInt("best", rekor);
                int rakam = PlayerPrefs.GetInt("best");
                bestText.text = rakam + "";
                StartCoroutine(next());
            }
        }
        else
        {
            if (!durumumuz)
            {
                timesNow.SetActive(false);
                durumumuz = true;
                yanlis.Play();
                sik_B.GetComponentInChildren<Image>().color = Color.red;
                StartCoroutine(finish());
                durum = 0;
            }
        }
        
    }
    public void cpick()
    {
        if (simdikiSoru.cevap == 3)
        {
            if (!durumumuz)
            {
                timesNow.SetActive(false);
                sik_C.GetComponentInChildren<Image>().color = Color.green;
                ++dogru;
                puan.text = dogru + "";
                durum = 0;
                rekor = int.Parse(bestText.text);
                if (rekor < dogru)
                {
                    rekor = dogru;
                }
                durumumuz = true;
                ses.Play();
                PlayerPrefs.SetInt("best", rekor);
                int rakam = PlayerPrefs.GetInt("best");
                bestText.text = rakam + "";
                StartCoroutine(next());
            }
        }
        else
        {
            if (!durumumuz)
            {
                timesNow.SetActive(false);
                durumumuz = true;
                yanlis.Play();
                sik_C.GetComponentInChildren<Image>().color = Color.red;
                StartCoroutine(finish());
                durum = 0;
            }
        }
     
    }
    public void dpick()
    {
        if (simdikiSoru.cevap == 4)
        {
            if (!durumumuz)
            {
                timesNow.SetActive(false);
                sik_D.GetComponentInChildren<Image>().color = Color.green;
                ++dogru;
                puan.text = dogru + "";
                durum = 0;
                rekor = int.Parse(bestText.text);
                if (rekor < dogru)
                {
                    rekor = dogru;
                }
                durumumuz = true;
                ses.Play();
                PlayerPrefs.SetInt("best", rekor);
                durum = 0;
                int rakam = PlayerPrefs.GetInt("best");
                bestText.text = rakam + "";
                StartCoroutine(next());
            }
        }
        else
        {
            if (!durumumuz)
            {
                timesNow.SetActive(false);
                durumumuz = true;
                yanlis.Play();
                sik_D.GetComponentInChildren<Image>().color = Color.red;
                StartCoroutine(finish());
                durum = 0;
            }
        }
        
    }

    IEnumerator next()
    {
        
       
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
        
    }

    IEnumerator finish()
    {
        yield return new WaitForSeconds(1);
        OyunBitti();

    }
    

    public void OyunBitti()
    {
        
        panel.SetActive(false);
        sik_A.gameObject.SetActive(false);
        sik_B.gameObject.SetActive(false);
        sik_C.gameObject.SetActive(false);
        sik_D.gameObject.SetActive(false);

        sonPanel.SetActive(true);

        
    }
    void sureBitti()
    {
        
        puan.text = dogru + "";

        int rakam = PlayerPrefs.GetInt("best");
        bestText.text = rakam + "";
        panel.SetActive(false);
        sik_A.gameObject.SetActive(false);
        sik_B.gameObject.SetActive(false);
        sik_C.gameObject.SetActive(false);
        sik_D.gameObject.SetActive(false);

        timePanel.SetActive(true);
        
    }

    void SoruBitti()
    {
        puan.text = dogru + "";

        int rakam = PlayerPrefs.GetInt("best");
        bestText.text = rakam + "";
        panel.SetActive(false);
        sik_A.gameObject.SetActive(false);
        sik_B.gameObject.SetActive(false);
        sik_C.gameObject.SetActive(false);
        sik_D.gameObject.SetActive(false);

        finishPanel.SetActive(true);

        
        
    }




    public void menu()
    {
        sorulmamisSorular = sorular.ToList<Soru>();
        dogru = 0;
        SceneManager.LoadScene(0);
    }
}
