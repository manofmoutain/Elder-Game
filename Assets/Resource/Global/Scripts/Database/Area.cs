using System;
using System.Collections;
using System.Collections.Generic;
using Global.Database;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Database
{
    [Serializable]
    public class Area
    {
        [BoxGroup("洲"), HideLabel, EnumToggleButtons]
        public Continents continents;

        [BoxGroup("亞洲"), ShowIfGroup("亞洲/continents", Value = Continents.亞洲), HideLabel, EnumToggleButtons]
        public AsiaNation asiaNation;

        [BoxGroup("歐洲"), ShowIfGroup("歐洲/continents", Value = Continents.歐洲), HideLabel, EnumToggleButtons]
        public EuropeNation europeNation;

        [BoxGroup("美洲"), ShowIfGroup("美洲/continents", Value = Continents.美洲), HideLabel, EnumToggleButtons]
        public AmericaNation americaNation;

        [BoxGroup("非洲"), ShowIfGroup("非洲/continents", Value = Continents.非洲), HideLabel, EnumToggleButtons]
        public AfricaNation africaNation;

        [BoxGroup("澳洲"), ShowIfGroup("澳洲/continents", Value = Continents.澳洲), HideLabel, EnumToggleButtons]
        public AustriaNation austriaNation;
    }

    public enum Continents
    {
        亞洲,
        歐洲,
        美洲,
        非洲,
        澳洲
    }

    public enum AsiaNation
    {
        中國,
        菲律賓,
        日本,
        泰國,
        台灣,
        越南
    }

    public enum EuropeNation
    {
        英國,
        法國,
        德國,
        義大利,
        瑞典
    }

    public enum AmericaNation
    {
        美國,
        加拿大,
        墨西哥,
        古巴,
        巴西
    }

    public enum AfricaNation
    {
        奈及利亞,
        埃及,
        剛果,
        南非共和國,
        盧安達
    }

    public enum AustriaNation
    {
        澳大利亞,
        紐西蘭,
    }

}
