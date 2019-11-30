﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


public static class clsKernel
{
    static List<clsHastalik> _Hastaliklar = new List<clsHastalik>();
    static List<clsKelime> _ElenenKelimeler = new List<clsKelime>();
    static List<clsKelime> _EslenenKelimeler = new List<clsKelime>();
    static string _sHastaAciklama = "";

    public static List<clsHastalik> Hastaliklar
    {
        get { return _Hastaliklar; }
        set { _Hastaliklar = value; }
    }

    public static string sHastaAciklama
    {
        get { return _sHastaAciklama; }
        set { _sHastaAciklama = value; }
    }

    public static void Initialize()
    {
        clsDB DB = new clsDB();
        clsHastalik Hastalik;
        clsBelirti Belirti;
        clsKelime Kelime;
        clsEslesenKelime EslesenKelime;
        DataTable dtHastaliklar, dtHastalikBelirtileri, dtElenenKelimeler,dtEslesenKelimeler;
        DataRow drHastalik, drHastalikBelirtisi, drElenenKelime,drEslesenKelime, drBelirti;

        dtHastaliklar = DB.GetHastaliklar();

        int i = 0, j = 0;
        for (i = 0; i < dtHastaliklar.Rows.Count; i++)
        {
            Hastalik = new clsHastalik();
            drHastalik = dtHastaliklar.Rows[i];
            Hastalik.iKodu = (int)drHastalik["Kodu"];
            Hastalik.sAdi = drHastalik["Adi"].ToString();
            dtHastalikBelirtileri = DB.GetHastalikBelirtileri(Hastalik.iKodu);
            for (j = 0; j < dtHastalikBelirtileri.Rows.Count; i++)
            {
                Belirti = new clsBelirti();
                drHastalikBelirtisi = dtHastalikBelirtileri.Rows[j];
                Belirti.iKodu = (int)drHastalikBelirtisi["BelirtiKodu"];
                Belirti.sAdi = drHastalikBelirtisi["BelirtiAdi"].ToString();
                Belirti.iHastalikBelirtiKodu = (int)drHastalikBelirtisi["HastalikBelirtiKodu"];
                Hastalik.Belirtiler.Add(Belirti);
            }
            _Hastaliklar.Add(Hastalik);
        }
        
        dtElenenKelimeler = DB.GetElenenKelimeler();
        for (i = 0; i < dtElenenKelimeler.Rows.Count; i++)
        {
            Kelime = new clsKelime();
            drElenenKelime = dtElenenKelimeler.Rows[i];
            Kelime.iKodu = (int)drElenenKelime["Kodu"];
            Kelime.sAdi = drElenenKelime["Adi"].ToString();
            _ElenenKelimeler.Add(Kelime);
        }

        dtEslesenKelimeler = DB.GetEslesenKelimeler();
        for (i = 0; i < dtEslesenKelimeler.Rows.Count; i++)
        {
            EslesenKelime = new clsEslesenKelime();
            drEslesenKelime = dtEslesenKelimeler.Rows[i];
            EslesenKelime.iKodu = (int)drEslesenKelime["Kodu"];
            EslesenKelime.sAdi = drEslesenKelime["Adi"].ToString();
            EslesenKelime.sEslenigi = drEslesenKelime["Eslenigi"].ToString();
            _EslesenKelimeler.Add(EslesenKelime);
        }
    }

}