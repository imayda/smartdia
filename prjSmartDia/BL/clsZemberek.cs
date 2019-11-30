﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using net.zemberek.erisim;
using net.zemberek.yapi;
using net.zemberek.tr.yapi;
using System.IO;
using net.zemberek.yapi.ek;



public class clsZemberek
    {
    private string skelime;

    public string MyProperty
    {
        get { return skelime; }
        set { skelime = value; }
    }


    public void KokGetir(string sKokuneAyrılacakelime)
    {
        Kelime[] cozumler = zemberek.kelimeCozumle(input);

        if (cozumler.Length == 0)
        {

            return input;
        }

        int igUzunluk = 0;
        int maxIndex = 0;
        for (int i = 0; i < cozumler.Length; i++)
        {
            if (igUzunluk < cozumler[i].ekler().Count)
            {
                igUzunluk = cozumler[i].ekler().Count;
                maxIndex = i;
            }

        }

        Kelime kelime1 = cozumler[maxIndex];
        System.Console.WriteLine(cozumler[maxIndex].ToString());

        List<Ek> ekler = kelime1.ekler();
        List<Ek> yeni_ekler = new List<Ek>();

        int j = 0;
        for (int i = 0; i < ekler.Count; i++)
        {

            Boolean cekimEkiMi = false;

            if (    // Cogul Ekleri -ler, -lar
                    (Convert.ToString(ekler[i]).Contains("ISIM_COGUL_LER"))
                    || (Convert.ToString(ekler[i]).Contains("ISIM_COGUL_LAR"))

                    // Durum (hal) Ekleri -i, -e, -de, -den
                    || (Convert.ToString(ekler[i]).Contains("ISIM_BELIRTME_I"))
                    || (Convert.ToString(ekler[i]).Contains("ISIM_YONELME_E"))
                    || (Convert.ToString(ekler[i]).Contains("ISIM_KALMA_DE"))
                    || (Convert.ToString(ekler[i]).Contains("ISIM_CIKMA_DEN"))

                    // Tamlama
                    || (Convert.ToString(ekler[i]).Contains("ISIM_TAMLAMA_"))
                    /*
                    || (Convert.ToString(ekler[i]).Contains("ISIM_TAMLAMA_I"))
                    || (Convert.ToString(ekler[i]).Contains("ISIM_TAMLAMA_IN"))
                     */

                    // Iyelik -im, -in
                    || (Convert.ToString(ekler[i]).Contains("ISIM_SAHIPLIK_"))
                    /*
                    || (Convert.ToString(ekler[i]).Contains("ISIM_SAHIPLIK_BEN_IM"))
                    || (Convert.ToString(ekler[i]).Contains("ISIM_SAHIPLIK_SEN_IN"))
                    || (Convert.ToString(ekler[i]).Contains("ISIM_SAHIPLIK_O_I"))
                    || (Convert.ToString(ekler[i]).Contains("ISIM_SAHIPLIK_BIZ_IMIZ"))
                    || (Convert.ToString(ekler[i]).Contains("ISIM_SAHIPLIK_SIZ_INIZ"))
                    || (Convert.ToString(ekler[i]).Contains("ISIM_SAHIPLIK_ONLAR_LERI"))
                     */

                    // Kisi
                    || (Convert.ToString(ekler[i]).Contains("ISIM_KISI_"))
                    /*
                    || (Convert.ToString(ekler[i]).Contains("ISIM_KISI_BEN_IM"))
                    || (Convert.ToString(ekler[i]).Contains("ISIM_KISI_SEN_SIN"))
                    || (Convert.ToString(ekler[i]).Contains("ISIM_KISI_BIZ_IZ"))
                    || (Convert.ToString(ekler[i]).Contains("ISIM_KISI_SIZ_SINIZ"))
                     */

                    // Diger
                    || (Convert.ToString(ekler[i]).Contains("ISIM_TANIMLAMA_DIR"))

                    // Fiiler icin

                    || (Convert.ToString(ekler[i]).Contains("FIIL_GECMISZAMAN_"))
                    || (Convert.ToString(ekler[i]).Contains("FIIL_SIMDIKIZAMAN_"))
                    || (Convert.ToString(ekler[i]).Contains("FIIL_GENISZAMAN_"))
                    || (Convert.ToString(ekler[i]).Contains("FIIL_GELECEKZAMAN_"))
                    || (Convert.ToString(ekler[i]).Contains("FIIL_KISI_"))
                    //    || (Convert.ToString(ekler[i]).Contains("FIIL_OLUMSUZLUK_"))
                    || (Convert.ToString(ekler[i]).Contains("FIIL_EMIR_"))
                    //|| (Convert.ToString(ekler[i]).Contains("FIIL_DONUSUM_"))
                    //  || (Convert.ToString(ekler[i]).Contains("ISIM_DONUSUM_"))
                    || (Convert.ToString(ekler[i]).Contains("FIIL_SART_"))
                    || (Convert.ToString(ekler[i]).Contains("FIIL_ISTEK_"))
                    || (Convert.ToString(ekler[i]).Contains("IMEK_"))
                    || (Convert.ToString(ekler[i]).Contains("FIIL_SUREKLILIK_"))
                    || (Convert.ToString(ekler[i]).Contains("FIIL_ZORUNLULUK_"))
                      || (Convert.ToString(ekler[i]).Contains("FIIL_MASTAR_"))
                    )
            {

                cekimEkiMi = true;
            }
            if (cekimEkiMi)
            {
                break;
            }
            else
            {

                yeni_ekler.Add(ekler[i]);
                j++;
            }
        }

        String kelimeson = "";

        if (j > 0)
        {
            kelimeson = zemberek.kelimeUret(kelime1.kok(), yeni_ekler);
        }
        else
        {
            kelimeson = kelime1.kok().icerik();
        }

        return kelimeson;



    }


}